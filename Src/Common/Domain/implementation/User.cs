using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Ttu.Domain
{
    public class User : IUser
    {

        # region Constructors

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
            Password = string.Empty;
            RecordId = 0;
        }

        # endregion

        # region Properties

        public virtual string EmailAddress { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Password { get; set; }

        public virtual int RecordId { get; set; }

        public virtual string UserId { get; set; }

        # endregion

        # region Public Methods

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
            return Password == password;
        }

        # endregion

    }
}
