using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ttu.Domain;

namespace Tcp.DomainTest.map
{
    [TestClass]
    public class ThreadSafeMapTest
    {

        private IUser User1;
        private IUser User2;
        private IUser User3;
        private IUser User4;
        private IUser User5;

        private ThreadSafeMap<string, IUser> Map;

        [TestInitialize]
        public void SetUp()
        {
            Map = new ThreadSafeMap<string, IUser>();

            User1 = CreateUser("1");
            Map["1"] = User1;
            User2 = CreateUser("2");
            Map["2"] = User2;
            User3 = CreateUser("3");
            Map["3"] = User3;
            User4 = CreateUser("4");
            Map["4"] = User4;
            User5 = CreateUser("5");
            Map["5"] = User5;
        }

        #region Blue Sky Tests

        [TestMethod]
        public void TestBlueSky_Coverage()
        {
            // pre-conditions
            Assert.AreEqual(5, Map.Count);
            Assert.AreEqual(User1, Map["1"]);
            Assert.AreEqual(User2, Map["2"]);
            Assert.AreEqual(User3, Map["3"]);
            Assert.AreEqual(User4, Map["4"]);
            Assert.AreEqual(User5, Map["5"]);
            Assert.IsTrue(Map.ContainsKey("1"));

            // exercise
            Map.Remove("1");

            // mid-conditions
            Assert.AreEqual(4, Map.Count);
            Assert.IsNull(Map["1"]);
            Assert.AreEqual(User2, Map["2"]);
            Assert.AreEqual(User3, Map["3"]);
            Assert.AreEqual(User4, Map["4"]);
            Assert.AreEqual(User5, Map["5"]);
            Assert.IsFalse(Map.ContainsKey("1"));

            // exercise
            IUser[] users = Map.GetValues();

            // mid-conditions
            Assert.AreEqual(users.Length, Map.Count);
            Assert.AreEqual(users[0], Map[users[0].UserId]);
            Assert.AreEqual(users[1], Map[users[1].UserId]);
            Assert.AreEqual(users[2], Map[users[2].UserId]);
            Assert.AreEqual(users[3], Map[users[3].UserId]);

            // exercise
            Map.Clear();

            // post-conditions
            Assert.AreEqual(0, Map.Count);
        }

        #endregion

        [TestCleanup]
        public void TearDown()
        {
        }

        #region Helper Methods

        private IUser CreateUser(string userId)
        {
            IUser user = new User(userId);
            user.FirstName = string.Format("First {0}", userId);
            user.LastName = string.Format("Last {0}", userId);
            return user;
        }

        #endregion

    }
}
