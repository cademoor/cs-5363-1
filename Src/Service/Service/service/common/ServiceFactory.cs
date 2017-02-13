using Ttu.Domain;

namespace Ttu.Service
{
    public class ServiceFactory : IServiceFactory
    {

        # region Public Methods

        public IAuthenticationService CreateAuthenticationService()
        {
            return new AuthenticationService();
        }

        public IUserService CreateUserService(IUnitOfWork unitOfWork)
        {
            return new UserService(unitOfWork);
        }

        # endregion

    }
}
