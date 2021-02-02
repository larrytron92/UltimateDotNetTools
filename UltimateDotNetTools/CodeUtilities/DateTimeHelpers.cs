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

        public static long ToFileTimeUtc(this DateTime? value, bool setToUtcNowOnNull = true)
        {
            if (value.HasValue)
            {
                return value.Value.ToFileTime();
            }
            
            return setToUtcNowOnNull ? DateTime.UtcNow.ToFileTime() : DateTime.MinValue.ToFileTime();
        }

        public static DateTime LastSecondOfTheDay(this DateTime? value, bool setToNowOnNull = true)
        {
            if (value.HasValue)
            {
                return value.Value.LastSecondOfTheDay();
            }

            return setToNowOnNull ? DateTime.Now.LastSecondOfTheDay() : DateTime.MinValue.LastSecondOfTheDay();
        }

        public static DateTime LastSecondOfTheDayUtc(this DateTime? value, bool setToUtcNowOnNull = true)
        {
            if (value.HasValue)
            {
                return value.Value.LastSecondOfTheDay();
            }

            return setToUtcNowOnNull ? DateTime.UtcNow.LastSecondOfTheDay() : DateTime.MinValue.LastSecondOfTheDay();
        }

        public static DateTime LastSecondOfTheDay(this DateTime value) => new DateTime(value.Year, value.Month, value.Day, 23, 59, 59, 59);

        public static DateTime Noon(this DateTime? value, bool setToNowOnNull = true)
        {
            if (value.HasValue)
            {
                return value.Value.Noon();
            }

            return setToNowOnNull ? DateTime.Now.Noon() : DateTime.MinValue.Noon();
        }

        public static DateTime NoonUtc(this DateTime? value, bool setToUtcNowOnNull = true)
        {
            if (value.HasValue)
            {
                return value.Value.Noon();
            }

            return setToUtcNowOnNull ? DateTime.UtcNow.Noon() : DateTime.MinValue.Noon();
        }

        public static DateTime Noon(this DateTime value) => new DateTime(value.Year, value.Month, value.Day, 12, 0, 0);

        public static bool IsValidValue(this DateTime? value) => value.GetValueOrDefault() != default(DateTime);

        public static bool HasNotExpired(this DateTime? value, bool dateOnly = false) => value.GetValueOrDefault().HasNotExpired(dateOnly);

        public static bool HasNotExpiredUtc(this DateTime? value, bool dateOnly = false) => value.GetValueOrDefault().HasNotExpiredUtc(dateOnly);

        public static bool HasExpired(this DateTime? value, bool dateOnly = false) => value.GetValueOrDefault().HasExpired(dateOnly);

        public static bool HasExpiredUtc(this DateTime? value, bool dateOnly = false) => value.GetValueOrDefault().HasExpiredUtc(dateOnly);

        public static bool IsToday(this DateTime? value) => value.GetValueOrDefault().IsToday();

        public static bool IsTodayUtc(this DateTime? value) => value.GetValueOrDefault().IsTodayUtc();

        public static bool HasNotExpired(this DateTime value, bool dateOnly = false) => dateOnly ? value.Date >= DateTime.Now.Date : value >= DateTime.Now;

        public static bool HasNotExpiredUtc(this DateTime value, bool dateOnly = false) => dateOnly ? value.Date >= DateTime.UtcNow.Date : value >= DateTime.UtcNow;

        public static bool HasExpired(this DateTime value, bool dateOnly = false) => dateOnly ? value.Date < DateTime.Now.Date : value < DateTime.Now;

        public static bool HasExpiredUtc(this DateTime value, bool dateOnly = false) => dateOnly ? value.Date < DateTime.UtcNow.Date : value < DateTime.UtcNow;

        public static bool IsToday(this DateTime value) => value.Date == DateTime.Now.Date;

        public static bool IsTodayUtc(this DateTime value) => value.Date == DateTime.UtcNow.Date;

        public static DateTime BeginningOfTheYear(this DateTime value) => new DateTime(DateTime.Now.Year, 1, 1);

        public static DateTime BeginningOfTheYearUtc(this DateTime value) => new DateTime(DateTime.UtcNow.Year, 1, 1);

        public static DateTime EndOfTheYear(this DateTime value) => new DateTime(DateTime.Now.Year, 12, 31, 23, 59, 59, 999);

        public static DateTime EndOfTheYearUtc(this DateTime value) => new DateTime(DateTime.UtcNow.Year, 12, 31, 23, 59, 59, 999);
    }
}