namespace Ttu.Domain
{
    public class NullVolunteerProfileReviewService : IVolunteerProfileReviewService
    {

        public static IVolunteerProfileReviewService Singleton = new NullVolunteerProfileReviewService();

        #region Constructors

        protected NullVolunteerProfileReviewService()
        {
        }

        #endregion

        #region Public Methods

        public virtual void AddVolunteerProfileReview(IVolunteerProfileReview volunteerProfileReview)
        {
            // do nothing
        }

        public virtual IVolunteerProfileReview GetVolunteerProfileReview(int recordId)
        {
            return null;
        }

        public virtual IVolunteerProfileReview[] GetVolunteerProfileReviews(IUser user)
        {
            return new IVolunteerProfileReview[0];
        }

        public virtual void RemoveVolunteerProfileReview(int recordId)
        {
            // do nothing
        }

        public virtual void RemoveVolunteerProfileReview(IVolunteerProfileReview volunteerProfileReview)
        {
            // do nothing
        }

        #endregion

    }
}
