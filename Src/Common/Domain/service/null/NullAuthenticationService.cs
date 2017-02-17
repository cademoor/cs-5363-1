namespace Ttu.Domain
{
    public class NullAuthenticationService : IAuthenticationService
    {

        public static IAuthenticationService Singleton = new NullAuthenticationService();

        # region Constructors

        public NullAuthenticationService()
        {
        }

        # endregion

        # region Public Methods

        public virtual IUnitOfWork Authenticate(string userId, string password)
        {
            return NullUnitOfWork.Singleton;
        }

        public virtual IUnitOfWork CreateAdHocUnitOfWork()
        {
            return NullUnitOfWork.Singleton;
        }

        # endregion

    }
}
