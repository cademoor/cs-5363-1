using Ttu.Domain;

namespace Ttu.Presentation
{
    public abstract class AbstractViewState : IViewState
    {

        #region Constructors

        protected AbstractViewState(IPresenterFactory presenterFactory)
        {
            PresenterFactory = presenterFactory ?? NullPresenterFactory.Singleton;
        }

        #endregion

        #region Properties

        public IUnitOfWork UnitOfWork { get { return PresenterFactory.UnitOfWork; } }
        public IUser User { get { return PresenterFactory.User; } }
        public IOrganization Organization { get { return PresenterFactory.Organization; } }

        private IPresenterFactory PresenterFactory { get; set; }

        #endregion

    }
}
