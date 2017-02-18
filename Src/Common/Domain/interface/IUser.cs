namespace Ttu.Domain
{
    public interface IUser
    {

        // attributes
        string EmailAddress { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string PasswordEncrypted { get; set; }

        int RecordId { get; }

        string UserId { get; set; }

        // behavior
        bool IsValid();

        bool MatchesPassword(string password);

        void SetPassword(string password);

    }
}
