using System;

namespace Ttu.Domain
{
    public class VolunteerOpportunity : IVolunteerOpportunity
    {

        #region Constructors

        public VolunteerOpportunity()
            : this(null)
        {
        }

        public VolunteerOpportunity(IUser createdBy)
        {
            CreatedBy = createdBy;

            RecordId = 0;
            StartTime = DateTime.Today;
            StopTime = DateTime.Today;
        }

        #endregion

        #region Properties

        public virtual IUser CreatedBy { get; set; }
        public virtual int RecordId { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime StopTime { get; set; }

        #endregion

        #region Public Methods

        public virtual bool IsCurrent()
        {
            return StartTime >= DateTime.Today;
        }

        public virtual bool IsPrevious()
        {
            return StartTime < DateTime.Today;
        }

        #endregion

    }
}
