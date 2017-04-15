namespace Ttu.Domain
{
    public class OrganizationUser : IOrganizationUser
    {

        #region Constructors

        public OrganizationUser()
            : this(null, null)
        {
        }

        public OrganizationUser(IOrganization organization, IUser user)
        {
            Organization = organization;
            User = user;

            RecordId = 0;
        }

        #endregion

        #region Properties

        public virtual IOrganization Organization { get; set; }
        public virtual int RecordId { get; set; }
        public virtual IUser User { get; set; }

        #endregion

        #region Public Methods

        public virtual int GetOrganizationRecordId()
        {
            // guard clause - invalid state
            if (Organization == null)
            {
                return 0;
            }

            return Organization.RecordId;
        }

        public virtual int GetUserRecordId()
        {
            // guard clause - invalid state
            if (User == null)
            {
                return 0;
            }

            return User.RecordId;
        }

        public virtual bool IsOrganizationCreator()
        {
            // guard clause - invalid state
            if (Organization == null || User == null)
            {
                return false;
            }

            // guard clause - invalid state
            IUser organizationCreator = Organization.CreatedBy;
            if (organizationCreator == null)
            {
                return false;
            }

            return organizationCreator.RecordId == User.RecordId;
        }

        #endregion

    }
}
