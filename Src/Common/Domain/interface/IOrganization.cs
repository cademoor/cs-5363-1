namespace Ttu.Domain
{
    public interface IOrganization
    {

        IContact Contact { get; set; }
        IUser CreatedBy { get; }

        string Description { get; set; }

        ILocation Location { get; set; }

        string MissionStatement { get; set; }

        string Name { get; set; }

        int RecordId { get; set; }

        string Website { get; set; }

    }
}
