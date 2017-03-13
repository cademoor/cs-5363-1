using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.IO;
using Ttu.Domain;

namespace Ttu.Service
{
    public class ServiceInitializer : AbstractApplicationLogger
    {

        #region Public Methods

        public ISessionFactory Initialize(bool forceDropBeforeCreate, bool writeSqliteLibraries)
        {
            if (writeSqliteLibraries)
            {
                InitializeSqlite();
            }

            ISessionFactory sessionFactory = InitializeDatabase(forceDropBeforeCreate);
            TestStatefulSession(sessionFactory);
            ServiceEnvironment.Singleton.SetSessionFactory(sessionFactory);
            return sessionFactory;
        }

        #endregion

        #region Helper Methods

        private ISessionFactory BuildSessionFactory(Configuration cfg)
        {
            ISessionFactory sessionFactory = cfg.BuildSessionFactory();
            if (sessionFactory == null)
            {
                throw new PersistenceException("A session factory could not be created.");
            }

            return sessionFactory;
        }

        private void CreateDatabaseFileIfApplicable(Configuration configuration)
        {
            try
            {
                // new SchemaExport(configuration).Create(true, true);
                new SchemaUpdate(configuration).Execute(false, true);
            }
            catch (Exception ex)
            {
                LogError("Database could not be created/updated: {0}", ex.Message);
            }
        }

        private ISessionFactory InitializeDatabase(bool forceDropBeforeCreate)
        {
            Configuration cfg = InitializeNHibernateConfiguration();
            InstallSchema(cfg, forceDropBeforeCreate);
            return BuildSessionFactory(cfg);
        }

        private void InitializeFile(string directory, string fileName)
        {
            if (File.Exists(fileName))
            {
                return;
            }

            AssemblyFileReader reader = new AssemblyFileReader(GetType().Assembly);
            byte[] fileBytes = reader.ReadBinaryFile(string.Format("Ttu.Service.lib.{0}.{1}", directory, fileName));
            File.WriteAllBytes(fileName, fileBytes);
        }

        private Configuration InitializeNHibernateConfiguration()
        {
            Configuration cfg = new Configuration();
            cfg.Configure(Path.Combine(System.Environment.CurrentDirectory, "nhibernate.cfg.xml"));
            cfg.AddAssembly(typeof(SessionDecorator).Assembly);
            return cfg;
        }

        private void InitializeSqlite()
        {
            bool require64BitLink = System.Environment.Is64BitOperatingSystem || System.Environment.Is64BitProcess;
            string directory = require64BitLink ? "x64" : "x86";

            InitializeFile(directory, "SQLite.Interop.dll");
            InitializeFile(directory, "System.Data.SQLite.dll");
        }

        private void InstallSchema(Configuration cfg, bool forceDropBeforeCreate)
        {
            CreateDatabaseFileIfApplicable(cfg);
        }

        private void TestStatefulSession(ISessionFactory sessionFactory)
        {
            ISession openSession = null;
            try
            {
                openSession = sessionFactory.OpenSession();
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw new PersistenceException("A session could not be opened.");
            }
            finally
            {
                if (openSession != null)
                {
                    openSession.Close();
                }
            }
        }

        #endregion

    }
}
