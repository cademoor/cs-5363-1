using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ttu.Domain;

namespace Ttu.Presentation
{
    public class ManageProjectPresenter : AbstractPresenter
    {

        #region Constructors

        public ManageProjectPresenter(ManageProjectViewState viewState)
            : base(viewState)
        {
            Service = CreateProjectService();
        }

        #endregion

        #region Properties

        private IProjectService Service { get; set; }

        #endregion

        #region Public Methods

        public void AddProject(ProjectModel projectModel)
        {
            // guard clause - invalid input
            if (projectModel == null)
            {
                return;
            }

            IProject project = new Project(User, Organization);
            projectModel.ApplyTo(project);

            Service.AddProject(project);
            Commit();
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

        public ProjectModel[] GetProjects()
        {
            return Service.GetProjects().Select(o => CreateProjectModel(o)).ToArray();
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

        #endregion

    }
}
