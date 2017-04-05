﻿using Ttu.Domain;

namespace Ttu.Presentation
{
    public class LogOnPresenter : AbstractPresenter
    {

        #region Constructors

        public LogOnPresenter(IViewState viewState)
            : base(viewState)
        {
        }

        #endregion

        #region Public Methods

        public IUnitOfWork LogOn(string userId, string password)
        {
            IUnitOfWork uow = ValidateCredentials(userId, password);
            return ConfigureAuthenticatedSession(uow);
        }

        public IUnitOfWork RegisterUser(RegisterUserModel registerUserModel)
        {
            ValidateInput(registerUserModel);

            IUnitOfWork uow = CreateUnitOfWork();
            AddUser(uow, registerUserModel);
            return ConfigureAuthenticatedSession(uow);
        }

        public IUser GetUser(string userId, string password)
        {
            if (UnitOfWork == null)
            {
                return null;
            }

            return UnitOfWork.User;
        }
        #endregion

        #region Helper Methods

        private void AddUser(IUnitOfWork uow, RegisterUserModel registerUserModel)
        {
            IUser newUser = new User(registerUserModel.UserId);
            registerUserModel.ApplyTo(newUser);

            uow.Users.Add(newUser);
        }

        private IUnitOfWork ConfigureAuthenticatedSession(IUnitOfWork uow)
        {
            string sessionId = uow.SessionId;
            IUnitOfWork unitOfWork = uow;
            IUser user = uow.User;

            IPresenterFactory presenterFactory = new PresenterFactory(user, unitOfWork, sessionId);
            PresentationEnvironment.MapPresenterFactory(sessionId, presenterFactory);
            return unitOfWork;
        }

        private IUnitOfWork CreateUnitOfWork()
        {
            IAuthenticationService authenticationService = ServiceFactory.CreateAuthenticationService();
            return authenticationService.CreateAdHocUnitOfWork();
        }

        private IUnitOfWork ValidateCredentials(string userId, string password)
        {
            IAuthenticationService authenticationService = ServiceFactory.CreateAuthenticationService();
            return authenticationService.Authenticate(userId, password);
        }

        #endregion

    }
}
