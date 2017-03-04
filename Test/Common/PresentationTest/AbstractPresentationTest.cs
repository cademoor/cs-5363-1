using System;
using Ttu.Domain;
using Ttu.Presentation;

namespace Ttu.PresentationTest
{
    public class AbstractPresentationTest
    {

        #region Constructors

        protected AbstractPresentationTest()
        {
            Initialize();
            PresenterFactory = CreatePresenterFactory();
        }

        #endregion

        #region Properties

        protected PresenterFactory PresenterFactory;
        protected MockUnitOfWork UnitOfWork;
        protected IUser User;

        #endregion

        #region Helper Methods

        private void Initialize()
        {
            PresentationEnvironment.Singleton.SetServiceFactory(new MockServiceFactory());

            IUser user = new User("TESTUSER");

            UnitOfWork = new MockUnitOfWork();
            UnitOfWork.User = user;

            User = user;
        }

        private PresenterFactory CreatePresenterFactory()
        {
            return new PresenterFactory(User, UnitOfWork, Guid.NewGuid().ToString());
        }

        #endregion

    }
}
