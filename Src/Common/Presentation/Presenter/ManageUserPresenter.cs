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
            ValidateUser(userModel);

            IUser user = new User(userModel.UserId);
            userModel.ApplyTo(user);

            UserService.AddUser(user);
            Commit();
        }

        public void AddVolunteerProfile(IVolunteerProfile volunteerProfile)
        {
            ValidateVolunteerProfile(volunteerProfile);

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
            return UserService.GetUsers().Select(u => CreateUserModel(u)).ToArray();
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

        private void ValidateInput(UserModel userModel)
        {
            if (userModel != null)
            {
                return;
            }

            throw new System.Exception("Invalid input");
        }

        private void ValidateUser(UserModel userModel)
        {
            ValidateInput(userModel);
            ValidateUserId(userModel.UserId);
        }

        private void ValidateUserId(string userId)
        {
            ValidateValue("User ID", userId, Constants.USER_ID_MIN_LENGTH, Constants.USER_ID_MAX_LENGTH, InputType.AlphaNumericWithSymbols);
        }

        private void ValidateVolunteerProfile(IVolunteerProfile volunteerProfile)
        {
            ValidateVolunteerProfileDescription(volunteerProfile.Description);
            ValidateVolunteerProfileName(volunteerProfile.Name);
        }

        private void ValidateVolunteerProfileDescription(string description)
        {
            ValidateValue("Description", description, Constants.VOLUNTEER_PROFILE_DESCRIPTION_MIN_LENGTH, Constants.VOLUNTEER_PROFILE_DESCRIPTION_MAX_LENGTH, InputType.AlphaNumericWithSymbols);
        }

        private void ValidateVolunteerProfileName(string name)
        {
            ValidateValue("Name", name, Constants.VOLUNTEER_PROFILE_NAME_MIN_LENGTH, Constants.VOLUNTEER_PROFILE_NAME_MAX_LENGTH, InputType.AlphaNumericWithoutDecimal);
        }

        #endregion

    }
}
