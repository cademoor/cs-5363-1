using NHibernate;
using System;
using System.IO;
using Ttu.Domain;
using Ttu.Service;

namespace Ttu.ServiceTest
{
    public class AbstractServiceTest
    {

        protected const string USER_ID = "ADMIN";
        protected const string ORG_NAME = "SERVICE_TEST_ORGANIZATION";

        #region Constructors

        public AbstractServiceTest()
        {
            if (Session == null)
            {
                try
                {
                    File.Delete("volunteermetest.db");
                }
                catch
                {
                    // best effort
                }

                ISessionFactory sessionFactory = new ServiceInitializer().Initialize(true, true);
                ISession openSession = sessionFactory.OpenSession();
                Session = new SessionDecorator(openSession, Guid.NewGuid().ToString());
            }

            IUser user = InitializeUser();
            IOrganization organization = InitializeOrganization();
            UnitOfWork = new UnitOfWork(Session, user);
            User = user;
        }

        #endregion

        #region Properties

        protected static SessionDecorator Session { get; private set; }
        protected IUnitOfWork UnitOfWork;
        protected IUser User;
        protected IOrganization Org;

        #endregion

        #region Helper Methods

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

        private IOrganization InitializeOrganization()
        {
            IUser testUser = InitializeUser();

            IUnitOfWorkRepository<IOrganization> repository = new UnitOfWorkRepository<IOrganization>(Session);

            // guard clause - user already exists
            IOrganization foundOrg = repository.FindByUnique(o => o.Name == ORG_NAME);
            if (foundOrg != null)
            {
                return foundOrg;
            }

            IOrganization newOrg = new Organization(testUser, ORG_NAME);
            repository.Add(newOrg);
            Session.Flush();
            return newOrg;
        }

        #endregion

    }
}
