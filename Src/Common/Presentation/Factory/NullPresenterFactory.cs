using Ttu.Domain;
using Ttu.Presentation.Presenter;

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
        public virtual IOrganization Organization { get; protected set; }

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

        public virtual ManageOrganizationUserPresenter CreateManageOrganizationUserPresenter()
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

        public virtual ManageProjectPresenter CreateManageProjectPresenter()
        {
            return null;
        }

        public virtual ProjectPresenter CreateProjectPresenter()
        {
            return null;
        }

        #endregion

    }
}
