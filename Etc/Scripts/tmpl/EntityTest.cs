using NUnit.Framework;
using Ttu.Domain;

namespace Ttu.DomainTest.implementation
{
    [TestFixture]
    public class EntityTest
    {

        private Entity Entity;

        [SetUp]
        public void SetUp()
        {
            Entity = new Entity();
        }

        #region Blue Sky Tests

        [Test]
        public void TestBlueSky_Coverage()
        {
            // pre-conditions
            Assert.AreEqual(0, Entity.RecordId);

            // exercise
            Entity.RecordId = 1;

            // post-conditions
            Assert.AreEqual(1, Entity.RecordId);
        }

        #endregion

        [TearDown]
        public void TearDown()
        {
        }

    }
}
