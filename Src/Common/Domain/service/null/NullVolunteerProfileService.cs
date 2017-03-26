namespace Ttu.Domain
{
    public class NullVolunteerProfileService : IVolunteerProfileService
    {

        public static IVolunteerProfileService Singleton = new NullVolunteerProfileService();

        #region Constructors

        protected NullVolunteerProfileService()
        {
        }

        #endregion

        #region Public Methods

        public virtual void AddVolunteerProfile(IVolunteerProfile volunteerProfile)
        {
            // do nothing
        }

        public virtual IVolunteerProfile GetVolunteerProfile(IUser user)
        {
            return null;
        }

        public virtual IVolunteerProfile GetVolunteerProfile(int recordId)
        {
            return null;
        }

        public virtual IVolunteerProfile[] GetVolunteerProfiles()
        {
            return new IVolunteerProfile[0];
        }

        public virtual void RemoveVolunteerProfile(int recordId)
        {
            // do nothing
        }

        public virtual void RemoveVolunteerProfile(IVolunteerProfile volunteerProfile)
        {
            // do nothing
        }

        #endregion

    }
}
