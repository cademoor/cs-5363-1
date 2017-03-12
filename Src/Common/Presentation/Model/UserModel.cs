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
            UserId = string.Empty;
        }

        #endregion

        #region Properties

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserId { get; set; }

        #endregion

        #region Public Methods

        public void CopyFrom(IUser user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserId = user.UserId;
        }

        #endregion

    }
}
