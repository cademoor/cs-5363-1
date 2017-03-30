using Ttu.Domain;

namespace Ttu.Presentation
{
    public class NullPresenterFactory : IPresenterFactory
    {

        public static IPresenterFactory Singleton = new NullPresenterFactory();

        #region Constructors

        protected NullPresenterFactory()
        {
            UnitOfWork = NullUnitOfWork.Singleton;
            User = null;
        }

        #endregion

        #region Properties

        public virtual IUnitOfWork UnitOfWork { get; protected set; }
        public virtual IUser User { get; protected set; }

        #endregion

        #region Public Methods

        public virtual LogOnPresenter CreateLogOnPresenter()
        {
            return null;
        }

        public virtual ManageOrganizationPresenter CreateManageOrganizationPresenter()
        {
            return null;
        }

        public virtual ManageRecommendationPresenter CreateManageRecommendationPresenter()
        {
            return null;
        }

        public virtual ManageUserPresenter CreateManageUserPresenter()
        {
            return null;
        }

        #endregion

    }
}
