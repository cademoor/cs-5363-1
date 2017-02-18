using NUnit.Framework;
using Ttu.Domain;
using Ttu.Service;

namespace Ttu.ServiceTest.persistence
{
    [TestFixture]
    public class UnitOfWorkRepositoryTest : AbstractServiceTest
    {

        // used to provide a non-mapped class to cause exception to occur
        private class TestClassNotMapped
        {
        }

        private UnitOfWorkRepository<TestClassNotMapped> Repository;

        private TestClassNotMapped TestObjectNotMapped;

        [SetUp]
        public void SetUp()
        {
            Repository = new UnitOfWorkRepository<TestClassNotMapped>(Session);
            TestObjectNotMapped = new TestClassNotMapped();
        }

        #region Non Blue Sky Tests (Stateful)

        [Test]
        public void TestNonBlueSky_Stateful_Add()
        {
            try
            {
                Repository.Add(TestObjectNotMapped);
                Assert.Fail("An exception should have been thrown.");
            }
            catch (PersistenceException ex)
            {
                Assert.IsTrue(ex.Message.StartsWith("Problem saving object"));
            }
        }

        [Test]
        public void TestNonBlueSky_Stateful_Add_Null()
        {
            // set-up
            int preCount = Repository.FindAll().Length;

            // exercise
            Repository.Add(null);

            // post-conditions
            int postCount = Repository.FindAll().Length;
            Assert.AreEqual(preCount, postCount);
        }

        [Test]
        public void TestNonBlueSky_Stateful_AddAll()
        {
            try
            {
                Repository.AddAll(new TestClassNotMapped[] { TestObjectNotMapped });
                Assert.Fail("An exception should have been thrown.");
            }
            catch (PersistenceException ex)
            {
                Assert.IsTrue(ex.Message.StartsWith("Problem saving object"));
            }

            try
            {
                Repository.AddAll(new TestClassNotMapped[0]);
            }
            catch (PersistenceException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void TestNonBlueSky_Stateful_FindBy()
        {
            try
            {
                Repository.FindBy(o => o != null);
                Assert.Fail("An exception should have been thrown.");
            }
            catch (PersistenceException ex)
            {
                Assert.IsTrue(ex.Message.StartsWith("Problem querying objects"));
            }
        }

        [Test]
        public void TestNonBlueSky_Stateful_FindByRecordId()
        {
            try
            {
                Repository.FindByRecordId(0);
                Assert.Fail("An exception should have been thrown.");
            }
            catch (PersistenceException ex)
            {
                Assert.IsTrue(ex.Message.StartsWith("Problem querying object"));
            }
        }

        [Test]
        public void TestNonBlueSky_Stateful_FindByUnique()
        {
            try
            {
                Repository.FindByUnique(o => o != null);
                Assert.Fail("An exception should have been thrown.");
            }
            catch (PersistenceException ex)
            {
                Assert.IsTrue(ex.Message.StartsWith("Problem querying object"));
            }
        }

        [Test]
        public void TestNonBlueSky_Stateful_IsObjectAlreadyPersistent()
        {
            Assert.IsFalse(Repository.IsObjectAlreadyPersistent(TestObjectNotMapped));
        }

        [Test]
        public void TestNonBlueSky_Stateful_Remove()
        {
            try
            {
                Repository.Remove(TestObjectNotMapped);
                Assert.Fail("An exception should have been thrown.");
            }
            catch (PersistenceException ex)
            {
                Assert.IsTrue(ex.Message.StartsWith("Problem deleting object"));
            }
        }

        [Test]
        public void TestNonBlueSky_Stateful_RemoveAll()
        {
            try
            {
                Repository.RemoveAll(new TestClassNotMapped[] { TestObjectNotMapped });
                Assert.Fail("An exception should have been thrown.");
            }
            catch (PersistenceException ex)
            {
                Assert.IsTrue(ex.Message.StartsWith("Problem deleting object"));
            }
        }

        #endregion

        [TearDown]
        public void TearDown()
        {
        }

    }
}
