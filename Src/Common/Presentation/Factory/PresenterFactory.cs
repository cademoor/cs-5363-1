using Ttu.Domain;

namespace Ttu.Presentation
{
    public class PresenterFactory : NullPresenterFactory
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
        public ManageOrganizationViewState ManageOrganizationViewState { get; set; }
        public ManageUserViewState ManageUserViewState { get; set; }

        #endregion

        #region Properties - Session

        public string SessionId { get; private set; }

        #endregion

        #region Public Methods

        public override LogOnPresenter CreateLogOnPresenter()
        {
            return new LogOnPresenter(LogOnViewState);
        }

        public override ManageOrganizationPresenter CreateManageOrganizationPresenter()
        {
            return new ManageOrganizationPresenter(ManageOrganizationViewState);
        }

        public override ManageUserPresenter CreateManageUserPresenter()
        {
            return new ManageUserPresenter(ManageUserViewState);
        }

        #endregion

        #region Helper Methods

        private void InitializeFeatureViewStates()
        {
            LogOnViewState = new LogOnViewState(this);
            ManageOrganizationViewState = new ManageOrganizationViewState(this);
            ManageUserViewState = new ManageUserViewState(this);
        }

        #endregion

    }
}
