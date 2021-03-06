﻿namespace Ttu.Domain
{
    public class NullServiceFactory : IServiceFactory
    {

        public static IServiceFactory Singleton = new NullServiceFactory();

        #region Constructors

        private NullServiceFactory()
        {
        }

        #endregion

        #region Public Methods

        public virtual IAuthenticationService CreateAuthenticationService()
        {
            return NullAuthenticationService.Singleton;
        }

        public virtual IContactService CreateContactService(IUnitOfWork unitOfWork)
        {
            return NullContactService.Singleton;
        }

        public virtual IOrganizationService CreateOrganizationService(IUnitOfWork unitOfWork)
        {
            return NullOrganizationService.Singleton;
        }


        public virtual IOrganizationUserService CreateOrganizationUserService(IUnitOfWork unitOfWork)
        {
            return NullOrganizationUserService.Singleton;
        }

        public virtual IRecommendationService CreateRecommendationService(IUnitOfWork unitOfWork)
        {
            return NullRecommendationService.Singleton;
        }

        public virtual IUserService CreateUserService(IUnitOfWork unitOfWork)
        {
            return NullUserService.Singleton;
        }

        public virtual IVolunteerProfileReviewService CreateVolunteerProfileReviewService(IUnitOfWork unitOfWork)
        {
            return NullVolunteerProfileReviewService.Singleton;
        }

        public virtual IVolunteerProfileService CreateVolunteerProfileService(IUnitOfWork unitOfWork)
        {
            return NullVolunteerProfileService.Singleton;
        }

        public IProjectService CreateProjectService(IUnitOfWork unitOfWork)
        {
            return NullProjectService.Singleton;
        }

        #endregion

    }
}
