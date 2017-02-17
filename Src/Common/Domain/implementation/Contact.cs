namespace Ttu.Domain
{
    public class Contact : IContact
    {

        # region Constructors

        public Contact()
            : this(null, ContactType.None, string.Empty)
        {
        }

        public Contact(IUser user, ContactType contactType, string value)
        {
            ContactType = contactType;
            Value = value;
            User = user;

            RecordId = 0;
        }

        # endregion

        # region Properties

        public virtual ContactType ContactType { get; set; }
        public virtual int RecordId { get; set; }
        public virtual IUser User { get; protected set; }
        public virtual string Value { get; set; }

        # endregion

    }
}
