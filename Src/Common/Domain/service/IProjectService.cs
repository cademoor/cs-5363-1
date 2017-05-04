namespace Ttu.Domain
{
    public interface IProjectService
    {

        void AddProject(IProject project);

        IProjectApplication[] GetAllApplications(int projectRecordId);
        IProjectApplication[] GetApprovedApplications(int projectRecordId);
        IProjectApplication[] GetDeniedApplications(int projectRecordId);
        IProjectApplication[] GetSubmittedApplications(int projectRecordId);

        IProject[] GetProjects();
        IProject[] GetActiveProjectsByEndDate();
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
