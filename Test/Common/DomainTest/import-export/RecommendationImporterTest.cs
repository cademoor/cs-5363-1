using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Ttu.Domain;
using Ttu.TestFramework;

namespace Ttu.DomainTest.implementation
{
    [TestClass]
    public class RecommendationImportTest
    {

        private MockUnitOfWork MockUnitOfWork;
        private RecommendationImporter Importer;
        private IServiceFactory ServiceFactory;
        private string FilePath;

        [TestInitialize]
        public void SetUp()
        {
            MockUnitOfWork = new MockUnitOfWork();
            ServiceFactory = new MockServiceFactory();

            FilePath = Path.GetTempFileName();
            Importer = new RecommendationImporter(ServiceFactory, MockUnitOfWork, FilePath);
        }

        #region Blue Sky Tests

        [TestMethod]
        public void TestBlueSky_Import()
        {
            // set-up
            IRecommendation recommendation = CreateRecommendation(1, RecommendationType.OrganizationToUser, "Org1");
            string importText = string.Format("{0},{1},{2},{3},{4}{5}", recommendation.RecordId, recommendation.User.RecordId, recommendation.Rating, recommendation.Value, (int)recommendation.Type, Environment.NewLine);
            File.WriteAllText(FilePath, importText);

            // pre-conditions
            Assert.AreEqual(importText, File.ReadAllText(FilePath));
            Assert.AreEqual(0, MockUnitOfWork.Recommendations.FindAll().Length);

            // exercise
            Importer.Import();

            // post-conditions
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
