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
            OrganizationService = CreateOrganizationService();
            Service = CreateOrganizationUserService();
            UserService = CreateUserService();
        }

        #endregion

        #region Properties

        private IOrganizationService OrganizationService { get; set; }
        private IOrganizationUserService Service { get; set; }
        private IUserService UserService { get; set; }

        #endregion

        #region Public Methods

        public void AddOrganizationUser(OrganizationUserModel organizationUserModel)
        {
            // guard clause - invalid input
            if (organizationUserModel == null)
            {
                return;
            }

            IOrganization organization = OrganizationService.GetOrganization(organizationUserModel.OrganizationId);
            IUser user = UserService.GetUser(organizationUserModel.UserId);

            IOrganizationUser organizationUser = new OrganizationUser(organization, user);
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

        public OrganizationUserModel[] GetOrganizationUsers()
        {
            return Service.GetOrganizationUsers().Select(o => CreateOrganizationUserModel(o)).ToArray();
        }

        public OrganizationUserModel[] GetOrganizationUsers(int organizationRecordId)
        {
            IOrganization organization = OrganizationService.GetOrganization(organizationRecordId);
            return Service.GetOrganizationUsers(organization).Select(o => CreateOrganizationUserModel(o)).ToArray();
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