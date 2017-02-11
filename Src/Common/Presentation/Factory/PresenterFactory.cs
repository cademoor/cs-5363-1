using Ttu.Domain;

namespace Ttu.Presentation
{
    public class PresenterFactory : IPresenterFactory
    {

        # region Constructors

        public PresenterFactory(IUser user, IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            User = user;
        }

        # endregion

        # region Properties

        public IUnitOfWork UnitOfWork { get; private set; }
        public IUser User { get; private set; }

        # endregion

        # region Public Methods

        public ManageUserPresenter CreateManageUserPresenter()
        {
            return new ManageUserPresenter(User, UnitOfWork);
        }

        # endregion

    }
}
