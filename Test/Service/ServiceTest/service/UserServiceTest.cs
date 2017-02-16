using NUnit.Framework;
using Ttu.Domain;
using Ttu.Service;

namespace Ttu.ServiceTest
{
    [TestFixture]
    public class UserServiceTest : AbstractServiceTest
    {

        private UserService Service;

        [SetUp]
        public void SetUp()
        {
            Service = new UserService(UnitOfWork);

            UnitOfWork.Users.RemoveAll(UnitOfWork.Users.FindBy(u => u.UserId != USER_ID));
            UnitOfWork.Commit();
            UnitOfWork.Abort();
        }

        # region Blue Sky Tests

        [Test]
        public void TestBlueSky_MaintainUsers()
        {
            // pre-conditions
            Assert.AreEqual(1, Service.GetUsers().Length); // an extra because the user that remains in the test environment

            // exercise
            IUser user1 = new User("TESTUSER1");
            Service.AddUser(user1);

            IUser user2 = new User("TESTUSER2");
            Service.AddUser(user2);

            Service.RemoveUser(user1);

            UnitOfWork.Commit();
            UnitOfWork.Abort();

            // post-conditions
            Assert.AreEqual(2, Service.GetUsers().Length); // an extra because the user that remains in the test environment
            Assert.IsNull(Service.GetUser(user1.RecordId));
            Assert.IsNotNull(Service.GetUser(user2.RecordId));
        }

        # endregion

        [TearDown]
        public void TearDown()
        {
        }

    }
}
