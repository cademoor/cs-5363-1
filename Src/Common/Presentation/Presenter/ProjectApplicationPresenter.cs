using System;
using System.Linq;
using Ttu.Domain;
using Ttu.Presentation.Model;
using Ttu.Presentation.ViewState;

namespace Ttu.Presentation.Presenter
{
    public class ProjectApplicationPresenter : AbstractPresenter
    {

        #region Constructors

        public ProjectApplicationPresenter(ProjectApplicationViewState viewState)
            : base(viewState)
        {
            OrganizationService = CreateOrganizationService();
            ProjectService = CreateProjectService();
        }

        #endregion

        #region Properties

        private IOrganizationService OrganizationService { get; set; }
        private IProjectService ProjectService { get; set; }

        #endregion

        #region Public Methods

        public void Volunteer(ProjectModel projectModel, String note)
        {
            IProject project = new Project();
            projectModel.ApplyTo(project);
            ProjectService.Volunteer(User, project, note);
        }

        public ProjectApplicationModel[] GetProjectApplications(ProjectModel projectModel)
        {
            IProject project = new Project();
            projectModel.ApplyTo(project);
            IProjectApplication[] projectApplications = ProjectService.GetSubmittedApplications(project);

            // guard clause - not/none found
            if (projectApplications == null || projectApplications.Length == 0)
            {
                return null;
            }

            ProjectApplicationModel[] projectApplicationModels = new ProjectApplicationModel[projectApplications.Length];
            for ( int i=0; i<projectApplications.Length; i++)
            {
                projectApplicationModels[i] = new ProjectApplicationModel();
                projectApplicationModels[i].CopyFrom(projectApplications[i]);
            }

            return projectApplicationModels;
        }

        public ProjectModel GetProject(int recordId)
        {
            // guard clause - not found
            IProject project = Service.GetProject(recordId);
            if (project == null)
            {
                return null;
            }

            return CreateProjectModel(project);
        }

        public ProjectModel[] GetProjects(int organizationRecordId)
        {
            return Service.GetProjects(organizationRecordId).Select(o => CreateProjectModel(o)).ToArray();
        }

        public void RemoveProject(ProjectModel projectModel)
        {
            // guard clause - invalid input
            if (projectModel == null)
            {
                return;
            }

            Service.RemoveProject(projectModel.RecordId);
            Commit();
        }

        #endregion

        #region Helper Methods

        private ProjectModel CreateProjectModel(IProject project)
        {
            ProjectModel projectModel = new ProjectModel();
            projectModel.CopyFrom(project);
            return projectModel;
        }

        private OrganizationModel GetOrganization(int recordId)
        {
            // guard clause - not found
            IOrganization organization = OrganizationService.GetOrganization(recordId);
            if (organization == null)
            {
                return null;
            }

            return CreateOrganizationModel(organization);
        }

        #endregion
    }
}