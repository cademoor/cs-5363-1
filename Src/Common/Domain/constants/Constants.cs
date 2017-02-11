namespace Ttu.Domain
{
    public class Constants
    {

        public const int USER_PASSWORD_MAX_LENGTH = 50;
        public const int USER_PASSWORD_MIN_LENGTH = 1;

        public const int USER_ID_MAX_LENGTH = 50;
        public const int USER_ID_MIN_LENGTH = 1;

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

}
