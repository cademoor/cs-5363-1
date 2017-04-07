using System.ComponentModel.DataAnnotations;
using Ttu.Domain;

namespace Ttu.Presentation
{
    public class OrganizationUserModel
    {

        #region Constructors

        public OrganizationUserModel()
        {

            OrganizationCreator = false;
            OrganizationId = 0;
            OrganizationRole = 0;
            RecordId = 0;
            UserId = 0;
        }

        #endregion

        #region Properties

        
        [Display(Name = "OrganizationCreator")]
        public bool OrganizationCreator { get; set; }

        [Required]
        [Display(Name = "OrganizationId")]
        public int OrganizationId { get; set; }

        [Display(Name = "OrganizationRole")]
        public int OrganizationRole { get; set; }

        public int RecordId { get; set; }

        [Required]
        [Display(Name = "UserId")]
        public int UserId { get; set; }

        #endregion

        #region Public Methods

        public void ApplyTo(IOrganizationUser organizationUser)
        {
            organizationUser.OrganizationCreator = OrganizationCreator;
            organizationUser.OrganizationId = OrganizationId;
            organizationUser.OrganizationRole = OrganizationRole;
            organizationUser.UserId = UserId;
        }

        public void CopyFrom(IOrganizationUser organizationUser)
        {
            OrganizationCreator = organizationUser.OrganizationCreator;
            OrganizationId = organizationUser.OrganizationId;
            OrganizationRole = organizationUser.OrganizationRole;
            RecordId = organizationUser.RecordId;
            UserId = organizationUser.UserId;
        }

        #endregion

    }
}
