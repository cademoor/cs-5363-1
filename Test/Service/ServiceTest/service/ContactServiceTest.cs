using NUnit.Framework;
using Ttu.Domain;
using Ttu.Service;

namespace Ttu.ServiceTest.service
{
    [TestFixture]
    public class ContactServiceTest : AbstractServiceTest
    {

        private ContactService Service;

        [SetUp]
        public void SetUp()
        {
            Service = new ContactService(UnitOfWork);

            UnitOfWork.Contacts.RemoveAll(UnitOfWork.Contacts.FindAll());
            UnitOfWork.Commit();
            UnitOfWork.Abort();
        }

        #region Blue Sky Tests

        [Test]
        public void TestBlueSky_MaintainContacts()
        {
            // pre-conditions
            Assert.AreEqual(0, Service.GetContacts().Length);

            // exercise
            IContact contactHome = CreateContact(ContactType.HomePhone, "1112223333");
            Service.AddContact(contactHome);

            IContact contactMobile = CreateContact(ContactType.MobilePhone, "4445556666");
            Service.AddContact(contactMobile);

            Service.RemoveContact(contactHome);

            UnitOfWork.Commit();
            UnitOfWork.Abort();

            // post-conditions
            Assert.AreEqual(1, Service.GetContacts().Length);
            Assert.IsNull(Service.GetContact(contactHome.RecordId));
            Assert.IsNotNull(Service.GetContact(contactMobile.RecordId));
        }

        #endregion

        [TearDown]
        public void TearDown()
        {
        }

        #region Helper Methods

        private IContact CreateContact(ContactType contactType, string value)
        {
            return new Contact(User, contactType, value);
        }

        #endregion

    }
}
