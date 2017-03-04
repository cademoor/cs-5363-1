using Ttu.Domain;

namespace Ttu.PresentationTest
{
    public class MockServiceFactory : IServiceFactory
    {

        #region Constructors

        public MockServiceFactory()
        {
            AuthenticationService = new MockAuthenticationService();
            ContactService = new MockContactService();
            UserService = new MockUserService();
            VolunteerProfileReviewService = new MockVolunteerProfileReviewService();
            VolunteerProfileService = new MockVolunteerProfileService();
        }

        #endregion

        #region Properties

        private MockAuthenticationService AuthenticationService { get; set; }
        private MockContactService ContactService { get; set; }
        private MockUserService UserService { get; set; }
        private MockVolunteerProfileReviewService VolunteerProfileReviewService { get; set; }
        private MockVolunteerProfileService VolunteerProfileService { get; set; }

        #endregion

        #region Public Methods

        public IAuthenticationService CreateAuthenticationService()
        {
            return AuthenticationService;
        }

        public IContactService CreateContactService(IUnitOfWork unitOfWork)
        {
            return ContactService;
        }

        public IUserService CreateUserService(IUnitOfWork unitOfWork)
        {
            return UserService;
        }

        public IVolunteerProfileReviewService CreateVolunteerProfileReviewService(IUnitOfWork unitOfWork)
        {
            return VolunteerProfileReviewService;
        }

        public IVolunteerProfileService CreateVolunteerProfileService(IUnitOfWork unitOfWork)
        {
            return VolunteerProfileService;

        }

        #endregion

    }
}
