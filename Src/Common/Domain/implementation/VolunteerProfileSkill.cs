namespace Ttu.Domain
{
    public class VolunteerProfileSkill : IVolunteerProfileSkill
    {

        #region Constructors

        public VolunteerProfileSkill()
            : this(null, string.Empty)
        {
        }

        public VolunteerProfileSkill(IVolunteerProfile volunteerProfile, string description)
        {
            Description = description;
            VolunteerProfile = volunteerProfile;
        }

        #endregion

        #region Properties

        public virtual string Description { get; set; }
        public virtual IVolunteerProfile VolunteerProfile { get; set; }

        #endregion

    }
}
