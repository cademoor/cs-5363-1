namespace Ttu.Domain
{
    public class Constants
    {

        // constant values change here must also be changed in the hbm file for that entity...be careful using a value LESS than original

        public const string COOKIE_NAME = "ttu.volunteer.me";

        public const string USER_ID_ADMIN = "ADMIN";

        public const int ORGANIZATION_MAX_LENGTH = 500;
        public const int ORGANIZATION_MIN_LENGTH = 1;

        public const int USER_FIRST_NAME_MAX_LENGTH = 50;
        public const int USER_FIRST_NAME_MIN_LENGTH = 1;

        public const int USER_ID_MAX_LENGTH = 50;
        public const int USER_ID_MIN_LENGTH = 1;

        public const int USER_LAST_NAME_MAX_LENGTH = 50;
        public const int USER_LAST_NAME_MIN_LENGTH = 1;

        public const int USER_PASSWORD_MAX_LENGTH = 50;
        public const int USER_PASSWORD_MIN_LENGTH = 1;

        public const int VOLUNTEER_PROFILE_DESCRIPTION_MAX_LENGTH = 500;
        public const int VOLUNTEER_PROFILE_DESCRIPTION_MIN_LENGTH = 0;
        public const int VOLUNTEER_PROFILE_LOCATION_MAX_LENGTH = 200;
        public const int VOLUNTEER_PROFILE_LOCATION_MIN_LENGTH = 0;
        public const int VOLUNTEER_PROFILE_NAME_MAX_LENGTH = 50;
        public const int VOLUNTEER_PROFILE_NAME_MIN_LENGTH = 1;

        public const int PROJECT_MIN_LENGTH = 1;
        public const int PROJECT_MAX_LENGTH = 100;
        public const int PROJECT_DESCRIPTION_MIN_LENGTH = 1;
        public const int PROJECT_DESCRIPTION_MAX_LENGTH = 1000;

    }

    public enum ContactType : int
    {
        None = 0,
        HomePhone = 1,
        MobilePhone = 2,
    }

}
