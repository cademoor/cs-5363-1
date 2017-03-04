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

        public void AddOrganization(IOrganization organization)
        {
            Service.AddOrganization(organization);
            Commit();
        }

        public IOrganization GetOrganization(int recordId)
        {
            return Service.GetOrganization(recordId);
        }

        public IOrganization[] GetOrganizations()
        {
            return Service.GetOrganizations();
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

    }
}
