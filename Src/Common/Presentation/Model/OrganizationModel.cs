using System.ComponentModel.DataAnnotations;
using Ttu.Domain;

namespace Ttu.Presentation
{
    public class OrganizationModel
    {

        #region Constructors

        public OrganizationModel()
        {
            Description = string.Empty;
            MissionStatement = string.Empty;
            Name = string.Empty;
            RecordId = 0;
            Website = string.Empty;
        }

        #endregion

        #region Properties

        [Required]
        [StringLength(Constants.ORGANIZATION_MAX_LENGTH, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Constants.ORGANIZATION_MIN_LENGTH)]
        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public string MissionStatement { get; set; }
        public string Name { get; set; }
        public int RecordId { get; set; }
        public string Website { get; set; }

        #endregion

        #region Public Methods

        public void ApplyTo(IOrganization organization)
        {
            organization.Description = Description;
            organization.MissionStatement = MissionStatement;
            organization.Name = Name;
            organization.Website = Website;
        }

        public void CopyFrom(IOrganization organization)
        {
            Description = organization.Description;
            MissionStatement = organization.MissionStatement;
            Name = organization.Name;
            RecordId = organization.RecordId;
            Website = organization.Website;
        }

        #endregion

    }
}
