using NUnit.Framework;
using Ttu.Domain;
using Ttu.Presentation;

namespace Ttu.PresentationTest
{
    [TestFixture]
    public class NullUserTest
    {

        private NullUser User;

        [SetUp]
        public void SetUp()
        {
            User = NullUser.Singleton as NullUser;
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
            Assert.IsFalse(User.IsValid());

            // exercise
            User.FirstName = "Harper";
            User.LastName = "Moorman";
            User.Password = "TestPassword";
            User.RecordId = 1;
            User.UserId = "A";

            // post-conditions
            Assert.IsEmpty(User.FirstName);
            Assert.IsEmpty(User.LastName);
            Assert.IsEmpty(User.Password);
            Assert.AreEqual(0, User.RecordId);
            Assert.IsEmpty(User.UserId);
            Assert.IsFalse(User.IsValid());
        }

        # endregion

        [TearDown]
        public void TearDown()
        {
        }

    }
}
