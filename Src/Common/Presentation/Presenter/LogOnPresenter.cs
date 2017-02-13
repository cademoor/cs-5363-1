using Ttu.Domain;

namespace Ttu.Presentation
{
    public class LogOnPresenter : AbstractPresenter
    {

        # region Constructors

        public LogOnPresenter(IUser user, IUnitOfWork unitOfWork)
            : base(user, unitOfWork)
        {
        }

        # endregion

        # region Public Methods

        public string LogOn(string userId, string password)
        {
            ValidateUserId(userId);
            ValidatePassword(password);
            IUnitOfWork uow = ValidateCredentials(userId, password);
            return ConfigureAuthenticatedSession(uow);
        }

        # endregion

        # region Helper Methods

        private string ConfigureAuthenticatedSession(IUnitOfWork uow)
        {
            string sessionId = uow.SessionId;
            IUnitOfWork unitOfWork = uow;
            IUser user = uow.User;

            IPresenterFactory presenterFactory = new PresenterFactory(user, unitOfWork, sessionId);
            PresentationEnvironment.MapPresenterFactory(sessionId, presenterFactory);
            return sessionId;
        }

        private IUnitOfWork ValidateCredentials(string userId, string password)
        {
            IAuthenticationService authenticationService = ServiceFactory.CreateAuthenticationService();
            return authenticationService.Authenticate(userId, password);
        }

        private void ValidatePassword(string password)
        {
            ValidateValue("Password", password, Constants.USER_PASSWORD_MIN_LENGTH, Constants.USER_PASSWORD_MAX_LENGTH, InputType.AlphaNumericWithSymbols);
        }

        private void ValidateUserId(string userId)
        {
            ValidateValue("User Id", userId, Constants.USER_ID_MIN_LENGTH, Constants.USER_ID_MAX_LENGTH, InputType.AlphaNumericWithSymbols);
        }

        # endregion

    }
}
