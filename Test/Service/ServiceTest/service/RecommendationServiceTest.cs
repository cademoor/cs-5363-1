using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ttu.Domain;
using Ttu.Service;

namespace Ttu.ServiceTest.service
{
    [TestClass]
    public class RecommendationServiceTest : AbstractServiceTest
    {

        private RecommendationService Service;

        [TestInitialize]
        public void SetUp()
        {
            Service = new RecommendationService(UnitOfWork);

            UnitOfWork.Recommendations.RemoveAll(UnitOfWork.Recommendations.FindAll());
            UnitOfWork.Commit();
            UnitOfWork.Abort();
        }

        #region Blue Sky Tests

        [TestMethod]
        public void TestBlueSky_MaintainRecommendations()
        {
            // pre-conditions
            Assert.AreEqual(0, Service.GetRecommendations().Length);

            // exercise
            IRecommendation recommendationHome = CreateRecommendation(RecommendationType.OrganizationToUser, "Organization1");
            Service.AddRecommendation(recommendationHome);

            IRecommendation recommendationMobile = CreateRecommendation(RecommendationType.OrganizationToUser, "Organization2");
            Service.AddRecommendation(recommendationMobile);

            UnitOfWork.Commit();
            UnitOfWork.Abort();

            Service.RemoveRecommendation(recommendationHome);

            UnitOfWork.Commit();
            UnitOfWork.Abort();

            // post-conditions
            Assert.AreEqual(1, Service.GetRecommendations().Length);
            Assert.IsNull(Service.GetRecommendation(recommendationHome.RecordId));
            Assert.IsNotNull(Service.GetRecommendation(recommendationMobile.RecordId));
        }

        #endregion

        [TestCleanup]
        public void TearDown()
        {
        }

        #region Helper Methods

        private IRecommendation CreateRecommendation(RecommendationType recommendationType, string value)
        {
            Recommendation recommendation = new Recommendation();
            recommendation.Type = recommendationType;
            recommendation.User = User;
            recommendation.Value = value;
            return recommendation;
        }

        #endregion

    }
}
