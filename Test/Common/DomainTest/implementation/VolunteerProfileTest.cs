using NUnit.Framework;
using Ttu.Domain;

namespace Ttu.DomainTest.implementation
{
    [TestFixture]
    public class VolunteerProfileTest
    {

        private IUser User;
        private VolunteerProfile VolunteerProfile;

        [SetUp]
        public void SetUp()
        {
            User = new User();

            VolunteerProfile = new VolunteerProfile(User);
        }

        #region Blue Sky Tests

        [Test]
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

        [Test]
        public void TestNonBlueSky_()
        {

        }

        #endregion

        [TearDown]
        public void TearDown()
        {
        }

        #region Helper Methods



        #endregion

    }
}
