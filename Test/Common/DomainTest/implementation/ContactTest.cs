using NUnit.Framework;
using Ttu.Domain;

namespace Ttu.DomainTest
{
    [TestFixture]
    public class ContactTest
    {

        private Contact Contact;
        private IUser User;

        [SetUp]
        public void SetUp()
        {
            Contact = new Contact();
            User = new User("ADMIN");
        }

        # region Blue Sky Tests

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
            Assert.AreEqual("1112223333", Contact.Value);
        }

        # endregion

        [TearDown]
        public void TearDown()
        {
        }

    }
}
