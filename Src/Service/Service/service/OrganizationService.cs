using Ttu.Domain;

namespace Ttu.Service
{
    public class OrganizationService : AbstractService, IOrganizationService
    {

        #region Constructors

        public OrganizationService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region Public Methods

        public virtual void AddOrganization(IOrganization organization)
        {
            UnitOfWork.Organizations.Add(organization);
        }

        public virtual IOrganization GetOrganization(int recordId)
        {
            return UnitOfWork.Organizations.FindByRecordId(recordId);
        }

        public virtual IOrganization[] GetOrganizations()
        {
            return UnitOfWork.Organizations.FindAll();
        }

        public virtual IOrganization[] GetOrganizations(IUser createdByUser)
        {
            return UnitOfWork.Organizations.FindBy(c => c.CreatedBy == createdByUser);
        }

        public virtual void RemoveOrganization(int recordId)
        {
            // guard clause - not found
            IOrganization organization = GetOrganization(recordId);
            if (organization == null)
            {
                return;
            }

            IOrganizationUser[] organizationUsers = UnitOfWork.OrganizationUsers.FindBy(ou => ou.Organization == organization);
            UnitOfWork.OrganizationUsers.RemoveAll(organizationUsers);

            IProject[] projects = UnitOfWork.Projects.FindBy(ou => ou.Organization == organization);
            UnitOfWork.Projects.RemoveAll(projects);

            UnitOfWork.Organizations.Remove(organization);
        }

        public virtual void RemoveOrganization(IOrganization createdByUser)
        {
            // guard clause - invalid input
            if (createdByUser == null)
            {
                return;
            }

            RemoveOrganization(createdByUser.RecordId);
        }

        #endregion

    }
}
