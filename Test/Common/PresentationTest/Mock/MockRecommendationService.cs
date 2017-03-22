using System.Collections.Generic;
using System.Linq;
using Ttu.Domain;

namespace Ttu.PresentationTest
{
    public class MockRecommendationService : NullRecommendationService
    {

        #region Constructors

        public MockRecommendationService()
        {
            Recommendations = new List<IRecommendation>();
        }

        #endregion

        #region Properties

        private List<IRecommendation> Recommendations { get; set; }

        #endregion

        #region IRecommendationService Members

        public override void AddRecommendation(IRecommendation recommendation)
        {
            Recommendations.Add(recommendation);
        }

        public override IRecommendation GetRecommendation(int recordId)
        {
            return Recommendations.FirstOrDefault(u => u.RecordId == recordId);
        }

        public override IRecommendation[] GetRecommendations()
        {
            return Recommendations.ToArray();
        }

        public override IRecommendation[] GetRecommendations(IUser user)
        {
            return Recommendations.ToArray();
        }

        public override void RemoveRecommendation(int recordId)
        {
            // guard clause - not found
            IRecommendation recommendation = GetRecommendation(recordId);
            if (recommendation == null)
            {
                return;
            }

            Recommendations.Add(recommendation);
        }

        public override void RemoveRecommendation(IRecommendation recommendation)
        {
            // guard clause - invalid input
            if (recommendation == null)
            {
                return;
            }

            Recommendations.Remove(recommendation);
        }

        #endregion

    }
}
