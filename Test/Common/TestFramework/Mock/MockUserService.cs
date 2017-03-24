using System.Linq;
using Ttu.Domain;

namespace Ttu.TestFramework
{
    public class MockUserService : NullUserService
    {

        #region Constructors

        public MockUserService()
        {
            MockUnitOfWork = new MockUnitOfWork();
        }

        #endregion

        #region Properties

        public IUnitOfWork MockUnitOfWork { get; set; }

        #endregion

        #region IUserService Members

        public override void AddUser(IUser user)
        {
            IUser[] users = GetUsers();
            if (users.Length == 0)
            {
                (user as User).RecordId = 1;
            }
            else
            {
                (user as User).RecordId = users.Max(u => u.RecordId) + 1;
            }
            MockUnitOfWork.Users.Add(user);
        }

        public override IUser GetUser(string userId)
        {
            return MockUnitOfWork.Users.FindByUnique(u => u.UserId == userId);
        }

        public override IUser GetUser(int recordId)
        {
            return MockUnitOfWork.Users.FindByRecordId(recordId);
        }

        public override IUser[] GetUsers()
        {
            return MockUnitOfWork.Users.FindAll();
        }

        public override void RemoveUser(int recordId)
        {
            // guard clause - not found
            IUser user = GetUser(recordId);
            if (user == null)
            {
                return;
            }

            MockUnitOfWork.Users.Remove(user);
        }

        public override void RemoveUser(IUser user)
        {
            // guard clause - invalid input
            if (user == null)
            {
                return;
            }

            MockUnitOfWork.Users.Remove(user);
        }

        #endregion

    }
}
