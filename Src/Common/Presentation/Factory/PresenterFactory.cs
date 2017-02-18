using Ttu.Domain;

namespace Ttu.Presentation
{
    public class PresenterFactory : IPresenterFactory
    {

        #region Constructors

        public PresenterFactory(IUser user, IUnitOfWork unitOfWork, string sessionId)
        {
            SessionId = sessionId;
            UnitOfWork = unitOfWork;
            User = user;

            InitializeFeatureViewStates();
        }

        #endregion

        #region Properties - Feature

        public LogOnViewState LogOnViewState { get; set; }
        public ManageUserViewState ManageUserViewState { get; set; }

        #endregion

        #region Properties - Session

        public string SessionId { get; private set; }
        public IUnitOfWork UnitOfWork { get; private set; }
        public IUser User { get; private set; }

        #endregion

        #region Public Methods

        public LogOnPresenter CreateLogOnPresenter()
        {
            return new LogOnPresenter(LogOnViewState);
        }

        public ManageUserPresenter CreateManageUserPresenter()
        {
            return new ManageUserPresenter(ManageUserViewState);
        }

        #endregion

        #region Helper Methods

        private void InitializeFeatureViewStates()
        {
            LogOnViewState = new LogOnViewState(this);
            ManageUserViewState = new ManageUserViewState(this);
        }

        #endregion

    }
}
