using System.ComponentModel.DataAnnotations;
using Ttu.Domain;

namespace Ttu.Presentation.Model
{
    public class LogOnModel
    {

        [Required]
        [StringLength(Constants.USER_PASSWORD_MAX_LENGTH, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Constants.USER_PASSWORD_MIN_LENGTH)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [StringLength(Constants.USER_ID_MAX_LENGTH, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Constants.USER_ID_MIN_LENGTH)]
        [DataType(DataType.Text)]
        [Display(Name = "User ID")]
        public string UserId { get; set; }

    }
}
