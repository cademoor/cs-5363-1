using System.ComponentModel.DataAnnotations;
using Ttu.Domain;

namespace Ttu.Presentation
{
    public class UserModel
    {

        #region Constructors

        public UserModel()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            RecordId = 0;
            UserId = string.Empty;
        }

        #endregion

        #region Properties

        [Required]
        [StringLength(Constants.USER_FIRST_NAME_MAX_LENGTH, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Constants.USER_FIRST_NAME_MIN_LENGTH)]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(Constants.USER_LAST_NAME_MAX_LENGTH, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Constants.USER_LAST_NAME_MIN_LENGTH)]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public int RecordId { get; set; }

        [Display(Name = "User ID")]
        public string UserId { get; set; }

        [StringLength(Constants.VOLUNTEER_PROFILE_LOCATION_MAX_LENGTH, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Constants.VOLUNTEER_PROFILE_LOCATION_MIN_LENGTH)]
        [DataType(DataType.Text)]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [StringLength(Constants.VOLUNTEER_PROFILE_DESCRIPTION_MAX_LENGTH, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Constants.VOLUNTEER_PROFILE_DESCRIPTION_MIN_LENGTH)]
        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        #endregion

        #region Public Methods

        public void ApplyTo(IUser user)
        {
            user.FirstName = FirstName;
            user.LastName = LastName;
            // It's possible we weren't initialized with a UserId.
            // In that case, don't force null/empty on the other guy
            if (!string.IsNullOrEmpty(UserId))
            {
                user.UserId = UserId;
            }
            user.Location = Location;
            user.Description = Description;
        }

        public void CopyFrom(IUser user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            RecordId = user.RecordId;
            UserId = user.UserId;
            Description = user.Description;
            Location = user.Location;
        }

        #endregion

    }
}
