using Ttu.Domain;

namespace Ttu.TestFramework
{
    public class MockRecommendationService : NullRecommendationService
    {

        #region Constructors

        public MockRecommendationService()
        {
            MockUnitOfWork = new MockUnitOfWork();
        }

        #endregion

        #region Properties

        public IUnitOfWork MockUnitOfWork { get; set; }

        #endregion

        #region IRecommendationService Members

        public override void AddRecommendation(IRecommendation recommendation)
        {
            MockUnitOfWork.Recommendations.Add(recommendation);
        }

        public override IRecommendation GetRecommendation(int recordId)
        {
            return MockUnitOfWork.Recommendations.FindByUnique(u => u.RecordId == recordId);
        }

        public override IRecommendation[] GetRecommendations()
        {
            return MockUnitOfWork.Recommendations.FindAll();
        }

        public override IRecommendation[] GetRecommendations(IUser user)
        {
            return MockUnitOfWork.Recommendations.FindBy(r => r.User == user);
        }

        public override void RemoveRecommendation(int recordId)
        {
            // guard clause - not found
            IRecommendation recommendation = GetRecommendation(recordId);
            if (recommendation == null)
            {
                return;
            }

            MockUnitOfWork.Recommendations.Add(recommendation);
        }

        public override void RemoveRecommendation(IRecommendation recommendation)
        {
            // guard clause - invalid input
            if (recommendation == null)
            {
                return;
            }

            MockUnitOfWork.Recommendations.Remove(recommendation);
        }

        #endregion

    }
}
