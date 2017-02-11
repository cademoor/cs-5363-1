using Ttu.Domain;

namespace Ttu.Presentation
{
    public abstract class AbstractViewState
    {

        # region Constructors

        protected AbstractViewState(IUser user, IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            User = user;
        }

        # endregion

        # region Properties

        public IUnitOfWork UnitOfWork { get; private set; }
        public IUser User { get; private set; }

        # endregion

    }
}
