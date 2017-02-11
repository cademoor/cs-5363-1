namespace Ttu.Domain
{
    public interface IUser
    {

        // attributes
        string FirstName { get; set; }
        string LastName { get; set; }
        int RecordId { get; }
        string UserId { get; set; }

        // behavior
        bool IsValid();

    }
}
