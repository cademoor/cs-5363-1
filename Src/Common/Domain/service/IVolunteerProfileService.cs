namespace Ttu.Domain
{
    public interface IVolunteerProfileService
    {

        void AddVolunteerProfile(IVolunteerProfile volunteerProfile);

        IVolunteerProfile GetVolunteerProfile(int recordId);
        IVolunteerProfile[] GetVolunteerProfiles();

        void RemoveVolunteerProfile(int recordId);

        void RemoveVolunteerProfile(IVolunteerProfile volunteerProfile);

    }
}
