using System.Linq;
using Ttu.Domain;

namespace Ttu.Service
{
    public class UserService : AbstractService, IUserService
    {

        #region Constructors

        public UserService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region Public Methods

        public void AddUser(IUser user)
        {
            UnitOfWork.Users.Add(user);
        }

        public IUser GetUser(string userId)
        {
            return UnitOfWork.Users.FindByUnique(u => u.UserId == userId);
        }

        public IUser GetUser(int recordId)
        {
            return UnitOfWork.Users.FindByRecordId(recordId);
        }

        public IUser[] GetUsers()
        {
            return UnitOfWork.Users.FindAll();
        }

        public void RemoveUser(int recordId)
        {
            // guard clause - not found
            IUser user = GetUser(recordId);
            if (user == null)
            {
                return;
            }

            //RemoveVolunteerProfiles(user);
            //RemoveVolunteerProfileReviews(user);

            UnitOfWork.OrganizationUsers.RemoveAll(UnitOfWork.OrganizationUsers.FindBy(ou => ou.User == user));
            Organization[] organizations = UnitOfWork.Organizations.FindBy(ou => ou.CreatedBy == user).Select(o => o as Organization).ToArray();
            organizations.ToList().ForEach(o => o.CreatedBy = null);

            UnitOfWork.Users.Remove(user);
        }

        private void RemoveVolunteerProfile(IVolunteerProfileService volunteerProfileService, IVolunteerProfile volunteerProfile)
        {
            volunteerProfileService.RemoveVolunteerProfile(volunteerProfile);
        }

        private void RemoveVolunteerProfiles(IUser user)
        {
            IVolunteerProfileService volunteerProfileService = new VolunteerProfileService(UnitOfWork);
            RemoveVolunteerProfile(volunteerProfileService, volunteerProfileService.GetVolunteerProfile(user));
        }

        private void RemoveVolunteerProfileReview(IVolunteerProfileReviewService volunteerProfileReviewService, IVolunteerProfileReview volunteerProfileReview)
        {
            volunteerProfileReviewService.RemoveVolunteerProfileReview(volunteerProfileReview);
        }

        private void RemoveVolunteerProfileReviews(IUser user)
        {
            IVolunteerProfileReviewService volunteerProfileReviewService = new VolunteerProfileReviewService(UnitOfWork);
            IVolunteerProfileReview[] volunteerProfileReviews = volunteerProfileReviewService.GetVolunteerProfileReviews(user);
            volunteerProfileReviews.ToList().ForEach(vpr => RemoveVolunteerProfileReview(volunteerProfileReviewService, vpr));
        }

        public void RemoveUser(IUser user)
        {
            // guard clause - invalid input
            if (user == null)
            {
                return;
            }

            RemoveUser(user.RecordId);
        }

        #endregion

    }
}
