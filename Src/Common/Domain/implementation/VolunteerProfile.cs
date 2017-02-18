namespace Ttu.Domain
{
    public class VolunteerProfile : IVolunteerProfile
    {

        #region Constructors

        public VolunteerProfile()
            : this(null)
        {
        }

        public VolunteerProfile(IUser user)
        {
            User = user;

            RecordId = 0;
        }

        #endregion

        #region Properties

        public virtual int RecordId { get; set; }
        public virtual IUser User { get; set; }

        #endregion

    }
}
