using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Type;
using Ttu.Domain;

namespace Ttu.Service
{

    public class ProjectService : AbstractService, IProjectService
    {

        private class EndDateComparer : IComparer<IProject>
        {
            public int Compare(IProject x, IProject y)
            {
                // Shouldn't ever happen, but just in case...
                if (x == null || y == null)
                {
                    throw new NullReferenceException("Cannot compare a null Project(s)");
                }
                return x.StopTime.CompareTo(y.StopTime);
            }
        }

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

        public IProjectApplication[] GetAllApplications(int projectRecordId)
        {
            return GetApplications(projectRecordId, null);
        }

        public IProjectApplication[] GetApprovedApplications(int projectRecordId)
        {
            return GetApplications(projectRecordId, ProjectApplicationStatus.Approved);
        }

        public IProjectApplication[] GetDeniedApplications(int projectRecordId)
        {
            return GetApplications(projectRecordId, ProjectApplicationStatus.Denied);
        }

        public IProjectApplication[] GetSubmittedApplications(int projectRecordId)
        {
            return GetApplications(projectRecordId, ProjectApplicationStatus.Submitted);
        }

        public IProject[] GetProjects()
        {
            return UnitOfWork.Projects.FindAll();
        }

        public IProject[] GetActiveProjectsByEndDate()
        {
            IProject[] activeProjects = UnitOfWork.Projects.FindBy(vp => vp.StopTime >= DateTime.Today);
            Array.Sort(activeProjects, new EndDateComparer());
            return activeProjects;
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

        private IProjectApplication[] GetApplications(int projectId, ProjectApplicationStatus? status)
        {
            IQueryable<IProjectApplication> projectApplications = UnitOfWork.ProjectApplications.GetQueryable();
            projectApplications = projectApplications.Where(a => a.Project.RecordId == projectId);
            if (!status.HasValue)
            {
                return projectApplications.ToArray();
            }

            return projectApplications.Where(a => a.Status == status).ToArray();
        }

        #endregion

    }
}
