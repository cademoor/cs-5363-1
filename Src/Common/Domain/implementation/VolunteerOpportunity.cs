using System;
using System.Collections.Generic;

namespace Ttu.Domain
{
    public class VolunteerOpportunity : IVolunteerOpportunity
    {

        #region Constructors

        public VolunteerOpportunity()
            : this(null, null)
        {
        }

        public VolunteerOpportunity(IUser createdBy, IOrganization organization)
        {
            CreatedBy = createdBy;
            Organization = organization;

            RecordId = 0;

            ProjectName = string.Empty;
            ProjectDescription = string.Empty;

            StartTime = DateTime.MinValue;
            StopTime = DateTime.MinValue;

            NumVolunteersNeeded = 0;
            MaxNumVolunteers = 0;
        }

        #endregion

        #region Properties

        public virtual IUser CreatedBy { get; set; }
        public virtual IOrganization Organization { get; set; }

        public virtual int RecordId { get; set; }

        public virtual string ProjectName { get; set; }
        public virtual string ProjectDescription { get; set; }

        public virtual DateTime StartTime { get; set; }
        public virtual DateTime StopTime { get; set; }

        public virtual int NumVolunteersNeeded { get; set; }
        public virtual int MaxNumVolunteers { get; set; }

        #endregion

        #region Public Methods

        public virtual bool IsCurrent()
        {
            return StartTime == DateTime.MinValue || StartTime >= DateTime.Today;
        }

        public virtual bool IsPrevious()
        {
            return StartTime < DateTime.Today && StartTime != DateTime.MinValue;
        }


        #endregion

    }
}
