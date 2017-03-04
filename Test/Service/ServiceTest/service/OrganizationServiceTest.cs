using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ttu.Domain;
using Ttu.Service;

namespace Ttu.ServiceTest.service
{
    [TestClass]
    public class OrganizationServiceTest : AbstractServiceTest
    {

        private OrganizationService Service;

        [TestInitialize]
        public void SetUp()
        {
            Service = new OrganizationService(UnitOfWork);

            UnitOfWork.Organizations.RemoveAll(UnitOfWork.Organizations.FindAll());
            UnitOfWork.Commit();
            UnitOfWork.Abort();
        }

        #region Blue Sky Tests

        [TestMethod]
        public void TestBlueSky_MaintainOrganizations()
        {
            // pre-conditions
            Assert.AreEqual(0, Service.GetOrganizations().Length);

            // exercise
            IOrganization contactHome = CreateOrganization("1112223333");
            Service.AddOrganization(contactHome);

            IOrganization contactMobile = CreateOrganization("4445556666");
            Service.AddOrganization(contactMobile);

            UnitOfWork.Commit();
            UnitOfWork.Abort();

            Service.RemoveOrganization(contactHome);

            UnitOfWork.Commit();
            UnitOfWork.Abort();

            // post-conditions
            Assert.AreEqual(1, Service.GetOrganizations().Length);
            Assert.IsNull(Service.GetOrganization(contactHome.RecordId));
            Assert.IsNotNull(Service.GetOrganization(contactMobile.RecordId));
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

        #endregion

    }
}
