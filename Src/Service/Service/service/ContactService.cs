using Ttu.Domain;

namespace Ttu.Service
{
    public class ContactService : AbstractService, IContactService
    {

        #region Constructors

        public ContactService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region Public Methods

        public virtual void AddContact(IContact contact)
        {
            UnitOfWork.Contacts.Add(contact);
        }

        public virtual IContact GetContact(int recordId)
        {
            return UnitOfWork.Contacts.FindByRecordId(recordId);
        }

        public virtual IContact[] GetContacts()
        {
            return UnitOfWork.Contacts.FindAll();
        }

        public virtual IContact[] GetContacts(IUser user)
        {
            return UnitOfWork.Contacts.FindBy(c => c.User == user);
        }

        public virtual void RemoveContact(int recordId)
        {
            // guard clause - not found
            IContact user = GetContact(recordId);
            if (user == null)
            {
                return;
            }

            UnitOfWork.Contacts.Remove(user);
        }

        public virtual void RemoveContact(IContact contact)
        {
            // guard clause - invalid input
            if (contact == null)
            {
                return;
            }

            RemoveContact(contact.RecordId);
        }

        #endregion

    }
}
