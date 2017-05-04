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
            Commit();
        }

        public ProjectApplicationModel[] GetProjectApplications(int projectId)
        {
            return ProjectService.GetAllApplications(projectId).Select(o => CreateProjectApplicationModel(o)).ToArray();
        }

        #endregion

        #region Helper Methods

        private ProjectApplicationModel CreateProjectApplicationModel(IProjectApplication projectApplication)
        {
            ProjectApplicationModel projectApplicationModel = new ProjectApplicationModel();
            projectApplicationModel.CopyFrom(projectApplication);
            return projectApplicationModel;
        }

        #endregion
    }
}