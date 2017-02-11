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
            Assert.AreEqual(0, User.RecordId);
            Assert.IsEmpty(User.UserId);
            Assert.IsTrue(User.IsValid());

            // exercise
            User.RecordId = 1;
            User.UserId = "A";

            // post-conditions
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

    }
}
