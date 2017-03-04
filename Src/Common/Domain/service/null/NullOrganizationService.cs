namespace Ttu.Domain
{
    public class NullOrganizationService : IOrganizationService
    {

        public static IOrganizationService Singleton = new NullOrganizationService();

        #region Constructors

        protected NullOrganizationService()
        {
        }

        #endregion

        #region Public Methods

        public virtual void AddOrganization(IOrganization organization)
        {
            // do nothing
        }

        public virtual IOrganization GetOrganization(int recordId)
        {
            return null;
        }

        public virtual IOrganization[] GetOrganizations()
        {
            return new IOrganization[0];
        }

        public virtual IOrganization[] GetOrganizations(IUser createdByUser)
        {
            return new IOrganization[0];
        }

        public virtual void RemoveOrganization(int recordId)
        {
            // do nothing
        }

        public virtual void RemoveOrganization(IOrganization createdByUser)
        {
            // do nothing
        }

        #endregion

    }
}
