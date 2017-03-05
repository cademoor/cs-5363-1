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

            Causes = string.Empty;
            Description = string.Empty;
            Location = string.Empty;
            Photo = new byte[0];
            RecordId = 0;
            Skills = string.Empty;
        }

        #endregion

        #region Properties

        public virtual string Causes { get; set; }

        public virtual string Description { get; set; }

        public virtual string Location { get; set; }

        public virtual string Name { get; set; }

        public virtual byte[] Photo { get; set; }

        public virtual int RecordId { get; set; }

        public virtual string Skills { get; set; }

        public virtual IUser User { get; set; }

        #endregion

        #region Public Methods

        public virtual void SetPhoto(byte[] photoBytes)
        {
            Photo = photoBytes; // TODO:ACM - scale the photo
        }

        #endregion

    }
}
