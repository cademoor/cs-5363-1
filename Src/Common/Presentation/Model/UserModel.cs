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

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public int RecordId { get; set; }

        [Display(Name = "User ID")]
        public string UserId { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        #endregion

        #region Public Methods

        public void ApplyTo(IUser user)
        {
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.UserId = UserId;
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
