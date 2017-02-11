using Ttu.Domain;

namespace Ttu.Presentation
{
    public class NullUser : IUser
    {

        public static IUser Singleton = new NullUser();

        # region Constructors

        private NullUser()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            RecordId = 0;
            UserId = string.Empty;
        }

        # endregion

        # region Properties

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RecordId { get; private set; }
        public string UserId { get; set; }

        # endregion

        # region Public Methods

        public bool IsValid()
        {
            return false;
        }

        # endregion

    }
}
