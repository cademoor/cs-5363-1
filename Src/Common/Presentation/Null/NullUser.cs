using Ttu.Domain;

namespace Ttu.Presentation
{
    public class NullUser : IUser
    {

        public static IUser Singleton = new NullUser();

        #region Constructors

        private NullUser()
        {
            _EmailAddress = string.Empty;
            _FirstName = string.Empty;
            _LastName = string.Empty;
            _Password = string.Empty;
            _RecordId = 0;
            _UserId = string.Empty;
        }

        #endregion

        #region Properties

        public string EmailAddress { get { return _EmailAddress; } set { } }

        public string FirstName { get { return _FirstName; } set { } }

        public string LastName { get { return _LastName; } set { } }

        public string PasswordEncrypted { get { return _Password; } set { } }

        public int RecordId { get { return _RecordId; } set { } }

        public string UserId { get { return _UserId; } set { } }

        public string Location { get { return _Location; } set { } }

        public string Description { get { return _Description; } set { } }

        #endregion

        #region Variables

        public string _EmailAddress;
        public string _FirstName;
        public string _LastName;
        public string _Password;
        public int _RecordId;
        public string _UserId;
        public string _Location;
        public string _Description;

        #endregion

        #region Public Methods

        public virtual bool IsAdmin()
        {
            return false;
        }

        public virtual bool IsValid()
        {
            return false;
        }

        public virtual bool MatchesPassword(string password)
        {
            return false;
        }

        public virtual void SetPassword(string password)
        {
            // do nothing
        }

        #endregion

    }
}
