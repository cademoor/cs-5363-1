using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ttu.Domain;

namespace Ttu.DomainTest.implementation
{
    [TestClass]
    public class VolunteerProfileTest
    {

        private IUser User;
        private VolunteerProfile VolunteerProfile;

        [TestInitialize]
        public void SetUp()
        {
            User = new User();

            VolunteerProfile = new VolunteerProfile(User);
        }

        #region Blue Sky Tests

        [TestMethod]
        public void TestBlueSky_Coverage()
        {
            // pre-conditions
            Assert.AreEqual(0, VolunteerProfile.RecordId);

            // exercise
            VolunteerProfile.RecordId = 1;

            // post-conditions
            Assert.AreEqual(1, VolunteerProfile.RecordId);
        }

        #endregion

        #region Non Blue Sky Tests

        [TestMethod]
        public void TestNonBlueSky_()
        {

        }

        #endregion

        [TestCleanup]
        public void TearDown()
        {
        }

        #region Helper Methods



        #endregion

    }
}
