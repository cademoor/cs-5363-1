using NUnit.Framework;
using Ttu.Domain;
using Ttu.Presentation;

namespace Ttu.PresentationTest
{
    [TestFixture]
    public class NullUserTest
    {

        private IUser User;

        [SetUp]
        public void SetUp()
        {
            User = NullUser.Singleton;
        }

        # region Blue Sky Tests

        [Test]
        public void TestBlueSky_Coverage()
        {
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
