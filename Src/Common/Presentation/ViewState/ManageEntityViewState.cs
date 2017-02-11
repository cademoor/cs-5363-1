using Ttu.Domain;

namespace Ttu.Presentation
{
    public class ManageEntityViewState : AbstractViewState
    {

        # region Constructors

        protected ManageEntityViewState(IUser user, IUnitOfWork unitOfWork)
            : base(user, unitOfWork)
        {
        }

        # endregion

    }
}
