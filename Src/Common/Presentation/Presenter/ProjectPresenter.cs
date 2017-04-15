using System.Linq;
using Ttu.Domain;

namespace Ttu.Presentation.Presenter
{
    public class ProjectPresenter : AbstractPresenter
    {

        #region Constructors

        public ProjectPresenter(IViewState viewState) : base(viewState)
        {
            Service = CreateProjectService();
        }

        #endregion

        #region Properties

        private IProjectService Service { get; set; }

        #endregion

        #region Public Methods

        public ProjectModel[] GetProjects()
        {
            return Service.GetProjects().Select(CreateProjectModel).ToArray();
        }

        #endregion

        #region Helper Methods

        private static ProjectModel CreateProjectModel(IProject project)
        {
            var projectModel = new ProjectModel();
            projectModel.CopyFrom(project);
            return projectModel;
        }

        #endregion

    }
}
