namespace Ttu.Domain
{
    public interface IAuthenticationService
    {

        IUnitOfWork Authenticate(string userId, string password);
        IUnitOfWork CreateAdHocUnitOfWork();

    }
}
