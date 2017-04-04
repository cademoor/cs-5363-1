namespace Ttu.Domain
{
    public interface IOrganizationUser
    {

        int RecordId { get; set; }

        IOrganization Organization { get; set; }
        IUser User { get; set; }

        int OrganizationId { get; set; }
        int UserId { get; set; }
        int OrganizationRole { get; set; }
        bool OrganizationCreator { get; set; }

     }
}
