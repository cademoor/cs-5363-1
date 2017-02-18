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

        private IPresenterFactory PresenterFactory { get; set; }

        #endregion

    }
}
