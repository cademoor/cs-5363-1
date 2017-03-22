using Ttu.Domain;

namespace Ttu.TestFramework
{
    public class MockAuthenticationService : NullAuthenticationService
    {

        #region Constructors

        public MockAuthenticationService()
        {
            MockUnitOfWork = new MockUnitOfWork();
        }

        #endregion

        #region Properties

        public IUnitOfWork MockUnitOfWork { get; set; }

        #endregion

        #region IAuthenticationService Members

        public override IUnitOfWork Authenticate(string userId, string password)
        {
            return MockUnitOfWork;
        }

        public override IUnitOfWork CreateAdHocUnitOfWork()
        {
            return MockUnitOfWork;
        }

        #endregion

    }
}
