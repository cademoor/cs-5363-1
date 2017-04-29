using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ttu.Domain;
using Ttu.Presentation;

namespace Ttu.PresentationTest.Presenter
{
    [TestClass]
    public class ManageUserPresenterTest : AbstractPresentationTest
    {

        private ManageUserPresenter Presenter;

        [TestInitialize]
        public void SetUp()
        {
            Presenter = PresenterFactory.CreateManageUserPresenter();
            PresenterFactory.User.UserId = Constants.USER_ID_ADMIN;
        }

        #region Blue Sky Tests

        [TestMethod]
        public void TestBlueSky_GetUsers_Admin()
        {
            // set-up
            Presenter.AddUser(CreateUser("TESTUSER1", 1), new User());
            Presenter.AddUser(CreateUser("TESTUSER2", 2), new User());

            // exercise
            UserModel[] visibleUsers = Presenter.GetUsers();

            // post-conditions
            Assert.AreEqual(2, visibleUsers.Length);
            Assert.AreEqual("TESTUSER1", visibleUsers[0].UserId);
            Assert.AreEqual("TESTUSER2", visibleUsers[1].UserId);
        }

        [TestMethod]
        public void TestBlueSky_GetUsers_NonAdmin()
        {
            // set-up
            PresenterFactory.User.UserId = "CADE";
            Presenter.AddUser(CreateUser("TESTUSER1", 1), new User());
            Presenter.AddUser(CreateUser("TESTUSER2", 2), new User());

            // exercise
            UserModel[] visibleUsers = Presenter.GetUsers();

            // post-conditions
            Assert.AreEqual(1, visibleUsers.Length);
            Assert.AreEqual("CADE", visibleUsers[0].UserId);
        }

        [TestMethod]
        public void TestBlueSky_MaintainUser()
        {
            // pre-conditions
            Assert.AreEqual(0, Presenter.GetUsers().Length);

            // exercise
            UserModel user1 = CreateUser("TESTUSER1", 1);
            Presenter.AddUser(user1);

            UserModel user2 = CreateUser("TESTUSER2", 2);
            Presenter.AddUser(user2);

            Presenter.AddVolunteerProfile(CreateVolunteerProfile(user2, "Profile1"));

            Presenter.RemoveUser(user1);

            // post-conditions
            Assert.AreEqual(1, Presenter.GetUsers().Length);
            Assert.IsNull(Presenter.GetUser(user1.RecordId));
            Assert.IsNotNull(Presenter.GetUser(user2.RecordId));
        }

        #endregion

        [TestCleanup]
        public void TearDown()
        {
        }

        #region Helper Methods

        private UserModel CreateUser(string userId, int recordId)
        {
            User user = new User(userId);
            user.RecordId = recordId;

            UserModel userModel = new UserModel();
            userModel.CopyFrom(user);
            return userModel;
        }

        private IVolunteerProfile CreateVolunteerProfile(UserModel userModel, string name)
        {
            User user = new User(userModel.UserId);
            user.RecordId = userModel.RecordId;

            VolunteerProfile volunteerProfile = new VolunteerProfile(user, name);
            volunteerProfile.Description = "I really want to volunteer to help hungry children!";
            return volunteerProfile;
        }

        #endregion

    }
}
