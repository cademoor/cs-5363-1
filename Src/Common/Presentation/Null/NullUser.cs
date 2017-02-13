using Ttu.Domain;

namespace Ttu.Presentation
{
    public class NullUser : IUser
    {

        public static IUser Singleton = new NullUser();

        # region Constructors

        private NullUser()
        {
            _FirstName = string.Empty;
            _LastName = string.Empty;
            _Password = string.Empty;
            _RecordId = 0;
            _UserId = string.Empty;
        }

        # endregion

        # region Properties

        public string FirstName { get { return _FirstName; } set { } }
        public string LastName { get { return _LastName; } set { } }
        public string Password { get { return _Password; } set { } }
        public int RecordId { get { return _RecordId; } set { } }
        public string UserId { get { return _UserId; } set { } }

        # endregion

        # region Variables

        public string _FirstName;
        public string _LastName;
        public string _Password;
        public int _RecordId;
        public string _UserId;

        # endregion

        # region Public Methods

        public bool IsValid()
        {
            return false;
        }

        public bool MatchesPassword(string password)
        {
            return false;
        }

        # endregion

    }
}
