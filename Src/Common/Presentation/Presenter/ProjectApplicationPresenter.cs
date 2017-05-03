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
            IProjectApplication[] projectApplications = ProjectService.GetSubmittedApplications(projectId);

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

        #endregion

    }
}