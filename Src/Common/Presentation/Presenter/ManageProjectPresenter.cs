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
            OrganizationService = CreateOrganizationService();
            Service = CreateProjectService();
        }

        #endregion

        #region Properties

        private IOrganizationService OrganizationService { get; set; }
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

            int organizationId = projectModel.OrganizationId;
            OrganizationModel organizationModel = GetOrganization(organizationId);
            if (organizationModel == null)
            {
                throw new Exception("Unable to find organization with ID " + organizationId);
            }
            projectModel.OrganizationModel = organizationModel;

            IProject project = new Project(User);
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
