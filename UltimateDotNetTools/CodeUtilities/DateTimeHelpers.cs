using System;

namespace UltimateDotNetTools
{
    public static class DateTimeHelpers
    {
        public static long ToFileTime(this DateTime? value, bool setToNowOnNull = true)
        {
            if (value.HasValue)
            {
                return value.Value.ToFileTime();
            }
            
            return setToNowOnNull ? DateTime.Now.ToFileTime() : DateTime.MinValue.ToFileTime();
        }

        public static DateTime LastSecondOfTheDay(this DateTime? value, bool setToNowOnNull = true)
        {
            if (value.HasValue)
            {
                return value.Value.LastSecondOfTheDay();
            }

            return setToNowOnNull ? DateTime.Now.LastSecondOfTheDay() : DateTime.MinValue.LastSecondOfTheDay();
        }

        public static DateTime LastSecondOfTheDay(this DateTime value) => value.Date + new TimeSpan(23, 59, 59);

        public static DateTime Noon(this DateTime? value, bool setToNowOnNull = true)
        {
            if (value.HasValue)
            {
                return value.Value.Noon();
            }

            return setToNowOnNull ? DateTime.Now.Noon() : DateTime.MinValue.Noon();
        }

        public static DateTime Noon(this DateTime value) => value.Date + new TimeSpan(12, 0, 0);

        public static bool IsValidValue(this DateTime? value) => value.HasValue && value.Value != default(DateTime);

        public static bool IsValidBeforeToday(this DateTime? value, bool dateOnly = false) => value.HasValue ? value.Value.IsValidBeforeToday() : false;

        public static bool IsValidAfterToday(this DateTime? value, bool dateOnly = false) => value.HasValue ? value.Value.IsValidAfterToday(dateOnly) : false;

        public static bool IsValidToday(this DateTime? value) => value.HasValue && value.Value.IsValidToday();

        public static bool IsValidBeforeToday(this DateTime value, bool dateOnly = false) => dateOnly ? value.Date > DateTime.Now.Date : value > DateTime.Now;

        public static bool IsValidAfterToday(this DateTime value, bool dateOnly = false) => dateOnly ? value.Date < DateTime.Now.Date : value < DateTime.Now;

        public static bool IsValidToday(this DateTime value) => value.Date == DateTime.Now.Date;
    }
}