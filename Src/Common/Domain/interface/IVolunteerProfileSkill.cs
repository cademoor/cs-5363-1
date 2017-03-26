namespace Ttu.Domain
{
    public interface IVolunteerProfileSkill
    {

        string Description { get; set; }
        IVolunteerProfile VolunteerProfile { get; }

    }
}
