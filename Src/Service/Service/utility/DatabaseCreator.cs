using System.Data.SqlClient;

namespace Ttu.Service
{
    public class DatabaseCreator
    {

        # region Constructors

        public DatabaseCreator(string connectionString)
        {
            ConnectionString = connectionString;
        }

        # endregion

        # region Properties

        private string ConnectionString { get; set; }

        # endregion

        # region Public Methods

        public void Create()
        {
            CreateEmptySchema();
        }

        # endregion

        # region Helper Methods

        private void CreateEmptySchema()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnectionString);
            string originalDatabaseName = builder.InitialCatalog;
            builder.InitialCatalog = "master";

            SqlConnection sqlConnection = new SqlConnection(builder.ConnectionString);

            try
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = string.Format("IF DB_ID('{0}') IS NULL CREATE DATABASE [{0}]", originalDatabaseName);
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                if (sqlConnection.State != System.Data.ConnectionState.Closed)
                {
                    sqlConnection.Close();
                }
            }
        }

        # endregion

    }
}
