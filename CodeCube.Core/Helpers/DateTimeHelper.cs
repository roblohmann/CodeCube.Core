using System;
using CodeCube.Core.Enumerations;

namespace CodeCube.Core.Helpers
{
    public sealed class DateTimeHelper
    {
        /// <summary>
        /// Gets the localized datetime.
        /// </summary>
        /// <remarks>Currently only working for W. Europe Standard Time!</remarks>
        /// <returns>Datetime object, localized.</returns>
        public static DateTime DateTimeNow(EDateTimeRegion datetimeRegion)
        {
            switch (datetimeRegion)
            {
                case EDateTimeRegion.WesternEurope:
                    return DateTimeLocal_NL(DateTime.Now);
                default:
                    throw new Exception("Unknown datetime region.");
            }
        }

        #region private methods
        private static DateTime DateTimeLocal_NL(DateTime dateTime)
        {
            return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dateTime, "W. Europe Standard Time");
        }
        #endregion
    }
}
