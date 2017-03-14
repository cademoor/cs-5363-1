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

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RecordId { get; set; }
        public string UserId { get; set; }

        #endregion

        #region Public Methods

        public void ApplyTo(IUser user)
        {
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.UserId = user.UserId;
        }

        public void CopyFrom(IUser user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            RecordId = user.RecordId;
            UserId = user.UserId;
        }

        #endregion

    }
}
