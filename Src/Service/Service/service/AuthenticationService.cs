using Ttu.Domain;

namespace Ttu.Service
{
    public class AuthenticationService : AbstractService, IAuthenticationService
    {

        #region Constructors

        public AuthenticationService()
            : base(NullUnitOfWork.Singleton)
        {
        }

        #endregion

        #region Public Methods

        public IUnitOfWork Authenticate(string userId, string password)
        {
            SessionDecorator openSession = ServiceEnvironment.OpenSession();

            IUser user = GetUser(openSession, userId);
            ValidatePassword(user, password);

            return new UnitOfWork(openSession, user);
        }

        public IUnitOfWork CreateAdHocUnitOfWork()
        {
            SessionDecorator openSession = ServiceEnvironment.OpenSession();
            return new UnitOfWork(openSession, null);
        }

        #endregion

        #region Helper Methods

        private IUser GetUser(SessionDecorator openSession, string userId)
        {
            IUser user = openSession.QueryOver<IUser>().WhereRestrictionOn(u => u.UserId).IsInsensitiveLike(userId).SingleOrDefault();
            if (user == null)
            {
                throw new BusinessException("User not found.");
            }

            return user;
        }

        private void ValidatePassword(IUser user, string password)
        {
            if (!user.MatchesPassword(password))
            {
                throw new BusinessException("Invalid password.");
            }
        }

        #endregion

    }
}
