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
            MockUnitOfWork.Organizations.Add(CreateOrganization(1, "Org1"));

            IRecommendation recommendation = CreateRecommendation(1, RecommendationType.OrganizationToUser, 1);
            string importText = string.Format("{0},{1},{2},{3}", recommendation.User.RecordId, recommendation.ReferenceId, recommendation.Rank, Environment.NewLine);
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
