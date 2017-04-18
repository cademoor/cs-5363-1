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

        public int RecordId { get; set; }

        [Required]
        [Display(Name = "UserId")]
        public int UserId { get; set; }

        #endregion

        #region Public Methods

        public void ApplyTo(IOrganizationUser organizationUser)
        {
            // do nothing
        }

        public void CopyFrom(IOrganizationUser organizationUser)
        {
            OrganizationCreator = organizationUser.IsOrganizationCreator();
            OrganizationId = organizationUser.GetOrganizationRecordId();
            RecordId = organizationUser.RecordId;
            UserId = organizationUser.GetUserRecordId();
        }

        #endregion

    }
}
