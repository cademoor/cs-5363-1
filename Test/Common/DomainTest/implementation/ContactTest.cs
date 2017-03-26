using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ttu.Domain;

namespace Ttu.DomainTest.implementation
{
    [TestClass]
    public class ContactTest
    {

        private Contact Contact;

        [TestInitialize]
        public void SetUp()
        {
            Contact = new Contact();
        }

        #region Blue Sky Tests

        [TestMethod]
        public void TestBlueSky_Coverage()
        {
            // pre-conditions
            Assert.AreEqual(ContactType.None, Contact.ContactType);
            Assert.AreEqual(0, Contact.RecordId);
            Assert.AreEqual(string.Empty, Contact.Value);

            // exercise
            Contact.ContactType = ContactType.HomePhone;
            Contact.RecordId = 1;
            Contact.Value = "1112223333";

            // post-conditions
            Assert.AreEqual(ContactType.HomePhone, Contact.ContactType);
            Assert.AreEqual(1, Contact.RecordId);
            Assert.AreEqual("1112223333", Contact.Value);
        }

        #endregion

        [TestCleanup]
        public void TearDown()
        {
        }

    }
}
