namespace Ttu.Domain
{
    public interface IOrganizationUserService
    {
        void AddOrganizationUser(IOrganizationUser organizationUser);

        IOrganizationUser GetOrganizationUser(int recordId);
        IOrganizationUser GetOrganizationUser(int organizationId, int userId); 
        int GetOrganizationUserRole(int organizationId, int userId);
        IOrganizationUser[] GetOrganizationUsers();
        IOrganizationUser[] GetOrganizationUsers(int organizationId);

        void RemoveOrganizationUser(int recordId);
        void RemoveOrganizationUser(int organizationId, int userId);
    }
}
