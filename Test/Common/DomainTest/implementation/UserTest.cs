using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ttu.Domain;

namespace Ttu.DomainTest.implementation
{
    [TestClass]
    public class UserTest
    {

        private User User;

        [TestInitialize]
        public void SetUp()
        {
            User = new User();
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
            Assert.IsTrue(User.IsValid());

            // exercise
            User.FirstName = "Harper";
            User.LastName = "Moorman";
            User.PasswordEncrypted = "TestPassword";
            User.RecordId = 1;
            User.UserId = "A";

            // post-conditions
            Assert.AreEqual("Harper", User.FirstName);
            Assert.AreEqual("Moorman", User.LastName);
            Assert.AreEqual("TestPassword", User.PasswordEncrypted);
            Assert.AreEqual(1, User.RecordId);
            Assert.AreEqual("A", User.UserId);
            Assert.IsTrue(User.IsValid());
        }

        [TestMethod]
        public void TestBlueSky_GetFullName()
        {
            // pre-conditions
            Assert.AreEqual(string.Empty, User.FirstName);
            Assert.AreEqual(string.Empty, User.LastName);
            Assert.AreEqual(string.Empty, User.GetFullName());

            // exercise
            User.FirstName = "Harper";
            User.LastName = "Moorman";

            // post-conditions
            Assert.AreEqual("Harper", User.FirstName);
            Assert.AreEqual("Moorman", User.LastName);
            Assert.AreEqual("Harper Moorman", User.GetFullName());
        }

        #endregion

        [TestCleanup]
        public void TearDown()
        {
        }

        #region Helper Methods

        private IContact CreateContact(ContactType contactType, string value, int recordId)
        {
            Contact contact = new Contact(User, contactType, value);
            contact.RecordId = recordId;
            return contact;
        }

        #endregion

    }
}
