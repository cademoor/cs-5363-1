namespace Ttu.Domain
{
    public interface IVolunteerProfile
    {

        int RecordId { get; }
        IUser User { get; }

    }
}
