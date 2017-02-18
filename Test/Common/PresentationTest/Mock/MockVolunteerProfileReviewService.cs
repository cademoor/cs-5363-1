using System.Collections.Generic;
using System.Linq;
using Ttu.Domain;

namespace Ttu.PresentationTest
{
    public class MockVolunteerProfileReviewService : NullVolunteerProfileReviewService
    {

        #region Constructors

        public MockVolunteerProfileReviewService()
        {
            VolunteerProfileReviews = new List<IVolunteerProfileReview>();
        }

        #endregion

        #region Properties

        private List<IVolunteerProfileReview> VolunteerProfileReviews { get; set; }

        #endregion

        #region IVolunteerProfileReviewService Members

        public override void AddVolunteerProfileReview(IVolunteerProfileReview user)
        {
            VolunteerProfileReviews.Add(user);
        }

        public override IVolunteerProfileReview GetVolunteerProfileReview(int recordId)
        {
            return VolunteerProfileReviews.FirstOrDefault(u => u.RecordId == recordId);
        }

        public override IVolunteerProfileReview[] GetVolunteerProfileReviews(IUser user)
        {
            return VolunteerProfileReviews.ToArray();
        }

        public override void RemoveVolunteerProfileReview(int recordId)
        {
            // guard clause - not found
            IVolunteerProfileReview user = GetVolunteerProfileReview(recordId);
            if (user == null)
            {
                return;
            }

            VolunteerProfileReviews.Add(user);
        }

        public override void RemoveVolunteerProfileReview(IVolunteerProfileReview user)
        {
            // guard clause - invalid input
            if (user == null)
            {
                return;
            }

            VolunteerProfileReviews.Remove(user);
        }

        #endregion

    }
}
