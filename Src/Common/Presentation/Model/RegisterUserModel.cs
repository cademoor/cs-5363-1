using System;
using System.ComponentModel.DataAnnotations;
using Ttu.Domain;

namespace Ttu.Presentation
{
    public class RegisterUserModel
    {

        #region Constructors

        public RegisterUserModel()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Password1 = string.Empty;
            Password2 = string.Empty;
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

        [Required]
        [StringLength(Constants.USER_PASSWORD_MAX_LENGTH, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Constants.USER_PASSWORD_MIN_LENGTH)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password1 { get; set; }

        [Required]
        [StringLength(Constants.USER_PASSWORD_MAX_LENGTH, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Constants.USER_PASSWORD_MIN_LENGTH)]
        [DataType(DataType.Password)]
        [Display(Name = "Re-enter Password")]
        public string Password2 { get; set; }

        [Required]
        [StringLength(Constants.USER_ID_MAX_LENGTH, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Constants.USER_ID_MIN_LENGTH)]
        [DataType(DataType.Text)]
        [Display(Name = "User ID")]
        public string UserId { get; set; }

        #endregion

        #region Public Methods

        public void ApplyTo(IUser user)
        {
            Validate();

            user.FirstName = FirstName;
            user.LastName = LastName;
            user.UserId = UserId;
            user.SetPassword(Password1);
        }

        public void CopyFrom(IUser user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserId = user.UserId;
        }

        #endregion

        #region Helper Methods

        private void Validate()
        {
            if (Password1 == Password2)
            {
                return;
            }

            throw new Exception("Passwords to not match.");
        }

        #endregion

    }
}
