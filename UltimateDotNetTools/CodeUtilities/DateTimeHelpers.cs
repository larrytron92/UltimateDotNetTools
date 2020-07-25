using System;

namespace UltimateDotNetTools
{
    public static class DateTimeHelpers
    {
        public static long ToFileTime(this DateTime? value, bool nullMax = false)
        {
            if (value.HasValue)
            {
                return value.Value.ToFileTime();
            }

            if (nullMax)
            {
                return DateTime.MaxValue.ToFileTime();
            }
            
            return DateTime.MinValue.ToFileTime();
        }

        public static DateTime LastSecondOfTheDay(this DateTime value) => value.Date + new TimeSpan(23, 59, 59);

        public static DateTime Noon(this DateTime value) => value.Date + new TimeSpan(12, 0, 0);
    }
}