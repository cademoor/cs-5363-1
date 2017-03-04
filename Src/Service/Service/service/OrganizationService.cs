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

        public virtual void AddOrganization(IOrganization user)
        {
            UnitOfWork.Organizations.Add(user);
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
            IOrganization user = GetOrganization(recordId);
            if (user == null)
            {
                return;
            }

            UnitOfWork.Organizations.Remove(user);
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
