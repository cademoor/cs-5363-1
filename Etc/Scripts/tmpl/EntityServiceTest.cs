using NUnit.Framework;
using Ttu.Domain;
using Ttu.Service;

namespace Ttu.ServiceTest.service
{
    [TestFixture]
    public class EntityServiceTest : AbstractServiceTest
    {

        private EntityService Service;

        [SetUp]
        public void SetUp()
        {
            Service = new EntityService(UnitOfWork);

            UnitOfWork.Entitys.RemoveAll(UnitOfWork.Entitys.FindAll());
            UnitOfWork.Commit();
            UnitOfWork.Abort();
        }

        #region Blue Sky Tests

        [Test]
        public void TestBlueSky_MaintainEntitys()
        {
            // pre-conditions
            Assert.AreEqual(0, Service.GetEntitys().Length);

            // exercise
            IEntity volunteerProfile1 = CreateEntity();
            Service.AddEntity(volunteerProfile1);

            IEntity volunteerProfile2 = CreateEntity();
            Service.AddEntity(volunteerProfile2);

            Service.RemoveEntity(volunteerProfile1);

            UnitOfWork.Commit();
            UnitOfWork.Abort();

            // post-conditions
            Assert.AreEqual(1, Service.GetEntitys().Length);
            Assert.IsNull(Service.GetEntity(volunteerProfile1.RecordId));
            Assert.IsNotNull(Service.GetEntity(volunteerProfile2.RecordId));
        }

        #endregion

        [TearDown]
        public void TearDown()
        {
        }

        #region Helper Methods

        private IEntity CreateEntity()
        {
            return new Entity();
        }

        #endregion

    }
}
