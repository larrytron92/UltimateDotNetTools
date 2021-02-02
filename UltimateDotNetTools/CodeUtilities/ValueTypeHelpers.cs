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

        #region Long
        public static bool IsValidValue(this long? value) => value.GetValueOrDefault() != default(long);

        public static bool IsValidAndAboveZero(this long? value) => value.IsValidAndAbove(default(long));

        public static bool IsValidAndBelowZero(this long? value) => value.IsValidAndBelow(default(long));

        public static bool IsValidAndAbove(this long? value, long min) => value.GetValueOrDefault() > min;

        public static bool IsValidAndBelow(this long? value, long max) => value.GetValueOrDefault() < max;

        public static bool IsValidAndMatches(this long? value, long number) => value.GetValueOrDefault() == number;

        public static bool IsValidAndMatches(this long? value, string number) => value.GetValueOrDefault() == number.MapJsonString<long>();
        #endregion

        #region Byte
        public static bool IsValidValue(this byte? value) => value.GetValueOrDefault() != default(byte);

        public static bool IsValidAndAboveZero(this byte? value) => value.IsValidAndAbove(default(byte));

        public static bool IsValidAndBelowZero(this byte? value) => value.IsValidAndBelow(default(byte));

        public static bool IsValidAndAbove(this byte? value, byte min) => value.GetValueOrDefault() > min;

        public static bool IsValidAndBelow(this byte? value, byte max) => value.GetValueOrDefault() < max;

        public static bool IsValidAndMatches(this byte? value, byte number) => value.GetValueOrDefault() == number;

        public static bool IsValidAndMatches(this byte? value, string number) => value.GetValueOrDefault() == number.MapJsonString<byte>();
        #endregion

        #region SByte
        public static bool IsValidValue(this sbyte? value) => value.GetValueOrDefault() != default(sbyte);

        public static bool IsValidAndAboveZero(this sbyte? value) => value.IsValidAndAbove(default(sbyte));

        public static bool IsValidAndBelowZero(this sbyte? value) => value.IsValidAndBelow(default(sbyte));

        public static bool IsValidAndAbove(this sbyte? value, sbyte min) => value.GetValueOrDefault() > min;

        public static bool IsValidAndBelow(this sbyte? value, sbyte max) => value.GetValueOrDefault() < max;

        public static bool IsValidAndMatches(this sbyte? value, sbyte number) => value.GetValueOrDefault() == number;

        public static bool IsValidAndMatches(this sbyte? value, string number) => value.GetValueOrDefault() == number.MapJsonString<sbyte>();
        #endregion

        #region Ushort
        public static bool IsValidValue(this ushort? value) => value.GetValueOrDefault() != default(ushort);

        public static bool IsValidAndAboveZero(this ushort? value) => value.IsValidAndAbove(default(ushort));

        public static bool IsValidAndBelowZero(this ushort? value) => value.IsValidAndBelow(default(ushort));

        public static bool IsValidAndAbove(this ushort? value, ushort min) => value.GetValueOrDefault() > min;

        public static bool IsValidAndBelow(this ushort? value, ushort max) => value.GetValueOrDefault() < max;

        public static bool IsValidAndMatches(this ushort? value, ushort number) => value.GetValueOrDefault() == number;

        public static bool IsValidAndMatches(this ushort? value, string number) => value.GetValueOrDefault() == number.MapJsonString<ushort>();
        #endregion

        #region Uint
        public static bool IsValidValue(this uint? value) => value.GetValueOrDefault() != default(uint);

        public static bool IsValidAndAboveZero(this uint? value) => value.IsValidAndAbove(default(uint));

        public static bool IsValidAndBelowZero(this uint? value) => value.IsValidAndBelow(default(uint));

        public static bool IsValidAndAbove(this uint? value, uint min) => value.GetValueOrDefault() > min;

        public static bool IsValidAndBelow(this uint? value, uint max) => value.GetValueOrDefault() < max;

        public static bool IsValidAndMatches(this uint? value, uint number) => value.GetValueOrDefault() == number;

        public static bool IsValidAndMatches(this uint? value, string number) => value.GetValueOrDefault() == number.MapJsonString<uint>();
        #endregion

        #region Ulong
        public static bool IsValidValue(this ulong? value) => value.GetValueOrDefault() != default(ulong);

        public static bool IsValidAndAboveZero(this ulong? value) => value.IsValidAndAbove(default(ulong));

        public static bool IsValidAndBelowZero(this ulong? value) => value.IsValidAndBelow(default(ulong));

        public static bool IsValidAndAbove(this ulong? value, ulong min) => value.GetValueOrDefault() > min;

        public static bool IsValidAndBelow(this ulong? value, ulong max) => value.GetValueOrDefault() < max;

        public static bool IsValidAndMatches(this ulong? value, ulong number) => value.GetValueOrDefault() == number;

        public static bool IsValidAndMatches(this ulong? value, string number) => value.GetValueOrDefault() == number.MapJsonString<ulong>();
        #endregion
    }
}