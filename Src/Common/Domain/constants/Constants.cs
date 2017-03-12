namespace Ttu.Domain
{
    public class Constants
    {

        // constant values change here must also be changed in the hbm file for that entity...be careful using a value LESS than original

        public const string COOKIE_NAME = "ttu.volunteer.me";

        public const string USER_ID_ADMIN = "ADMIN";

        public const int USER_ID_MAX_LENGTH = 50;
        public const int USER_ID_MIN_LENGTH = 1;

        public const int USER_PASSWORD_MAX_LENGTH = 50;
        public const int USER_PASSWORD_MIN_LENGTH = 1;

        public const int VOLUNTEER_PROFILE_DESCRIPTION_MAX_LENGTH = 500;
        public const int VOLUNTEER_PROFILE_DESCRIPTION_MIN_LENGTH = 1;
        public const int VOLUNTEER_PROFILE_NAME_MAX_LENGTH = 50;
        public const int VOLUNTEER_PROFILE_NAME_MIN_LENGTH = 1;

    }

    public enum InputType : int
    {
        None = 0,
        Alpha = 1,
        NumericWithoutDecimal = 2,
        NumericWithDecimal = 3,
        AlphaNumericWithoutDecimal = 4,
        AlphaNumericWithDecimal = 5,
        AlphaNumericWithSymbols = 6,
    }

    public enum ContactType : int
    {
        None = 0,
        HomePhone = 1,
        MobilePhone = 2,
    }

}
