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
        }

        public IVolunteerProfile GetVolunteerProfile(IUser user)
        {
            return VolunteerProfileService.GetVolunteerProfile(user);
        }

        public IUser[] GetUsers()
        {
            return UserService.GetUsers();
        }

        public void RemoveUser(IUser user)
        {
            UserService.RemoveUser(user);
        }

        #endregion

    }
}
