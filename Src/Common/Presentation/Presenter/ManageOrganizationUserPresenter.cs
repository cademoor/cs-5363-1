using System.Linq;
using Ttu.Domain;

namespace Ttu.Presentation
{
    public class ManageOrganizationUserPresenter : AbstractPresenter
    {
        #region Constructors

        public ManageOrganizationUserPresenter(ManageOrganizationUserViewState viewState)
            : base(viewState)
        {
            Service = CreateOrganizationUserService();
        }

        #endregion

        #region Properties

        private IOrganizationUserService Service { get; set; }

        #endregion

        #region Public Methods

        public void AddOrganizationUser(OrganizationUserModel organizationUserModel)
        {
            // guard clause - invalid input
            if (organizationUserModel == null)
            {
                return;
            }

            IOrganizationUser organizationUser = new OrganizationUser(organizationUserModel.OrganizationId,
                organizationUserModel.UserId);
            organizationUserModel.ApplyTo(organizationUser);

            Service.AddOrganizationUser(organizationUser);
            Commit();
        }

        public OrganizationUserModel GetOrganizationUser(int recordId)
        {
            // guard clause - not found
            IOrganizationUser organizationUser = Service.GetOrganizationUser(recordId);
            if (organizationUser == null)
            {
                return null;
            }

            return CreateOrganizationUserModel(organizationUser);
        }

        public virtual OrganizationUserModel GetOrganizationUser(int organizationId, int userId)
        {
            // guard clause - not found
            IOrganizationUser organizationUser = Service.GetOrganizationUser(organizationId, userId);
            if (organizationUser == null)
            {
                return null;
            }

            return CreateOrganizationUserModel(organizationUser);
        }

        public virtual int GetOrganizationUserRole(int organizationId, int userId)
        {
            return
                UnitOfWork.OrganizationUsers.FindByUnique(o => o.OrganizationId == organizationId && o.UserId == userId)
                    .OrganizationRole;
        }

        public OrganizationUserModel[] GetOrganizationUsers()
        {
            return Service.GetOrganizationUsers().Select(o => CreateOrganizationUserModel(o)).ToArray();
        }

        public OrganizationUserModel[] GetOrganizationUsers(int organizationId)
        {
            return Service.GetOrganizationUsers(organizationId).Select(o => CreateOrganizationUserModel(o)).ToArray();
        }

        public void RemoveOrganizationUser(OrganizationUserModel organizationUserModel)
        {
            // guard clause - invalid input
            if (organizationUserModel == null)
            {
                return;
            }

            Service.RemoveOrganizationUser(organizationUserModel.RecordId);
            Commit();
        }

        #endregion

        #region Helper Methods

        private OrganizationUserModel CreateOrganizationUserModel(IOrganizationUser organizationUser)
        {
            OrganizationUserModel organizationUserModel = new OrganizationUserModel();
            organizationUserModel.CopyFrom(organizationUser);
            return organizationUserModel;
        }

        #endregion
    }
}