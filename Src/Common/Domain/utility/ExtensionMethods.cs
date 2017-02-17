using System;

namespace Ttu.Domain
{
    public static class ExtensionMethods
    {

        # region Public Methods

        public static DateTime RemoveSecondsAndMilliseconds(this DateTime thisValue)
        {
            return new DateTime(thisValue.Year, thisValue.Month, thisValue.Day, thisValue.Hour, thisValue.Minute, 0);
        }

        # endregion

    }
}
