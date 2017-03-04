namespace Ttu.Domain
{
    public interface IOrganization
    {

        IUser CreatedBy { get; }

        string Description { get; set; }

        string Name { get; set; }

        int RecordId { get; set; }

    }
}
