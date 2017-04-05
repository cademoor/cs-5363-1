using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ttu.Domain;
using Ttu.Service;

namespace Ttu.ServiceTest.service
{
    [TestClass]
    public class OrganizationUserServiceTest : AbstractServiceTest
    {

        private OrganizationUserService Service;

        [TestInitialize]
        public void SetUp()
        {
            Service = new OrganizationUserService(UnitOfWork);

            UnitOfWork.OrganizationUsers.RemoveAll(UnitOfWork.OrganizationUsers.FindAll());
            UnitOfWork.Commit();
            UnitOfWork.Abort();
        }

        #region Blue Sky Tests

        [TestMethod]
        public void TestBlueSky_MaintainOrganizationUsers()
        {
            // pre-conditions
            Assert.AreEqual(0, Service.GetOrganizationUsers().Length);

            // exercise
            IOrganizationUser contactHome = CreateOrganizationUser(1000, 1000);
            Service.AddOrganizationUser(contactHome);

            IOrganizationUser contactMobile = CreateOrganizationUser(1001, 1001);
            Service.AddOrganizationUser(contactMobile);

            UnitOfWork.Commit();
            UnitOfWork.Abort();

            

            Service.RemoveOrganizationUser(contactHome.OrganizationId, contactHome.UserId);

            UnitOfWork.Commit();
            UnitOfWork.Abort();

            // post-conditions
            Assert.AreEqual(1, Service.GetOrganizationUsers().Length);
            Assert.IsNotNull(Service.GetOrganizationUser(1001, 1001));
            Assert.IsNull(Service.GetOrganizationUser(contactHome.RecordId));
            Assert.IsNotNull(Service.GetOrganizationUser(contactMobile.RecordId));
        }

        #endregion

        [TestCleanup]
        public void TearDown()
        {
        }

        #region Helper Methods

        private IOrganizationUser CreateOrganizationUser(int organizationId, int userId)
        {
            return new OrganizationUser(organizationId, userId);
        }

        #endregion

    }
}
