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
            Presenter.InitializeFeature();
        }

        #region Blue Sky Tests

        //[TestMethod]
        //public void TestBlueSky_MaintainUser()
        //{
        //    // pre-conditions
        //    Assert.AreEqual(0, Presenter.GetUsers().Length);

        //    // exercise
        //    IUser user1 = CreateUser("TESTUSER1", 1);
        //    Presenter.AddUser(user1);

        //    IUser user2 = CreateUser("TESTUSER2", 2);
        //    Presenter.AddUser(user2);

        //    Presenter.AddVolunteerProfile(CreateVolunteerProfile(user2, "Profile1"));

        //    Presenter.RemoveUser(user1);

        //    // post-conditions
        //    Assert.AreEqual(1, Presenter.GetUsers().Length);
        //    Assert.IsNull(Presenter.GetUser(user1.RecordId));
        //    Assert.IsNotNull(Presenter.GetUser(user2.RecordId));
        //}

        #endregion

        #region Non Blue Sky Tests

        //[TestMethod]
        //public void TestNonBlueSky_UserId_TooLong()
        //{
        //    IUser invalidUser = CreateUser(new string('A', Constants.USER_ID_MAX_LENGTH + 1), 1);

        //    try
        //    {
        //        Presenter.AddUser(invalidUser);
        //        Assert.Fail("An exception should have been thrown.");
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.AreEqual("The \"User ID\" must be between 1 and 50 characters.", ex.Message);
        //    }
        //}

        #endregion

        [TestCleanup]
        public void TearDown()
        {
        }

        #region Helper Methods

        private IUser CreateUser(string userId, int recordId)
        {
            User user = new User(userId);
            user.RecordId = recordId;
            return user;
        }

        private IVolunteerProfile CreateVolunteerProfile(IUser user, string name)
        {
            VolunteerProfile volunteerProfile = new VolunteerProfile(user, name);
            volunteerProfile.Description = "I really want to volunteer to help hungry children!";
            return volunteerProfile;
        }

        #endregion

    }
}
