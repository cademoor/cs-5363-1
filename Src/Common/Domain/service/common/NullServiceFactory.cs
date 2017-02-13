namespace Ttu.Domain
{
    public class NullServiceFactory : IServiceFactory
    {

        public static IServiceFactory Singleton = new NullServiceFactory();

        # region Constructors

        private NullServiceFactory()
        {
        }

        # endregion

        # region Public Methods

        public virtual IAuthenticationService CreateAuthenticationService()
        {
            return NullAuthenticationService.Singleton;
        }

        public virtual IUserService CreateUserService(IUnitOfWork unitOfWork)
        {
            return NullUserService.Singleton;
        }

        # endregion

    }
}
