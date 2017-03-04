using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ttu.Domain;
using Ttu.Service;

namespace Ttu.ServiceTest.service
{
    [TestClass]
    public class VolunteerProfileReviewServiceTest : AbstractServiceTest
    {

        private VolunteerProfileReviewService Service;

        [TestInitialize]
        public void SetUp()
        {
            Service = new VolunteerProfileReviewService(UnitOfWork);

            UnitOfWork.VolunteerProfileReviews.RemoveAll(UnitOfWork.VolunteerProfileReviews.FindAll());
            UnitOfWork.Commit();
            UnitOfWork.Abort();
        }

        #region Blue Sky Tests

        [TestMethod]
        public void TestBlueSky_MaintainVolunteerProfileReviews()
        {
            // pre-conditions
            Assert.AreEqual(0, Service.GetVolunteerProfileReviews(User).Length);

            // exercise
            IVolunteerProfileReview volunteerProfile1 = CreateVolunteerProfileReview();
            Service.AddVolunteerProfileReview(volunteerProfile1);

            IVolunteerProfileReview volunteerProfile2 = CreateVolunteerProfileReview();
            Service.AddVolunteerProfileReview(volunteerProfile2);

            Service.RemoveVolunteerProfileReview(volunteerProfile1);

            UnitOfWork.Commit();
            UnitOfWork.Abort();

            // post-conditions
            Assert.AreEqual(1, Service.GetVolunteerProfileReviews(User).Length);
            Assert.IsNull(Service.GetVolunteerProfileReview(volunteerProfile1.RecordId));
            Assert.IsNotNull(Service.GetVolunteerProfileReview(volunteerProfile2.RecordId));
        }

        #endregion

        [TestCleanup]
        public void TearDown()
        {
        }

        #region Helper Methods

        private IVolunteerProfileReview CreateVolunteerProfileReview()
        {
            return new VolunteerProfileReview();
        }

        #endregion

    }
}
