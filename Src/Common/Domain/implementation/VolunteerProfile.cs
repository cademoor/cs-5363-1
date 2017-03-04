namespace Ttu.Domain
{
    public class VolunteerProfile : IVolunteerProfile
    {

        #region Constructors

        public VolunteerProfile()
            : this(null, string.Empty)
        {
        }

        public VolunteerProfile(IUser user, string name)
        {
            Name = name;
            User = user;

            Description = string.Empty;
            RecordId = 0;
        }

        #endregion

        #region Properties

        public virtual string Description { get; set; }
        public virtual string Name { get; set; }
        public virtual int RecordId { get; set; }
        public virtual IUser User { get; set; }

        #endregion

    }
}
