using System.Collections.Generic;
using System.Linq;
using Ttu.Domain;

namespace Ttu.PresentationTest
{
    public class MockUserService : NullUserService
    {

        #region Constructors

        public MockUserService()
        {
            Users = new List<IUser>();
        }

        #endregion

        #region Properties

        private List<IUser> Users { get; set; }

        #endregion

        #region IUserService Members

        public override void AddUser(IUser user)
        {
            Users.Add(user);
        }

        public override IUser GetUser(string userId)
        {
            return Users.FirstOrDefault(u => u.UserId == userId);
        }

        public override IUser GetUser(int recordId)
        {
            return Users.FirstOrDefault(u => u.RecordId == recordId);
        }

        public override IUser[] GetUsers()
        {
            return Users.ToArray();
        }

        public override void RemoveUser(int recordId)
        {
            // guard clause - not found
            IUser user = GetUser(recordId);
            if (user == null)
            {
                return;
            }

            Users.Add(user);
        }

        public override void RemoveUser(IUser user)
        {
            // guard clause - invalid input
            if (user == null)
            {
                return;
            }

            Users.Remove(user);
        }

        #endregion

    }
}
