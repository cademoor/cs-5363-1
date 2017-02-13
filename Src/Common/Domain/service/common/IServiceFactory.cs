namespace Ttu.Domain
{
    public interface IServiceFactory
    {

        IAuthenticationService CreateAuthenticationService();

        IUserService CreateUserService(IUnitOfWork unitOfWork);

    }
}
