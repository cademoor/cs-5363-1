using NHibernate;
using System;

namespace Ttu.Service
{
    public class ServiceEnvironment
    {

        public static ServiceEnvironment Singleton = new ServiceEnvironment();

        # region Constructors

        public ServiceEnvironment()
        {
            SessionFactory = null;
        }

        # endregion

        # region Properties

        public ISessionFactory SessionFactory { get; private set; }

        # endregion

        # region Public Methods

        public SessionDecorator OpenSession()
        {
            // guard clause - not initialized properly
            ISession openSession = SessionFactory.OpenSession();
            if (openSession == null)
            {
                return null;
            }

            string sessionId = Guid.NewGuid().ToString();
            return new SessionDecorator(openSession, sessionId);
        }

        public void SetSessionFactory(ISessionFactory sessionFactory)
        {
            SessionFactory = sessionFactory;
        }

        # endregion

    }
}
