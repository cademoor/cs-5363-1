using NUnit.Framework;
using Ttu.Domain;
using Ttu.Service;

namespace Ttu.ServiceTest.service
{
    [TestFixture]
    public class VolunteerProfileServiceTest : AbstractServiceTest
    {

        private VolunteerProfileService Service;

        [SetUp]
        public void SetUp()
        {
            Service = new VolunteerProfileService(UnitOfWork);

            UnitOfWork.VolunteerProfiles.RemoveAll(UnitOfWork.VolunteerProfiles.FindAll());
            UnitOfWork.Commit();
            UnitOfWork.Abort();
        }

        #region Blue Sky Tests

        [Test]
        public void TestBlueSky_MaintainVolunteerProfiles()
        {
            // pre-conditions
            Assert.AreEqual(0, Service.GetVolunteerProfiles().Length);
            Assert.IsNull(Service.GetVolunteerProfile(User));

            // exercise
            IVolunteerProfile volunteerProfile1 = CreateVolunteerProfile();
            Service.AddVolunteerProfile(volunteerProfile1);

            IVolunteerProfile volunteerProfile2 = CreateVolunteerProfile();
            Service.AddVolunteerProfile(volunteerProfile2);

            Service.RemoveVolunteerProfile(volunteerProfile1);

            UnitOfWork.Commit();
            UnitOfWork.Abort();

            // post-conditions
            Assert.AreEqual(1, Service.GetVolunteerProfiles().Length);
            Assert.IsNull(Service.GetVolunteerProfile(volunteerProfile1.RecordId));
            Assert.IsNotNull(Service.GetVolunteerProfile(volunteerProfile2.RecordId));
            Assert.IsNotNull(Service.GetVolunteerProfile(User));
        }

        #endregion

        [TearDown]
        public void TearDown()
        {
        }

        #region Helper Methods

        private IVolunteerProfile CreateVolunteerProfile()
        {
            return new VolunteerProfile(User);
        }

        #endregion

    }
}
