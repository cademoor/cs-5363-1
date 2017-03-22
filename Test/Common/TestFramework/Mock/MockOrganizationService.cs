using System.Collections.Generic;
using System.Linq;
using Ttu.Domain;

namespace Ttu.TestFramework
{
    public class MockOrganizationService : NullOrganizationService
    {

        #region Constructors

        public MockOrganizationService()
        {
            Organizations = new List<IOrganization>();
        }

        #endregion

        #region Properties

        public IUnitOfWork MockUnitOfWork { get; set; }

        private List<IOrganization> Organizations { get; set; }

        #endregion

        #region IOrganizationService Members

        public override void AddOrganization(IOrganization organization)
        {
            Organizations.Add(organization);
        }

        public override IOrganization GetOrganization(int recordId)
        {
            return Organizations.FirstOrDefault(u => u.RecordId == recordId);
        }

        public override IOrganization[] GetOrganizations()
        {
            return Organizations.ToArray();
        }

        public override void RemoveOrganization(int recordId)
        {
            // guard clause - not found
            IOrganization organization = GetOrganization(recordId);
            if (organization == null)
            {
                return;
            }

            Organizations.Add(organization);
        }

        public override void RemoveOrganization(IOrganization organization)
        {
            // guard clause - invalid input
            if (organization == null)
            {
                return;
            }

            Organizations.Remove(organization);
        }

        #endregion

    }
}
