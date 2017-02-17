using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using Ttu.Domain;

namespace Ttu.Service
{
    public class ServiceInitializer : AbstractApplicationLogger
    {

        # region Constants

        private const string DEFAULT_NHIBERNATE_TABLENAME = "hibernate_unique_key";

        # endregion

        # region Public Methods

        public ISessionFactory Initialize(bool forceDropBeforeCreate)
        {
            ISessionFactory sessionFactory = InitializeDatabase(forceDropBeforeCreate);
            TestStatefulSession(sessionFactory);
            ServiceEnvironment.Singleton.SetSessionFactory(sessionFactory);
            return sessionFactory;
        }

        # endregion

        # region Helper Methods

        private ISessionFactory BuildSessionFactory(Configuration cfg)
        {
            ISessionFactory sessionFactory = cfg.BuildSessionFactory();
            if (sessionFactory == null)
            {
                throw new PersistenceException("A session factory could not be created.");
            }

            return sessionFactory;
        }

        private void CreateDatabase(Configuration cfg)
        {
            try
            {
                //new SchemaExport(cfg).Create(false, true);
                new SchemaUpdate(cfg).Execute(false, true);
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        private void CreateEmptyDatabase(Configuration cfg)
        {
            string connectionString = cfg.GetProperty(NHibernate.Cfg.Environment.ConnectionString);
            new DatabaseCreator(connectionString).Create();
        }

        private void DropDatabase(Configuration cfg)
        {
            try
            {
                new SchemaExport(cfg).Drop(false, true);
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        private ISessionFactory InitializeDatabase(bool forceDropBeforeCreate)
        {
            Configuration cfg = InitializeNHibernateConfiguration();
            CreateEmptyDatabase(cfg);
            InstallSchema(cfg, forceDropBeforeCreate);
            return BuildSessionFactory(cfg);
        }

        private Configuration InitializeNHibernateConfiguration()
        {
            Configuration cfg = new Configuration();
            cfg.Configure("nhibernate.cfg.xml");
            cfg.AddAssembly(typeof(SessionDecorator).Assembly);
            return cfg;
        }

        private void InstallSchema(Configuration cfg, bool forceDropBeforeCreate)
        {
            if (forceDropBeforeCreate)
            {
                DropDatabase(cfg);
            }
            CreateDatabase(cfg);
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

        # endregion

    }
}
