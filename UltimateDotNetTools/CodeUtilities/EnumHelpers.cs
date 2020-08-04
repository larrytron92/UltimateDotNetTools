using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace UltimateDotNetTools
{
    public static class EnumHelpers
    {
        public static List<int> GetListOfEnumValues<Enum>() => GetListOfEnumValues(typeof(Enum));

        public static List<int> GetListOfEnumValues(Type enumType) => Enum.GetValues(enumType).Cast<int>().ToList();

        public static int GetHighestNumber<Enum>() => GetListOfEnumValues<Enum>().Max();

        public static int GetLowestNumber<Enum>(bool excludeZero = false)
        {
            var enumNumbers = GetListOfEnumValues<Enum>();

            if (excludeZero && enumNumbers.IsNotNullAndContains(0))
            {
                enumNumbers.Remove(0);
            }

            return enumNumbers.Min();
        }

        private static DescriptionAttribute[] GetDescriptions(Enum value) => (DescriptionAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
        
        public static string GetDescription(this Enum value)
        {
            var attributes = GetDescriptions(value);

            return attributes.IsNotNullOrEmpty() ? attributes.First().Description : value.ToString().SeperateCapitalLetters();
        }

        public static IDictionary<int, string> GetDictionaryOfEnumAndDescription(Type enumType, bool excludeZero = false)
        {
            var retVal = new Dictionary<int, string>();

            foreach (var name in Enum.GetNames(enumType))
            {
                var enumNumber = (int)Enum.Parse(enumType, name);

                if (enumNumber == 0 && excludeZero)
                {
                    continue;
                }

                var descriptionAttribute = (DescriptionAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(DescriptionAttribute), true);

                retVal.Add(enumNumber, descriptionAttribute.IsNotNullOrEmpty() ? descriptionAttribute.First().Description : name.SeperateCapitalLetters());
            }

            return retVal;
        }

        public static IDictionary<int, string> GetDictionaryOfEnumAndDescription<Enum>(bool excludeZero = false) => GetDictionaryOfEnumAndDescription(typeof(Enum), excludeZero);

        public static bool IsNotInRangeOfEnum<Enum>(this int value, bool excludeZero = false)
        {
            var enumNumbers = GetListOfEnumValues(typeof(Enum));

            if (excludeZero && enumNumbers.IsNotNullAndContains(0))
            {
                enumNumbers.Remove(0);
            }

            return !enumNumbers.IsNotNullAndContains(value);
        }

        public static bool IsInRangeOfEnum<Enum>(this int value, bool excludeZero = false)
        {
            var enumNumbers = GetListOfEnumValues(typeof(Enum));

            if (excludeZero && enumNumbers.IsNotNullAndContains(0))
            {
                enumNumbers.Remove(0);
            }

            return enumNumbers.IsNotNullAndContains(value);
        }

        public static bool HasDescriptionAttribute(this Enum value) => GetDescriptions(value).IsNotNullOrEmpty();
    }
}