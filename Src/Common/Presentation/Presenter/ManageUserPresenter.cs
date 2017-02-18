using Ttu.Domain;

namespace Ttu.Presentation
{
    public class ManageUserPresenter : AbstractPresenter
    {

        #region Constructors

        public ManageUserPresenter(IUser user, IUnitOfWork unitOfWork)
            : base(user, unitOfWork)
        {
        }

        #endregion

    }
}
