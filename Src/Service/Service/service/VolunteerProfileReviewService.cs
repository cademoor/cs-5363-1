using Ttu.Domain;

namespace Ttu.Service
{
    public class VolunteerProfileReviewService : AbstractService, IVolunteerProfileReviewService
    {

        #region Constructors

        public VolunteerProfileReviewService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region Public Methods

        public virtual void AddVolunteerProfileReview(IVolunteerProfileReview volunteerProfileReview)
        {
            UnitOfWork.VolunteerProfileReviews.Add(volunteerProfileReview);
        }

        public virtual IVolunteerProfileReview GetVolunteerProfileReview(int recordId)
        {
            return UnitOfWork.VolunteerProfileReviews.FindByRecordId(recordId);
        }

        public virtual IVolunteerProfileReview[] GetVolunteerProfileReviews(IUser user)
        {
            return UnitOfWork.VolunteerProfileReviews.FindAll();
        }

        public virtual void RemoveVolunteerProfileReview(int recordId)
        {
            // guard clause - not found
            IVolunteerProfileReview volunteerProfileReview = GetVolunteerProfileReview(recordId);
            if (volunteerProfileReview == null)
            {
                return;
            }

            UnitOfWork.VolunteerProfileReviews.Remove(volunteerProfileReview);
        }

        public virtual void RemoveVolunteerProfileReview(IVolunteerProfileReview volunteerProfileReview)
        {
            // guard clause - invalid input
            if (volunteerProfileReview == null)
            {
                return;
            }

            RemoveVolunteerProfileReview(volunteerProfileReview.RecordId);
        }

        #endregion

    }
}
