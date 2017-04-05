namespace Ttu.Domain
{
    public class NullOrganizationUserService : IOrganizationUserService
    {

        public static IOrganizationUserService Singleton = new NullOrganizationUserService();

        #region Constructors

        protected NullOrganizationUserService()
        {
        }

        #endregion

        #region Public Methods

        public virtual void AddOrganizationUser(IOrganizationUser organizationUser)
        {
            // do nothing
        }
        public virtual IOrganizationUser GetOrganizationUser(int recordId)
        {
            return null;

        }
        public virtual IOrganizationUser GetOrganizationUser(int organizationId, int userId)
        {
            return null; 
        }
        public virtual int GetOrganizationUserRole(int organizationId, int userId)
        {
            return -1; 
        }
        public virtual IOrganizationUser[] GetOrganizationUsers()
        {
            return new IOrganizationUser[0];
        }
        public virtual IOrganizationUser[] GetOrganizationUsers(int organizationId)
        {
            return new IOrganizationUser[0];
        }

        public virtual void RemoveOrganizationUser(int recordId)
        {
            // do nothing
        }
        public virtual void RemoveOrganizationUser(int organizationId, int userId)
        {
            // do nothing
        }
        #endregion

    }
}
