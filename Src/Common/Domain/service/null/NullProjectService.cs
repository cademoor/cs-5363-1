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

        public virtual IProjectApplication[] GetAllApplications(IProject project)
        {
            return new IProjectApplication[0];
        }

        public virtual IProjectApplication[] GetApprovedApplications(IProject project)
        {
            return new IProjectApplication[0];
        }

        public virtual IProjectApplication[] GetDeniedApplications(IProject project)
        {
            return new IProjectApplication[0];
        }

        public virtual IProjectApplication[] GetSubmittedApplications(IProject project)
        {
            return new IProjectApplication[0];
        }

        public virtual IProject[] GetProjects(int organizationId)
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
