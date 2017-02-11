using Ttu.Domain;

namespace Ttu.Presentation
{
    public class AbstractPresenter
    {

        # region Constructors

        public AbstractPresenter(IUser user, IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            User = user;
        }

        # endregion

        # region Properties

        protected IUnitOfWork UnitOfWork { get; private set; }
        protected IUser User { get; private set; }

        # endregion

    }
}
