using System.Linq;
using Ttu.Domain;

namespace Ttu.TestFramework
{
    public class MockOrganizationService : NullOrganizationService
    {

        #region Constructors

        public MockOrganizationService()
        {
            MockUnitOfWork = new MockUnitOfWork();
        }

        #endregion

        #region Properties

        public IUnitOfWork MockUnitOfWork { get; set; }

        #endregion

        #region IOrganizationService Members

        public override void AddOrganization(IOrganization organization)
        {
            IOrganization[] organizations = GetOrganizations();
            if (organizations.Length == 0)
            {
                organization.RecordId = 1;
            }
            else
            {
                organization.RecordId = organizations.Max(o => o.RecordId) + 1;
            }
            MockUnitOfWork.Organizations.Add(organization);
        }

        public override IOrganization GetOrganization(int recordId)
        {
            return MockUnitOfWork.Organizations.FindByRecordId(recordId);
        }

        public override IOrganization[] GetOrganizations()
        {
            return MockUnitOfWork.Organizations.FindAll();
        }

        public override void RemoveOrganization(int recordId)
        {
            // guard clause - not found
            IOrganization organization = GetOrganization(recordId);
            if (organization == null)
            {
                return;
            }

            MockUnitOfWork.Organizations.Remove(organization);
        }

        public override void RemoveOrganization(IOrganization organization)
        {
            // guard clause - invalid input
            if (organization == null)
            {
                return;
            }

            MockUnitOfWork.Organizations.Remove(organization);
        }

        #endregion

    }
}
