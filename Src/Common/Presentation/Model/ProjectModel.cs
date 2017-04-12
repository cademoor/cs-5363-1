using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ttu.Domain;

namespace Ttu.Presentation
{
    public class ProjectModel
    {

        #region Constructors

        public ProjectModel()
        {
            ProjectName = string.Empty;
            ProjectDescription = string.Empty;
            StartTime = DateTime.Today;
            StopTime = DateTime.Today;
            RecordId = 0;
            MinimumVolunteers = 0;
            MaximumVolunteers = 0;
        }

        #endregion

        #region Properties

        [Required]
        [StringLength(Constants.PROJECT_MAX_LENGTH, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Constants.PROJECT_MIN_LENGTH)]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string ProjectName { get; set; }

        [Required]
        [StringLength(Constants.PROJECT_DESCRIPTION_MAX_LENGTH, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Constants.PROJECT_DESCIPTION_MIN_LENGTH)]
        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        public string ProjectDescription { get; set; }

        [Required]
        [Display(Name = "Start Date/Time")]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "End Date/Time")]
        public DateTime StopTime { get; set; }

        public int RecordId { get; set; }

        [Required]
        [Display(Name = "Volunteers Needed")]
        public int MinimumVolunteers { get; set; }

        [Display(Name = "Volunteer Limit")]
        public int MaximumVolunteers { get; set; }

        #endregion

        #region Public Methods

        public void ApplyTo(IProject project)
        {
            project.ProjectName = ProjectName;
            project.ProjectDescription = ProjectDescription;
            project.StartTime = StartTime;
            project.StopTime = StopTime;
            project.MinimumVolunteers = MinimumVolunteers;
            project.MaximumVolunteers = MaximumVolunteers;
        }

        public void CopyFrom(IProject project)
        {
            ProjectName = project.ProjectName;
            ProjectDescription = project.ProjectDescription;
            StartTime = project.StartTime;
            StopTime = project.StopTime;
            RecordId = project.RecordId;
            MinimumVolunteers = project.MinimumVolunteers;
            MaximumVolunteers = project.MaximumVolunteers;
        }

        #endregion

    }
}
