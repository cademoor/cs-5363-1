using Ttu.Domain;

namespace Ttu.PresentationTest
{
    public class MockServiceFactory : IServiceFactory
    {

        #region Constructors

        public MockServiceFactory()
        {
        }

        #endregion

        #region Properties



        #endregion

        #region Public Methods

        public IAuthenticationService CreateAuthenticationService()
        {
            throw new System.NotImplementedException();
        }

        public IUserService CreateUserService(IUnitOfWork unitOfWork)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Helper Methods



        #endregion

    }
}
