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

        public IUnitOfWork UnitOfWork { get; private set; }
        public IUser User { get; private set; }

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

        public virtual ManageUserPresenter CreateManageUserPresenter()
        {
            return null;
        }

        #endregion

    }
}
