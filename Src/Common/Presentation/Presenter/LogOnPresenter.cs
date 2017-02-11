using System;
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
            ValidateCredentials(userId, password);
            return ConfigureAuthenticatedSession(userId, password);
        }

        # endregion

        # region Helper Methods

        private string ConfigureAuthenticatedSession(string userId, string password)
        {
            string sessionId = Guid.NewGuid().ToString();
            IUnitOfWork unitOfWork = NullUnitOfWork.Singleton;
            IUser user = NullUser.Singleton;

            IPresenterFactory presenterFactory = new PresenterFactory(user, unitOfWork, sessionId);
            PresentationEnvironment.MapPresenterFactory(sessionId, presenterFactory);
            return sessionId;
        }

        private void ValidateCredentials(string userId, string password)
        {
            // TODO:ACM - this is just a sample for now...need to hook up once we have real users
            if (userId != "SampleUser" || password != "SamplePassword")
            {
                throw new BusinessException("User Id and Password combination did not match.");
            }
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
