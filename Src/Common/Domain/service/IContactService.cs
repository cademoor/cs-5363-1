namespace Ttu.Domain
{
    public interface IContactService
    {

        void AddContact(IContact user);

        IContact GetContact(int recordId);
        IContact[] GetContacts();
        IContact[] GetContacts(IUser user);

        void RemoveContact(int recordId);
        void RemoveContact(IContact user);

    }
}
