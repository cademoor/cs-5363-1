namespace Ttu.Domain
{
    public interface IOrganizationService
    {

        void AddOrganization(IOrganization user);

        IOrganization GetOrganization(int recordId);
        IOrganization[] GetOrganizations();
        IOrganization[] GetOrganizations(IUser createdByUser);

        void RemoveOrganization(int recordId);
        void RemoveOrganization(IOrganization createdByUser);

    }
}
