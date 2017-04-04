using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ttu.Domain
{
    public class OrganizationUser : IOrganizationUser
    {
        #region Constructors

        public OrganizationUser()
            : this(null, null)
        {
        }

        public OrganizationUser(Organization organization, User user)
        {
            Organization = organization;
            User = user;

            OrganizationCreator = false;
            OrganizationId = 0;
            OrganizationRole = 0;
            RecordId = 0;
            UserId = 0;
        }

        public OrganizationUser(int organizationId, int userId)
        {
            Organization = null;
            User = null;

            
            OrganizationCreator = false;
            OrganizationId = organizationId;
            OrganizationRole = 0;
            RecordId = 0;
            UserId = userId;
        }

        #endregion

        #region Properties



        public virtual IOrganization Organization { get; set; }

        public virtual bool OrganizationCreator { get; set; }
        public virtual int OrganizationId { get; set; }
        public virtual int OrganizationRole { get; set; }
        public virtual int RecordId { get; set; }
        public virtual IUser User { get; set; }
        public virtual int UserId { get; set; }

        #endregion


    }
}
