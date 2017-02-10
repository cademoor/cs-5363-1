using NUnit.Framework;
using Ttu.Domain;

namespace Ttu.DomainTest
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

        [Test]
        public void TestBlueSky_Coverage()
        {
            // pre-conditions
            Assert.AreEqual(0, Entity.RecordId);
            Assert.IsEmpty(Entity.Property1);
            Assert.IsEmpty(Entity.Property2);
            Assert.IsEmpty(Entity.Property3);

            // exercise
            Entity.RecordId = 1;
            Entity.Property1 = "A";
            Entity.Property2 = "B";
            Entity.Property3 = "C";

            // post-conditions
            Assert.AreEqual("A", Entity.Property1);
            Assert.AreEqual("B", Entity.Property2);
            Assert.AreEqual("C", Entity.Property3);
        }

        [TearDown]
        public void TearDown()
        {
        }

    }
}
