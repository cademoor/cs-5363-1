namespace Ttu.Domain
{
    public interface IVolunteerProfileReviewService
    {

        void AddVolunteerProfileReview(IVolunteerProfileReview volunteerProfileReview);

        IVolunteerProfileReview GetVolunteerProfileReview(int recordId);
        IVolunteerProfileReview[] GetVolunteerProfileReviews(IUser user);

        void RemoveVolunteerProfileReview(int recordId);

        void RemoveVolunteerProfileReview(IVolunteerProfileReview volunteerProfileReview);

    }
}
