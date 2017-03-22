using Ttu.Domain;

namespace Ttu.TestFramework
{
    public class MockServiceFactory : IServiceFactory
    {

        #region Constructors

        public MockServiceFactory()
        {
            AuthenticationService = new MockAuthenticationService();
            ContactService = new MockContactService();
            OrganizationService = new MockOrganizationService();
            RecommendationService = new MockRecommendationService();
            UserService = new MockUserService();
            VolunteerProfileReviewService = new MockVolunteerProfileReviewService();
            VolunteerProfileService = new MockVolunteerProfileService();
        }

        #endregion

        #region Properties

        private MockAuthenticationService AuthenticationService { get; set; }

        private MockContactService ContactService { get; set; }

        private MockOrganizationService OrganizationService { get; set; }

        private MockRecommendationService RecommendationService { get; set; }

        private MockUserService UserService { get; set; }

        private MockVolunteerProfileReviewService VolunteerProfileReviewService { get; set; }
        private MockVolunteerProfileService VolunteerProfileService { get; set; }

        #endregion

        #region Public Methods

        public IAuthenticationService CreateAuthenticationService()
        {
            AuthenticationService.MockUnitOfWork = null;
            return AuthenticationService;
        }

        public IContactService CreateContactService(IUnitOfWork unitOfWork)
        {
            ContactService.MockUnitOfWork = unitOfWork;
            return ContactService;
        }

        public IOrganizationService CreateOrganizationService(IUnitOfWork unitOfWork)
        {
            OrganizationService.MockUnitOfWork = unitOfWork;
            return OrganizationService;
        }

        public IRecommendationService CreateRecommendationService(IUnitOfWork unitOfWork)
        {
            RecommendationService.MockUnitOfWork = unitOfWork;
            return RecommendationService;
        }

        public IUserService CreateUserService(IUnitOfWork unitOfWork)
        {
            UserService.MockUnitOfWork = unitOfWork;
            return UserService;
        }

        public IVolunteerProfileReviewService CreateVolunteerProfileReviewService(IUnitOfWork unitOfWork)
        {
            VolunteerProfileReviewService.MockUnitOfWork = unitOfWork;
            return VolunteerProfileReviewService;
        }

        public IVolunteerProfileService CreateVolunteerProfileService(IUnitOfWork unitOfWork)
        {
            VolunteerProfileService.MockUnitOfWork = unitOfWork;
            return VolunteerProfileService;

        }

        #endregion

    }
}
