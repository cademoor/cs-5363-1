using Ttu.Domain;

namespace Ttu.Service
{
    public class UserService : AbstractService, IUserService
    {

        #region Constructors

        public UserService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region Public Methods

        public void AddUser(IUser user)
        {
            UnitOfWork.Users.Add(user);
        }

        public IUser GetUser(string userId)
        {
            return UnitOfWork.Users.FindByUnique(u => u.UserId == userId);
        }

        public IUser GetUser(int recordId)
        {
            return UnitOfWork.Users.FindByRecordId(recordId);
        }

        public IUser[] GetUsers()
        {
            return UnitOfWork.Users.FindAll();
        }

        public void RemoveUser(int recordId)
        {
            // guard clause - not found
            IUser user = GetUser(recordId);
            if (user == null)
            {
                return;
            }

            UnitOfWork.Users.Remove(user);
        }

        public void RemoveUser(IUser user)
        {
            // guard clause - invalid input
            if (user == null)
            {
                return;
            }

            RemoveUser(user.RecordId);
        }

        #endregion

    }
}
