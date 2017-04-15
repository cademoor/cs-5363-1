using Ttu.Domain;

namespace Ttu.Service
{
    public class OrganizationUserService : AbstractService, IOrganizationUserService
    {


        #region Constructors

        public OrganizationUserService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region Public Methods

        public virtual void AddOrganizationUser(IOrganizationUser organizationUser)
        {
            UnitOfWork.OrganizationUsers.Add(organizationUser);
        }

        public virtual IOrganizationUser[] GetOrganizationUsers(IOrganization organization)
        {
            return UnitOfWork.OrganizationUsers.FindBy(o => o.Organization == organization);
        }

        public virtual IOrganizationUser GetOrganizationUser(int recordId)
        {
            return UnitOfWork.OrganizationUsers.FindByRecordId(recordId);
        }

        public virtual IOrganizationUser[] GetOrganizationUsers()
        {
            return UnitOfWork.OrganizationUsers.FindAll();
        }

        public virtual void RemoveOrganizationUser(int recordId)
        {
            IOrganizationUser organizationUser = GetOrganizationUser(recordId);
            if (organizationUser == null)
            {
                return;
            }

            UnitOfWork.OrganizationUsers.Remove(organizationUser);
        }

        #endregion

    }
}
