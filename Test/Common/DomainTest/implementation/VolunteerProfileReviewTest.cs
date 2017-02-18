using NUnit.Framework;
using Ttu.Domain;

namespace Ttu.DomainTest.implementation
{
    [TestFixture]
    public class VolunteerProfileReviewTest
    {

        private VolunteerProfileReview VolunteerProfileReview;

        [SetUp]
        public void SetUp()
        {
            VolunteerProfileReview = new VolunteerProfileReview();
        }

        #region Blue Sky Tests

        [Test]
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

        [TearDown]
        public void TearDown()
        {
        }

    }
}
