namespace Ttu.Domain
{
    public interface IOrganizationUser
    {

        // attributes
        IOrganization Organization { get; set; }
        int RecordId { get; set; }
        IUser User { get; set; }

        // behavior
        int GetOrganizationRecordId();
        int GetUserRecordId();
        bool IsOrganizationCreator();

    }
}
