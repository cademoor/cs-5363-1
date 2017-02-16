using NHibernate;
using System;
using Ttu.Domain;
using Ttu.Service;

namespace Ttu.ServiceTest
{
    public class AbstractServiceTest
    {

        protected const string USER_ID = "ADMIN";

        # region Constructors

        public AbstractServiceTest()
        {
            if (Session == null)
            {
                ISessionFactory sessionFactory = new ServiceInitializer().Initialize(true);

                ISession openSession = sessionFactory.OpenSession();
                Session = new SessionDecorator(openSession, Guid.NewGuid().ToString());
            }

            IUser user = InitializeUser();
            UnitOfWork = new UnitOfWork(Session, user);
            User = user;
        }

        # endregion

        # region Properties

        protected static SessionDecorator Session { get; private set; }
        protected IUnitOfWork UnitOfWork;
        protected IUser User;

        # endregion

        # region Helper Methods

        private IUser InitializeUser()
        {
            IUnitOfWorkRepository<IUser> repository = new UnitOfWorkRepository<IUser>(Session);

            // guard clause - user already exists
            IUser foundUser = repository.FindByUnique(u => u.UserId == USER_ID);
            if (foundUser != null)
            {
                return foundUser;
            }

            IUser newUser = new User(USER_ID);
            repository.Add(newUser);
            Session.Flush();
            return newUser;
        }

        # endregion

    }
}
