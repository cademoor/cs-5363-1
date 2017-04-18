namespace Ttu.Domain
{
    public class ProjectApplication : IProjectApplication
    {

        #region Constructors

        public ProjectApplication()
            : this(null, null)
        {
        }

        public ProjectApplication(IUser user, IProject project)
        {
            User = user;
            Project = project;

            LastChangeStatusUser = null;
            Note = string.Empty;
            Status = ProjectApplicationStatus.Submitted;
            RecordId = 0;
        }

        #endregion

        #region Properties

        public virtual IUser LastChangeStatusUser { get; set; }

        public virtual string Note { get; set; }

        public virtual int RecordId { get; set; }

        public virtual ProjectApplicationStatus Status { get; set; }

        public virtual IUser User { get; set; }

        public virtual IProject Project { get; set; }

        #endregion

        #region Public Methods

        public virtual void ChangeStatus(IUser user, ProjectApplicationStatus status)
        {
            LastChangeStatusUser = user;
            Status = status;
        }

        public virtual bool IsCurrent()
        {
            // guard clause - invalid state
            if (Project == null)
            {
                return false;
            }

            return Project.IsCurrent();
        }

        public virtual bool IsPrevious()
        {
            // guard clause - invalid state
            if (Project == null)
            {
                return false;
            }

            return Project.IsPrevious();
        }

        #endregion

    }
}
