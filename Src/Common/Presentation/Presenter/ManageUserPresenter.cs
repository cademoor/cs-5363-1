using System.Linq;
using Ttu.Domain;

namespace Ttu.Presentation
{
    public class ManageUserPresenter : AbstractPresenter
    {

        #region Constructors

        public ManageUserPresenter(ManageUserViewState viewState)
            : base(viewState)
        {
            UserService = CreateUserService();
            VolunteerProfileService = CreateVolunteerProfileService();
        }

        #endregion

        #region Properties

        private IUserService UserService { get; set; }
        private IVolunteerProfileService VolunteerProfileService { get; set; }

        #endregion

        #region Public Methods

        public void AddUser(UserModel userModel)
        {
            ValidateInput(userModel);

            IUser user = new User(userModel.UserId);
            userModel.ApplyTo(user);

            UserService.AddUser(user);
            Commit();
        }

        public void AddVolunteerProfile(IVolunteerProfile volunteerProfile)
        {
            ValidateInput(volunteerProfile);

            VolunteerProfileService.AddVolunteerProfile(volunteerProfile);
            Commit();
        }

        public UserModel GetUser(string userId)
        {
            // guard clause - not found
            IUser user = UserService.GetUser(userId);
            if (user == null)
            {
                return null;
            }

            return CreateUserModel(user);
        }

        public UserModel GetUser(int recordId)
        {
            // guard clause - not found
            IUser user = UserService.GetUser(recordId);
            if (user == null)
            {
                return null;
            }

            return CreateUserModel(user);
        }

        public UserModel[] GetUsers()
        {
            return GetVisibleUsers().Select(u => CreateUserModel(u)).ToArray();
        }

        public IVolunteerProfile GetVolunteerProfile(UserModel userModel)
        {
            // guard clause - invalid input
            if (userModel == null)
            {
                return null;
            }

            // guard clause - not found
            IUser user = UserService.GetUser(userModel.RecordId);
            if (user == null)
            {
                return null;
            }

            return VolunteerProfileService.GetVolunteerProfile(user);
        }

        public void RemoveUser(UserModel userModel)
        {
            // guard clause - invalid input
            if (userModel == null)
            {
                return;
            }

            UserService.RemoveUser(userModel.RecordId);
            Commit();
        }

        #endregion

        #region Helper Methods

        private UserModel CreateUserModel(IUser user)
        {
            UserModel userModel = new UserModel();
            userModel.CopyFrom(user);
            return userModel;
        }

        private IUser[] GetVisibleUsers()
        {
            if (User.IsAdmin())
            {
                IUser[] allUsers = UserService.GetUsers();
                return allUsers.Except(new IUser[1] { User }).ToArray();
            }
            else
            {
                return new IUser[1] { User };
            }
        }

        #endregion

    }
}
