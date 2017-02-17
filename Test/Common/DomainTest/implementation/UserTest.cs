using NUnit.Framework;
using Ttu.Domain;

namespace Ttu.DomainTest
{
    [TestFixture]
    public class UserTest
    {

        private User User;

        [SetUp]
        public void SetUp()
        {
            User = new User();
        }

        # region Blue Sky Tests

        [Test]
        public void TestBlueSky_Coverage()
        {
            // pre-conditions
            Assert.IsEmpty(User.FirstName);
            Assert.IsEmpty(User.LastName);
            Assert.IsEmpty(User.Password);
            Assert.AreEqual(0, User.RecordId);
            Assert.IsEmpty(User.UserId);
            Assert.IsTrue(User.IsValid());

            // exercise
            User.FirstName = "Harper";
            User.LastName = "Moorman";
            User.Password = "TestPassword";
            User.RecordId = 1;
            User.UserId = "A";

            // post-conditions
            Assert.AreEqual("Harper", User.FirstName);
            Assert.AreEqual("Moorman", User.LastName);
            Assert.AreEqual("TestPassword", User.Password);
            Assert.AreEqual(1, User.RecordId);
            Assert.AreEqual("A", User.UserId);
            Assert.IsTrue(User.IsValid());
        }

        [Test]
        public void TestBlueSky_GetFullName()
        {
            // pre-conditions
            Assert.IsEmpty(User.FirstName);
            Assert.IsEmpty(User.LastName);
            Assert.IsEmpty(User.GetFullName());

            // exercise
            User.FirstName = "Harper";
            User.LastName = "Moorman";

            // post-conditions
            Assert.AreEqual("Harper", User.FirstName);
            Assert.AreEqual("Moorman", User.LastName);
            Assert.AreEqual("Harper Moorman", User.GetFullName());
        }

        # endregion

        [TearDown]
        public void TearDown()
        {
        }

        # region Helper Methods

        private IContact CreateContact(ContactType contactType, string value, int recordId)
        {
            Contact contact = new Contact(User, contactType, value);
            contact.RecordId = recordId;
            return contact;
        }

        # endregion

    }
}
