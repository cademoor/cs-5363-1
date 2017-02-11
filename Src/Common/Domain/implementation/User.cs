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
            FirstName = string.Empty;
            LastName = string.Empty;
            RecordId = 0;
            UserId = userId;
        }

        # endregion

        # region Properties

        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
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

        # endregion

    }
}
