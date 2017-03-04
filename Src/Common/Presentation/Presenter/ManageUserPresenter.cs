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

        public void AddUser(IUser user)
        {
            UserService.AddUser(user);
            Commit();
        }

        public void AddVolunteerProfile(IVolunteerProfile volunteerProfile)
        {
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

    }
}
