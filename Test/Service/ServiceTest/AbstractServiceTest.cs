using NHibernate;
using System;
using Ttu.Service;

namespace Ttu.ServiceTest
{
    public class AbstractServiceTest
    {

        # region Constructors

        public AbstractServiceTest()
        {
            if (Session == null)
            {
                ISessionFactory sessionFactory = new ServiceInitializer().Initialize(true);

                ISession openSession = sessionFactory.OpenSession();
                Session = new SessionDecorator(openSession, Guid.NewGuid().ToString());
            }
        }

        # endregion

        # region Properties

        protected static SessionDecorator Session { get; private set; }

        # endregion

    }
}
