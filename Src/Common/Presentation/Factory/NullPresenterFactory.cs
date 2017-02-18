using Ttu.Domain;

namespace Ttu.Presentation
{
    public class NullPresenterFactory : IPresenterFactory
    {

        public static IPresenterFactory Singleton = new NullPresenterFactory();

        #region Constructors

        private NullPresenterFactory()
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

        public LogOnPresenter CreateLogOnPresenter()
        {
            return null;
        }

        public ManageUserPresenter CreateManageUserPresenter()
        {
            return null;
        }

        #endregion

    }
}
