using System.Text;

namespace Ttu.Domain
{
    public class User : IUser
    {

        #region Constructors

        public User()
            : this(string.Empty)
        {
        }

        public User(string userId)
        {
            UserId = userId;

            EmailAddress = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            PasswordEncrypted = string.Empty;
            RecordId = 0;
        }

        #endregion

        #region Properties

        public virtual string EmailAddress { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string PasswordEncrypted { get; set; }

        public virtual int RecordId { get; set; }

        public virtual string UserId { get; set; }

        #endregion

        #region Public Methods

        public virtual string GetFullName()
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(FirstName))
            {
                sb.Append(FirstName);
            }
            if (!string.IsNullOrWhiteSpace(LastName))
            {
                sb.Append(" ");
                sb.Append(LastName);
            }

            return sb.ToString();
        }

        public virtual bool IsValid()
        {
            return true;
        }

        public virtual bool MatchesPassword(string password)
        {
            return PasswordEncrypted == new Cipher().Encrypt(password);
        }

        public virtual void SetPassword(string password)
        {
            PasswordEncrypted = new Cipher().Encrypt(password);
        }

        #endregion

    }
}
