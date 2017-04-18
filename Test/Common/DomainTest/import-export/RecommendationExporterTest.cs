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
            // set-up
            MockUnitOfWork.Organizations.Add(CreateOrganization(1, "Org1"));

            // pre-conditions
            Assert.AreEqual(string.Empty, File.ReadAllText(FilePath));
            Assert.AreEqual(0, MockUnitOfWork.Recommendations.FindAll().Length);

            // exercise
            IRecommendation recommendation = CreateRecommendation(1, RecommendationType.OrganizationToUser, 1);
            MockUnitOfWork.Recommendations.Add(recommendation);
            Exporter.Export();

            // post-conditions
            string expectedOutput = string.Format("{0},{1}{2}", recommendation.User.RecordId, recommendation.ReferenceId, Environment.NewLine);
            Assert.AreEqual(expectedOutput, File.ReadAllText(FilePath));
            Assert.AreEqual(1, MockUnitOfWork.Recommendations.FindAll().Length);
        }

        #endregion

        [TestCleanup]
        public void TearDown()
        {
        }

        #region Helper Methods

        private IOrganization CreateOrganization(int recordId, string name)
        {
            Organization organization = new Organization();
            organization.Name = name;
            organization.RecordId = recordId;
            return organization;
        }

        private IRecommendation CreateRecommendation(int recordId, RecommendationType recommendationType, int referenceId)
        {
            Recommendation recommendation = new Recommendation();
            recommendation.Rank = 0.7;
            recommendation.RecordId = recordId;
            recommendation.ReferenceId = referenceId;
            recommendation.Type = recommendationType;
            recommendation.User = new User("USER1") { RecordId = 2 };
            return recommendation;
        }

        #endregion

    }
}
