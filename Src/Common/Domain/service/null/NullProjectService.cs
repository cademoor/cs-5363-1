namespace Ttu.Domain
{
    public class NullProjectService : IProjectService
    {

        public static IProjectService Singleton = new NullProjectService();

        #region Constructors

        protected NullProjectService()
        {
        }

        #endregion

        #region Public Methods

        public virtual void AddProject(IProject project)
        {
            // do nothing
        }

        public virtual IProjectApplication[] GetAllApplications(int projectId)
        {
            return new IProjectApplication[0];
        }

        public virtual IProjectApplication[] GetApprovedApplications(int projectId)
        {
            return new IProjectApplication[0];
        }

        public virtual IProjectApplication[] GetDeniedApplications(int projectId)
        {
            return new IProjectApplication[0];
        }

        public virtual IProjectApplication[] GetSubmittedApplications(int projectId)
        {
            return new IProjectApplication[0];
        }

        public virtual IProject[] GetProjects()
        {
            return new IProject[0];
        }

        public virtual IProject[] GetProjects(int organizationRecordId)
        {
            return new IProject[0];
        }

        public virtual IProject[] GetProjectsCreatedBy(IUser user)
        {
            return new IProject[0];
        }

        public virtual IProject GetProject(int recordId)
        {
            return null;
        }

        public IProject[] GetActiveProjectsByEndDate()
        {
            return new IProject[0];
        }

        public virtual IProject[] GetAllAppliedProjects(IUser user, ProjectApplicationStatus status)
        {
            return new IProject[0];
        }

        public virtual IProject[] GetCurrentAppliedProjects(IUser user, ProjectApplicationStatus status)
        {
            return new IProject[0];
        }

        public virtual IProject[] GetPreviousAppliedProjects(IUser user, ProjectApplicationStatus status)
        {
            return new IProject[0];
        }

        public virtual void RemoveProject(int recordId)
        {
            // do nothing
        }

        public virtual void RemoveProject(IProject project)
        {
            // do nothing
        }

        public virtual void Volunteer(IUser user, IProject project, string note)
        {
            // do nothing
        }

        #endregion

    }
}
