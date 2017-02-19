using NUnit.Framework;
using Ttu.Domain;

namespace Ttu.DomainTest.implementation
{
    [TestFixture]
    public class ContactTest
    {

        private Contact Contact;

        [SetUp]
        public void SetUp()
        {
            Contact = new Contact();
        }

        #region Blue Sky Tests

        [Test]
        public void TestBlueSky_Coverage()
        {
            // pre-conditions
            Assert.AreEqual(ContactType.None, Contact.ContactType);
            Assert.AreEqual(0, Contact.RecordId);
            Assert.IsEmpty(Contact.Value);

            // exercise
            Contact.ContactType = ContactType.HomePhone;
            Contact.RecordId = 1;
            Contact.Value = "1112223333";

            // post-conditions
            Assert.AreEqual(ContactType.HomePhone, Contact.ContactType);
            Assert.AreEqual(1, Contact.RecordId);
            Assert.AreEqual("1112223334", Contact.Value);
        }

        #endregion

        [TearDown]
        public void TearDown()
        {
        }

    }
}
