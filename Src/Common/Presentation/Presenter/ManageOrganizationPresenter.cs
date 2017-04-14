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
            // guard clause - invalid input
            if (organizationModel == null)
            {
                return;
            }

            IOrganization organization = new Organization(User, organizationModel.Name);
            organizationModel.ApplyTo(organization);

            Service.AddOrganization(organization);
            Commit();
        }

        public OrganizationModel GetOrganization(int recordId)
        {
            // guard clause - not found
            IOrganization organization = Service.GetOrganization(recordId);
            if (organization == null)
            {
                return null;
            }

            return CreateOrganizationModel(organization);
        }

        public OrganizationModel[] GetOrganizations()
        {
            return Service.GetOrganizations().Select(o => CreateOrganizationModel(o)).ToArray();
        }

        public void RemoveOrganization(OrganizationModel organizationModel)
        {
            // guard clause - invalid input
            if (organizationModel == null)
            {
                return;
            }

            Service.RemoveOrganization(organizationModel.RecordId);
            Commit();
        }

        #endregion

    }
}
