using System.Linq;
using Ttu.Domain;

namespace Ttu.TestFramework
{
    public class MockOrganizationUserService : NullOrganizationUserService
    {

        #region Constructors

        public MockOrganizationUserService()
        {
            MockUnitOfWork = new MockUnitOfWork();
        }

        #endregion

        #region Properties

        public IUnitOfWork MockUnitOfWork { get; set; }

        #endregion

        #region IOrganizationService Members

        public override void AddOrganizationUser(IOrganizationUser organization)
        {
            IOrganizationUser[] organizations = GetOrganizationUsers();
            if (organizations.Length == 0)
            {
                organization.RecordId = 1;
            }
            else
            {
                organization.RecordId = organizations.Max(o => o.RecordId) + 1;
            }
            MockUnitOfWork.OrganizationUsers.Add(organization);
        }

        public override IOrganizationUser GetOrganizationUser(int recordId)
        {
            return MockUnitOfWork.OrganizationUsers.FindByRecordId(recordId);
        }

        public override IOrganizationUser[] GetOrganizationUsers()
        {
            return MockUnitOfWork.OrganizationUsers.FindAll();
        }

        public override IOrganizationUser GetOrganizationUser(int organizationId, int userId)
        {
            return MockUnitOfWork.OrganizationUsers.FindByUnique(o => o.OrganizationId == organizationId && o.UserId == userId);
        }

        public override int GetOrganizationUserRole(int organizationId, int userId)
        {
            return MockUnitOfWork.OrganizationUsers.FindByUnique(o => o.OrganizationId == organizationId && o.UserId == userId).OrganizationRole;
        }


        public override void RemoveOrganizationUser(int recordId)
        {
            // guard clause - not found
            IOrganizationUser organization = GetOrganizationUser(recordId);
            if (organization == null)
            {
                return;
            }

            MockUnitOfWork.OrganizationUsers.Remove(organization);
        }

        public override void RemoveOrganizationUser(int organizationId, int userId)
        {
            IOrganizationUser organizationUser = GetOrganizationUser(organizationId, userId);
            if (organizationUser == null)
            {
                return;
            }

            RemoveOrganizationUser(organizationUser.RecordId);
        }

        #endregion

    }
}
