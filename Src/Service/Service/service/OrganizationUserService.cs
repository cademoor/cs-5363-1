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

        public virtual IOrganizationUser[] GetOrganizationUsers(int organizationId)
        {
            return UnitOfWork.OrganizationUsers.FindBy(o => o.OrganizationId == organizationId); 
        }

        public virtual IOrganizationUser GetOrganizationUser(int recordId)
        {
            return UnitOfWork.OrganizationUsers.FindByRecordId(recordId); 
        }

        public virtual IOrganizationUser GetOrganizationUser(int organizationId, int userId)
        {
            return UnitOfWork.OrganizationUsers.FindByUnique(o => o.OrganizationId == organizationId && o.UserId == userId);
        }

        public virtual int GetOrganizationUserRole(int organizationId, int userId)
        {
            return UnitOfWork.OrganizationUsers.FindByUnique(o => o.OrganizationId == organizationId && o.UserId == userId).OrganizationRole; 
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

        public virtual void RemoveOrganizationUser(int organizationId, int userId)
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
