namespace Ttu.Domain
{
    public interface IContact
    {

        ContactType ContactType { get; set; }
        int RecordId { get; set; }
        IUser User { get; }
        string Value { get; set; }

    }
}
