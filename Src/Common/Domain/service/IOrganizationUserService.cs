namespace Ttu.Domain
{
    public interface IOrganizationUserService
    {

        void AddOrganizationUser(IOrganizationUser organizationUser);

        IOrganizationUser GetOrganizationUser(int recordId);
        IOrganizationUser[] GetOrganizationUsers();
        IOrganizationUser[] GetOrganizationUsers(IOrganization organization);

        void RemoveOrganizationUser(int recordId);

    }
}
