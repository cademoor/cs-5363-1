using Ttu.Domain;

namespace Ttu.Service
{
    public class ServiceFactory : IServiceFactory
    {

        #region Public Methods

        public IAuthenticationService CreateAuthenticationService()
        {
            return new AuthenticationService();
        }

        public IContactService CreateContactService(IUnitOfWork unitOfWork)
        {
            return new ContactService(unitOfWork);
        }

        public IOrganizationService CreateOrganizationService(IUnitOfWork unitOfWork)
        {
            return new OrganizationService(unitOfWork);
        }

        public IOrganizationUserService CreateOrganizationUserService(IUnitOfWork unitOfWork)
        {
            return new OrganizationUserService(unitOfWork);
        }


        public IRecommendationService CreateRecommendationService(IUnitOfWork unitOfWork)
        {
            return new RecommendationService(unitOfWork);
        }

        public IUserService CreateUserService(IUnitOfWork unitOfWork)
        {
            return new UserService(unitOfWork);
        }

        public IVolunteerProfileReviewService CreateVolunteerProfileReviewService(IUnitOfWork unitOfWork)
        {
            return new VolunteerProfileReviewService(unitOfWork);
        }

        public IVolunteerProfileService CreateVolunteerProfileService(IUnitOfWork unitOfWork)
        {
            return new VolunteerProfileService(unitOfWork);
        }

        #endregion

    }
}
