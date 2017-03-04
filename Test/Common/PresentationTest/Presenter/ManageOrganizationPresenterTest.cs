using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ttu.Domain;
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
            Presenter.InitializeFeature();
        }

        #region Blue Sky Tests

        [TestMethod]
        public void TestBlueSky_MaintainOrganization()
        {
            // pre-conditions
            Assert.AreEqual(0, Presenter.GetOrganizations().Length);

            // exercise
            IOrganization user1 = CreateOrganization("TestOrg1", 1);
            Presenter.AddOrganization(user1);

            IOrganization user2 = CreateOrganization("TestOrg2", 2);
            Presenter.AddOrganization(user2);

            Presenter.RemoveOrganization(user1);

            // post-conditions
            Assert.AreEqual(1, Presenter.GetOrganizations().Length);
            Assert.IsNull(Presenter.GetOrganization(user1.RecordId));
            Assert.IsNotNull(Presenter.GetOrganization(user2.RecordId));
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

        private IOrganization CreateOrganization(string name, int recordId)
        {
            Organization user = new Organization(User, name);
            user.RecordId = recordId;
            return user;
        }

        #endregion

    }
}
