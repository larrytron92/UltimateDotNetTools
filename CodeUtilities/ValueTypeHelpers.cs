using System;

namespace UltimateDotNetTools
{
    public static class ValueTypeHelpers
    {
        #region Integer
        public static bool IsValidValue(this int? value) => value.HasValue && value.Value != default;

        public static bool IsValidAndAboveZero(this int? value) => value.HasValue && value.Value > default(int);

        public static bool IsValidAndBelowZero(this int? value) => value.HasValue && value.Value < default(int);

        public static bool IsValidAndAbove(this int? value, int min) => value.HasValue && value.Value > min;

        public static bool IsValidAndBelow(this int? value, int max) => value.HasValue && value.Value < max;

        public static bool IsValidAndMatches(this int? value, int number) => value.HasValue && value.Value == number;
        #endregion

        #region Guid
        public static bool IsValidValue(this Guid? value) => value.HasValue && value.Value != default;

        public static bool IsEmptyGuid(this Guid value) => value == default;

        public static bool NotEmptyGuid(this Guid value) => value != default;
        #endregion

        #region Double
        public static bool IsValidValue(this double? value) => value.HasValue && value.Value != default;

        public static bool IsValidAndAboveZero(this double? value) => value.HasValue && value.Value > default(double);

        public static bool IsValidAndBelowZero(this double? value) => value.HasValue && value.Value < default(double);

        public static bool IsValidAndAbove(this double? value, double min) => value.HasValue && value.Value > min;

        public static bool IsValidAndBelow(this double? value, double max) => value.HasValue && value.Value < max;

        public static bool IsValidAndMatches(this double? value, double number) => value.HasValue && value.Value == number;
        #endregion

        #region Float
        public static bool IsValidValue(this float? value) => value.HasValue && value.Value != default;

        public static bool IsValidAndAboveZero(this float? value) => value.HasValue && value.Value > default(float);

        public static bool IsValidAndBelowZero(this float? value) => value.HasValue && value.Value < default(float);

        public static bool IsValidAndAbove(this float? value, float min) => value.HasValue && value.Value > min;

        public static bool IsValidAndBelow(this float? value, float max) => value.HasValue && value.Value < max;

        public static bool IsValidAndMatches(this float? value, float number) => value.HasValue && value.Value == number;
        #endregion

        #region Boolean
        public static bool IsValidValue(this bool? value) => value.HasValue && value.Value;
        #endregion

        #region Decimal
        public static bool IsValidValue(this decimal? value) => value.HasValue && value.Value != default;

        public static bool IsValidAndAboveZero(this decimal? value) => value.HasValue && value.Value > default(decimal);

        public static bool IsValidAndBelowZero(this decimal? value) => value.HasValue && value.Value < default(decimal);

        public static bool IsValidAndAbove(this decimal? value, decimal min) => value.HasValue && value.Value > min;

        public static bool IsValidAndBelow(this decimal? value, decimal max) => value.HasValue && value.Value < max;

        public static bool IsValidAndMatches(this decimal? value, decimal number) => value.HasValue && value.Value == number;
        #endregion
    }
}