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
            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;

            UserService.AddUser(user);
            Commit();
        }

        public void AddVolunteerProfile(IVolunteerProfile volunteerProfile)
        {
            ValidateVolunteerProfile(volunteerProfile);

            VolunteerProfileService.AddVolunteerProfile(volunteerProfile);
            Commit();
        }

        public IUser GetUser(string userId)
        {
            return UserService.GetUser(userId);
        }

        public IUser GetUser(int recordId)
        {
            return UserService.GetUser(recordId);
        }

        public IUser[] GetUsers()
        {
            return UserService.GetUsers();
        }

        public IVolunteerProfile GetVolunteerProfile(IUser user)
        {
            return VolunteerProfileService.GetVolunteerProfile(user);
        }

        public void InitializeFeature()
        {
            Reset();
        }

        public void RemoveUser(IUser user)
        {
            UserService.RemoveUser(user);
            Commit();
        }

        #endregion

        #region Helper Methods

        private void ValidateUser(UserModel userModel)
        {
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
