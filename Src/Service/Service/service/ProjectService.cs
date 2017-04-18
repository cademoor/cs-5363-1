using System.Linq;
using Ttu.Domain;

namespace Ttu.Service
{
    public class ProjectService : AbstractService, IProjectService
    {

        #region Constructors

        public ProjectService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region Public Methods

        public void AddProject(IProject project)
        {
            UnitOfWork.Projects.Add(project);
        }

        public IProjectApplication[] GetAllApplications(IProject project)
        {
            return GetApplications(project, null);
        }

        public IProjectApplication[] GetApprovedApplications(IProject project)
        {
            return GetApplications(project, ProjectApplicationStatus.Approved);
        }

        public IProjectApplication[] GetDeniedApplications(IProject project)
        {
            return GetApplications(project, ProjectApplicationStatus.Denied);
        }

        public IProjectApplication[] GetSubmittedApplications(IProject project)
        {
            return GetApplications(project, ProjectApplicationStatus.Submitted);
        }

        public IProject[] GetProjects()
        {
            return UnitOfWork.Projects.FindAll();
        }

        public IProject[] GetProjects(int organizationRecordId)
        {
            return UnitOfWork.Projects.FindBy(vp => vp.Organization.RecordId == organizationRecordId);
        }

        public IProject[] GetProjectsCreatedBy(IUser user)
        {
            return UnitOfWork.Projects.FindBy(vp => vp.CreatedBy == user);
        }

        public IProject GetProject(int recordId)
        {
            return UnitOfWork.Projects.FindByRecordId(recordId);
        }

        public IProject[] GetAllAppliedProjects(IUser user, ProjectApplicationStatus status)
        {
            return GetApplications(user, status);
        }

        public IProject[] GetCurrentAppliedProjects(IUser user, ProjectApplicationStatus status)
        {
            return GetApplications(user, status).Where(a => a.IsCurrent()).ToArray();
        }

        public IProject[] GetPreviousAppliedProjects(IUser user, ProjectApplicationStatus status)
        {
            return GetApplications(user, status).Where(a => a.IsPrevious()).ToArray();
        }

        public void RemoveProject(int recordId)
        {
            // guard clause - not found
            Project project = GetProject(recordId) as Project;
            if (project == null)
            {
                return;
            }

            IProjectApplication[] applications = UnitOfWork.ProjectApplications.FindBy(voa => voa.Project == project);
            UnitOfWork.ProjectApplications.RemoveAll(applications);
            project.CreatedBy = null;
            project.Organization = null;

            UnitOfWork.Projects.Remove(project);
        }

        public void RemoveProject(IProject project)
        {
            // guard clause - invalid input
            if (project == null)
            {
                return;
            }

            RemoveProject(project.RecordId);
        }

        public void Volunteer(IUser user, IProject project, string note)
        {
            // guard clause - invalid input
            if (user == null || project == null)
            {
                return;
            }

            IProjectApplication application = new ProjectApplication(user, project);
            application.Note = note;

            UnitOfWork.ProjectApplications.Add(application);
        }

        #endregion

        # region Helper Methods

        private IProject[] GetApplications(IUser user, ProjectApplicationStatus status)
        {
            IQueryable<IProjectApplication> projectApplications = UnitOfWork.ProjectApplications.GetQueryable();
            return projectApplications.Where(a => a.User == user && a.Status == status).Select(a => a.Project).ToArray();
        }

        private IProjectApplication[] GetApplications(IProject project, ProjectApplicationStatus? status)
        {
            IQueryable<IProjectApplication> projectApplications = UnitOfWork.ProjectApplications.GetQueryable();
            projectApplications = projectApplications.Where(a => a.Project == project);
            if (!status.HasValue)
            {
                return projectApplications.ToArray();
            }

            return projectApplications.Where(a => a.Status == status).ToArray();
        }

        #endregion

    }
}
