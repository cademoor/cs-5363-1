﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ttu.Domain;
using Ttu.Service;

namespace Ttu.ServiceTest.persistence
{
    [TestClass]
    public class UnitOfWorkRepositoryTest : AbstractServiceTest
    {

        // used to provide a non-mapped class to cause exception to occur
        private class TestClassNotMapped
        {
        }

        private UnitOfWorkRepository<TestClassNotMapped> Repository;

        private TestClassNotMapped TestObjectNotMapped;

        [TestInitialize]
        public void SetUp()
        {
            Repository = new UnitOfWorkRepository<TestClassNotMapped>(Session);
            TestObjectNotMapped = new TestClassNotMapped();
        }

        #region Non Blue Sky Tests (Stateful)

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
        public void TestNonBlueSky_Stateful_IsObjectAlreadyPersistent()
        {
            Assert.IsFalse(Repository.IsObjectAlreadyPersistent(TestObjectNotMapped));
        }

        [TestMethod]
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

        [TestMethod]
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

        [TestCleanup]
        public void TearDown()
        {
        }

    }
}
