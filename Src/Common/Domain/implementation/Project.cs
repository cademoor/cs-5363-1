using System;

namespace Ttu.Domain
{
    public class Project : IProject
    {

        #region Constructors

        public Project()
            : this(null)
        {
        }

        public Project(IUser createdBy)
        {
            CreatedBy = createdBy;

            RecordId = 0;

            ProjectName = string.Empty;
            ProjectDescription = string.Empty;

            StartTime = DateTime.Today;
            StopTime = DateTime.Today;

            MinimumVolunteers = 0;
            MaximumVolunteers = 0;
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

        public virtual int MinimumVolunteers { get; set; }
        public virtual int MaximumVolunteers { get; set; }

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
