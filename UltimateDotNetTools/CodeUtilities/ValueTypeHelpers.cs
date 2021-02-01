using System;

namespace UltimateDotNetTools
{
    public static class ValueTypeHelpers
    {
        #region Integer
        public static bool IsValidValue(this int? value) => value.GetValueOrDefault() != default(int);

        public static bool IsValidAndAboveZero(this int? value) => value.IsValidAndAbove(default(int));

        public static bool IsValidAndBelowZero(this int? value) => value.IsValidAndBelow(default(int));

        public static bool IsValidAndAbove(this int? value, int min) => value.GetValueOrDefault() > min;

        public static bool IsValidAndBelow(this int? value, int max) => value.GetValueOrDefault() < max;

        public static bool IsValidAndMatches(this int? value, int number) => value.GetValueOrDefault() == number;

        public static bool IsValidAndMatches(this int? value, string number) => value.GetValueOrDefault() == number.MapJsonString<int>();
        #endregion

        #region Guid
        public static bool IsValidValue(this Guid? value) => value.GetValueOrDefault() != default(Guid);

        public static bool IsEmptyGuid(this Guid value) => value == default;

        public static bool NotEmptyGuid(this Guid value) => value != default;

        public static bool IsValidAndMatches(this Guid? value, Guid matching) => value.GetValueOrDefault() == matching;

        public static bool IsValidAndMatches(this Guid? value, string matching) => value.GetValueOrDefault() == matching.MapJsonString<Guid>();
        #endregion

        #region Double
        public static bool IsValidValue(this double? value) => value.GetValueOrDefault() != default(double);

        public static bool IsValidAndAboveZero(this double? value) => value.IsValidAndAbove(default(double));

        public static bool IsValidAndBelowZero(this double? value) => value.IsValidAndBelow(default(double));

        public static bool IsValidAndAbove(this double? value, double min) => value.GetValueOrDefault() > min;

        public static bool IsValidAndBelow(this double? value, double max) => value.GetValueOrDefault() < max;

        public static bool IsValidAndMatches(this double? value, double number) => value.GetValueOrDefault() == number;

        public static bool IsValidAndMatches(this double? value, string number) => value.GetValueOrDefault() == number.MapJsonString<double>();
        #endregion

        #region Float
        public static bool IsValidValue(this float? value) => value.GetValueOrDefault() != default(float);

        public static bool IsValidAndAboveZero(this float? value) => value.IsValidAndAbove(default(float));

        public static bool IsValidAndBelowZero(this float? value) => value.IsValidAndBelow(default(float));

        public static bool IsValidAndAbove(this float? value, float min) => value.GetValueOrDefault() > min;

        public static bool IsValidAndBelow(this float? value, float max) => value.GetValueOrDefault() < max;

        public static bool IsValidAndMatches(this float? value, float number) => value.GetValueOrDefault() == number;

        public static bool IsValidAndMatches(this float? value, string number) => value.GetValueOrDefault() == number.MapJsonString<float>();
        #endregion

        #region Boolean
        public static bool IsTrue(this bool? value) => value.GetValueOrDefault();
        #endregion

        #region Decimal
        public static bool IsValidValue(this decimal? value) => value.GetValueOrDefault() != default(decimal);

        public static bool IsValidAndAboveZero(this decimal? value) => value.IsValidAndAbove(default(decimal));

        public static bool IsValidAndBelowZero(this decimal? value) => value.IsValidAndBelow(default(decimal));

        public static bool IsValidAndAbove(this decimal? value, decimal min) => value.GetValueOrDefault() > min;

        public static bool IsValidAndBelow(this decimal? value, decimal max) => value.GetValueOrDefault() < max;

        public static bool IsValidAndMatches(this decimal? value, decimal number) => value.GetValueOrDefault() == number;

        public static bool IsValidAndMatches(this decimal? value, string number) => value.GetValueOrDefault() == number.MapJsonString<decimal>();
        #endregion
    }
}