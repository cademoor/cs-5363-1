namespace Ttu.Domain
{
    public class NullContactService : IContactService
    {

        public static IContactService Singleton = new NullContactService();

        # region Constructors

        private NullContactService()
        {
        }

        # endregion

        # region Public Methods

        public virtual void AddContact(IContact user)
        {
            // do nothing
        }

        public virtual IContact GetContact(int recordId)
        {
            return null;
        }

        public virtual IContact[] GetContacts()
        {
            return new IContact[0];
        }

        public virtual IContact[] GetContacts(IUser user)
        {
            return new IContact[0];
        }

        public virtual void RemoveContact(int recordId)
        {
            // do nothing
        }

        public virtual void RemoveContact(IContact user)
        {
            // do nothing
        }

        # endregion

    }
}
