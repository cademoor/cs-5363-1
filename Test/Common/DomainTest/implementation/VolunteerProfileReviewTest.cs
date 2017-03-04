using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ttu.Domain;

namespace Ttu.DomainTest.implementation
{
    [TestClass]
    public class VolunteerProfileReviewTest
    {

        private VolunteerProfileReview VolunteerProfileReview;

        [TestInitialize]
        public void SetUp()
        {
            VolunteerProfileReview = new VolunteerProfileReview();
        }

        #region Blue Sky Tests

        [TestMethod]
        public void TestBlueSky_Coverage()
        {
            // pre-conditions
            Assert.AreEqual(0, VolunteerProfileReview.RecordId);

            // exercise
            VolunteerProfileReview.RecordId = 1;

            // post-conditions
            Assert.AreEqual(1, VolunteerProfileReview.RecordId);
        }

        #endregion

        [TestCleanup]
        public void TearDown()
        {
        }

    }
}
