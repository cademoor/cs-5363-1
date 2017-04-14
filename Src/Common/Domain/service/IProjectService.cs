namespace Ttu.Domain
{
    public interface IProjectService
    {

        void AddProject(IProject project);

        IProjectApplication[] GetAllApplications(IProject project);
        IProjectApplication[] GetApprovedApplications(IProject project);
        IProjectApplication[] GetDeniedApplications(IProject project);
        IProjectApplication[] GetSubmittedApplications(IProject project);

        IProject[] GetProjects(int organizationRecordId);
        IProject[] GetProjectsCreatedBy(IUser user);
        IProject GetProject(int recordId);
        IProject[] GetAllAppliedProjects(IUser user, ProjectApplicationStatus status);
        IProject[] GetCurrentAppliedProjects(IUser user, ProjectApplicationStatus status);
        IProject[] GetPreviousAppliedProjects(IUser user, ProjectApplicationStatus status);

        void RemoveProject(int recordId);
        void RemoveProject(IProject project);

        void Volunteer(IUser user, IProject project, string note);

    }
}
