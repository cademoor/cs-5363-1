using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ttu.Presentation;

namespace Ttu.PresentationTest.Null
{
    [TestClass]
    public class NullUserTest
    {

        private NullUser User;

        [TestInitialize]
        public void SetUp()
        {
            User = NullUser.Singleton as NullUser;
        }

        #region Blue Sky Tests

        [TestMethod]
        public void TestBlueSky_Coverage()
        {
            // pre-conditions
            Assert.AreEqual(string.Empty, User.FirstName);
            Assert.AreEqual(string.Empty, User.LastName);
            Assert.AreEqual(string.Empty, User.PasswordEncrypted);
            Assert.AreEqual(0, User.RecordId);
            Assert.AreEqual(string.Empty, User.UserId);
            Assert.IsFalse(User.IsValid());

            // exercise
            User.FirstName = "Harper";
            User.LastName = "Moorman";
            User.PasswordEncrypted = "TestPassword";
            User.RecordId = 1;
            User.UserId = "A";

            // post-conditions
            Assert.AreEqual(string.Empty, User.FirstName);
            Assert.AreEqual(string.Empty, User.LastName);
            Assert.AreEqual(string.Empty, User.PasswordEncrypted);
            Assert.AreEqual(0, User.RecordId);
            Assert.AreEqual(string.Empty, User.UserId);
            Assert.IsFalse(User.IsValid());
        }

        #endregion

        [TestCleanup]
        public void TearDown()
        {
        }

    }
}
