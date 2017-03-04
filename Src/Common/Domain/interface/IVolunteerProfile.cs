namespace Ttu.Domain
{
    public interface IVolunteerProfile
    {

        string Description { get; set; }
        string Name { get; set; }
        int RecordId { get; }
        IUser User { get; }

    }
}
