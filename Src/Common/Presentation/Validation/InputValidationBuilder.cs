using Ttu.Domain;

namespace Ttu.Presentation
{
    public class InputValidationBuilder
    {

        #region Public Methods

        public string ValidateValue(string fieldName, string value, int minLength, int maxLength, InputType inputType)
        {
            string adjustedValue = value ?? string.Empty;

            bool valueViolatesInputType = ValueViolatesInputType(adjustedValue, inputType);
            bool valueViolatesMinLength = adjustedValue.Length < minLength;
            bool valueViolatesMaxLength = adjustedValue.Length > maxLength;
            if (valueViolatesInputType || valueViolatesMinLength || valueViolatesMaxLength)
            {
                return string.Format("The \"{0}\" must be between {1} and {2} characters{3}.", fieldName, minLength, maxLength, GetInputTypeValidationText(inputType));
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion

        #region Helper Methods

        private string GetInputTypeValidationText(InputType inputType)
        {
            switch (inputType)
            {
                case InputType.Alpha:
                    return " and must only contain letters";
                case InputType.AlphaNumericWithoutDecimal:
                    return " and must only contain letters or numbers";
                case InputType.AlphaNumericWithDecimal:
                    return " and must only contain letters or numbers or a decimal";
                case InputType.NumericWithoutDecimal:
                    return " and must only contain numbers";
                case InputType.NumericWithDecimal:
                    return " and must only contain numbers or a decimal";
                case InputType.AlphaNumericWithSymbols:
                case InputType.None:
                default:
                    return string.Empty;
            }
        }

        private bool IsAlpha(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsAlphaNumericWithDecimal(string value)
        {
            foreach (char c in value)
            {
                if (!IsLetterOrDigitOrDecimal(c))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsAlphaNumericWithoutDecimal(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsDigitOrDecimal(char c)
        {
            return char.IsDigit(c) || c == '.';
        }

        private bool IsLetterOrDigitOrDecimal(char c)
        {
            return char.IsLetterOrDigit(c) || c == '.';
        }

        private bool IsNumericWithDecimals(string value)
        {
            foreach (char c in value)
            {
                if (!IsDigitOrDecimal(c))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsNumericWithoutDecimals(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValueViolatesInputType(string value, InputType inputType)
        {
            switch (inputType)
            {
                case InputType.Alpha:
                    return !IsAlpha(value);
                case InputType.AlphaNumericWithoutDecimal:
                    return !IsAlphaNumericWithoutDecimal(value);
                case InputType.AlphaNumericWithDecimal:
                    return !IsAlphaNumericWithDecimal(value);
                case InputType.NumericWithoutDecimal:
                    return !IsNumericWithoutDecimals(value);
                case InputType.NumericWithDecimal:
                    return !IsNumericWithDecimals(value);
                case InputType.AlphaNumericWithSymbols:
                case InputType.None:
                default:
                    return false;
            }
        }

        #endregion

    }
}
