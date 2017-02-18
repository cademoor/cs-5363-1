using System;
using Ttu.Domain;

namespace Ttu.PresentationTest
{
    public class MockServiceFactory : IServiceFactory
    {

        #region Constructors

        public MockServiceFactory()
        {
        }

        #endregion

        #region Properties



        #endregion

        #region Public Methods

        public IAuthenticationService CreateAuthenticationService()
        {
            return new MockAuthenticationService();
        }

        public IContactService CreateContactService(IUnitOfWork unitOfWork)
        {
            throw new NotImplementedException();
        }

        public IUserService CreateUserService(IUnitOfWork unitOfWork)
        {
            return new MockUserService();
        }

        public IVolunteerProfileReviewService CreateVolunteerProfileReviewService(IUnitOfWork unitOfWork)
        {
            throw new NotImplementedException();
        }

        public IVolunteerProfileService CreateVolunteerProfileService(IUnitOfWork unitOfWork)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Helper Methods



        #endregion

    }
}
