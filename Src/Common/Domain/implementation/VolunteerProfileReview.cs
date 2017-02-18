namespace Ttu.Domain
{
    public class VolunteerProfileReview : IVolunteerProfileReview
    {

        #region Constructors

        public VolunteerProfileReview()
        {
            Notes = string.Empty;
            Rating = null;
            RecordId = 0;
            Reviewer = null;
        }

        #endregion

        #region Properties

        public virtual string Notes { get; set; }
        public virtual int? Rating { get; set; }
        public virtual int RecordId { get; set; }
        public virtual IUser Reviewer { get; set; }

        #endregion

        #region Public Methods

        public virtual bool HasBeenRated()
        {
            return Rating.HasValue;
        }

        #endregion

    }
}
