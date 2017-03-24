using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ttu.Presentation;

namespace Ttu.PresentationTest.Presenter
{
    [TestClass]
    public class ManageOrganizationPresenterTest : AbstractPresentationTest
    {

        private ManageOrganizationPresenter Presenter;

        [TestInitialize]
        public void SetUp()
        {
            Presenter = PresenterFactory.CreateManageOrganizationPresenter();
        }

        #region Blue Sky Tests

        [TestMethod]
        public void TestBlueSky_MaintainOrganization()
        {
            // pre-conditions
            Assert.AreEqual(0, Presenter.GetOrganizations().Length);

            // exercise
            OrganizationModel organization1 = CreateOrganization("TestOrg1", 1);
            Presenter.AddOrganization(organization1);

            OrganizationModel organization2 = CreateOrganization("TestOrg2", 2);
            Presenter.AddOrganization(organization2);

            Presenter.RemoveOrganization(organization1);

            // post-conditions
            Assert.AreEqual(1, Presenter.GetOrganizations().Length);
            Assert.IsNull(Presenter.GetOrganization(organization1.RecordId));
            Assert.IsNotNull(Presenter.GetOrganization(organization2.RecordId));
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

        private OrganizationModel CreateOrganization(string name, int recordId)
        {
            OrganizationModel organization = new OrganizationModel();
            organization.Name = name;
            organization.RecordId = recordId;
            return organization;
        }

        #endregion

    }
}
