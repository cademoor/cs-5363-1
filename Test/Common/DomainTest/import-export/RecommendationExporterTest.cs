using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Ttu.Domain;
using Ttu.TestFramework;

namespace Ttu.DomainTest.implementation
{
    [TestClass]
    public class RecommendationExportTest
    {

        private MockUnitOfWork MockUnitOfWork;
        private RecommendationExporter Exporter;
        private IServiceFactory ServiceFactory;
        private string FilePath;

        [TestInitialize]
        public void SetUp()
        {
            MockUnitOfWork = new MockUnitOfWork();
            ServiceFactory = new MockServiceFactory();

            FilePath = Path.GetTempFileName();
            Exporter = new RecommendationExporter(ServiceFactory, MockUnitOfWork, FilePath);
        }

        #region Blue Sky Tests

        [TestMethod]
        public void TestBlueSky_Export()
        {
            // pre-conditions
            Assert.AreEqual(string.Empty, File.ReadAllText(FilePath));
            Assert.AreEqual(0, MockUnitOfWork.Recommendations.FindAll().Length);

            // exercise
            IRecommendation recommendation = CreateRecommendation(1, RecommendationType.OrganizationToUser, "Org1");
            MockUnitOfWork.Recommendations.Add(recommendation);
            Exporter.Export();

            // post-conditions
            string expectedOutput = string.Format("{0},{1},{2}{3}", recommendation.RecordId, recommendation.User.RecordId, recommendation.Rating, Environment.NewLine);
            Assert.AreEqual(expectedOutput, File.ReadAllText(FilePath));
            Assert.AreEqual(1, MockUnitOfWork.Recommendations.FindAll().Length);
        }

        #endregion

        [TestCleanup]
        public void TearDown()
        {
        }

        #region Helper Methods

        private IRecommendation CreateRecommendation(int recordId, RecommendationType recommendationType, string value)
        {
            Recommendation recommendation = new Recommendation();
            recommendation.Rating = 7;
            recommendation.RecordId = recordId;
            recommendation.Type = recommendationType;
            recommendation.User = new User("USER1") { RecordId = 2 };
            recommendation.Value = value;
            return recommendation;
        }

        #endregion

    }
}
