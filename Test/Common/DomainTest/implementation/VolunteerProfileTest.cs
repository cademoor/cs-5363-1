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

            VolunteerProfile = new VolunteerProfile(User, "Test Profile");
        }

        #region Blue Sky Tests

        [TestMethod]
        public void TestBlueSky_Coverage()
        {
            // pre-conditions
            Assert.AreEqual(string.Empty, VolunteerProfile.Description);
            Assert.AreEqual("Test Profile", VolunteerProfile.Name);
            Assert.AreEqual(0, VolunteerProfile.RecordId);

            // exercise
            VolunteerProfile.Name = "Name 1";
            VolunteerProfile.Description = "Desc 1";
            VolunteerProfile.RecordId = 1;

            // post-conditions
            Assert.AreEqual("Desc 1", VolunteerProfile.Description);
            Assert.AreEqual("Name 1", VolunteerProfile.Name);
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
