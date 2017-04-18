using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ttu.Domain;
using Ttu.Service;

namespace Ttu.ServiceTest.service
{
    [TestClass]
    public class OrganizationUserServiceTest : AbstractServiceTest
    {

        private IOrganization Organization;
        private OrganizationService OrganizationService;
        private OrganizationUserService Service;

        [TestInitialize]
        public void SetUp()
        {
            OrganizationService = new OrganizationService(UnitOfWork);
            Service = new OrganizationUserService(UnitOfWork);

            Organization = CreateOrganization("Org1");
            OrganizationService.AddOrganization(Organization);

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
            IOrganizationUser organizationUser1 = CreateOrganizationUser();
            Service.AddOrganizationUser(organizationUser1);

            IOrganizationUser organizationUser2 = CreateOrganizationUser();
            Service.AddOrganizationUser(organizationUser2);

            UnitOfWork.Commit();
            UnitOfWork.Abort();

            Service.RemoveOrganizationUser(organizationUser1.RecordId);

            UnitOfWork.Commit();
            UnitOfWork.Abort();

            // post-conditions
            Assert.AreEqual(1, Service.GetOrganizationUsers().Length);
            Assert.IsNull(Service.GetOrganizationUser(organizationUser1.RecordId));
            Assert.IsNotNull(Service.GetOrganizationUser(organizationUser2.RecordId));
        }

        #endregion

        [TestCleanup]
        public void TearDown()
        {
        }

        #region Helper Methods

        private IOrganization CreateOrganization(string name)
        {
            return new Organization(User, name);
        }

        private IOrganizationUser CreateOrganizationUser()
        {
            return new OrganizationUser(Organization, User);
        }

        #endregion

    }
}
