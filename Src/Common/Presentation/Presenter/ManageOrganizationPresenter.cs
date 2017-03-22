using System.Linq;
using Ttu.Domain;

namespace Ttu.Presentation
{
    public class ManageOrganizationPresenter : AbstractPresenter
    {

        #region Constructors

        public ManageOrganizationPresenter(ManageOrganizationViewState viewState)
            : base(viewState)
        {
            Service = CreateOrganizationService();
        }

        #endregion

        #region Properties

        private IOrganizationService Service { get; set; }

        #endregion

        #region Public Methods

        public void AddOrganization(OrganizationModel organizationModel)
        {
            IOrganization organization = new Organization(User, organizationModel.Name);
            organizationModel.ApplyTo(organization);

            Service.AddOrganization(organization);
            Commit();
        }

        public IOrganization GetOrganization(int recordId)
        {
            return Service.GetOrganization(recordId);
        }

        public OrganizationModel[] GetOrganizations()
        {
            return Service.GetOrganizations().Select(o => CreateOrganizationModel(o)).ToArray();
        }

        public void InitializeFeature()
        {
            Reset();
        }

        public void RemoveOrganization(IOrganization organization)
        {
            Service.RemoveOrganization(organization);
            Commit();
        }

        #endregion

        #region Helper Methods

        private OrganizationModel CreateOrganizationModel(IOrganization organization)
        {
            OrganizationModel organizationModel = new OrganizationModel();
            organizationModel.CopyFrom(organization);
            return organizationModel;
        }

        #endregion

    }
}
