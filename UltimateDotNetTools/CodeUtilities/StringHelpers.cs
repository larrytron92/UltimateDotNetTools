using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace UltimateDotNetTools
{
    public static class StringHelpers
    {
        public static string ToSeperatedString(this ICollection<string> collection, string seperator, bool throwOnError = false)
        {
            if (collection.IsNullOrEmpty())
            {
                if (throwOnError)
                {
                    throw new ArgumentNullException("The collection of string is null or empty!");
                }

                return string.Empty;
            }

            return string.Join(seperator, collection);
        }

        public static string ToCommaSeperatedString(this ICollection<string> collection, bool throwOnError = false) => collection.ToSeperatedString(",", throwOnError);

        public static string SafeTrim(this string value) => !string.IsNullOrWhiteSpace(value) ? value.Trim() : string.Empty;

        public static string SeperateCapitalLetters(this string value, bool allowTrim = false, bool throwOnError = false)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                if (throwOnError)
                {
                    throw new ArgumentNullException("The string should not be null or full of white spaces!");
                }

                return value;
            }

            if (allowTrim)
            {
                value = value.Trim();
            }

            var words = Regex.Split(value, @"(?<!^)(?=[A-Z])");

            if (words.IsNotNullOrEmpty())
            {
                var sb = new StringBuilder();

                foreach (var word in words)
                {
                    sb.Append($"{word} ");
                }

                var retVal = sb.ToString();

                return retVal.Remove(retVal.Length - 1, 1);
            }

            if (throwOnError)
            {
                throw new Exception("There's no capital letters in this string!");
            }

            return value;
        }

        public static string SetFirstLetterToUpperCase(this string value, bool allowTrim = false)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (allowTrim)
                {
                    value = value.Trim();
                }

                for (var i = 0; i < value.Length; i++)
                {
                    if (char.IsLetter(value[i]))
                    {
                        return $"{char.ToUpper(value[i])}{value.Substring(1).ToLower()}";
                    }
                }
            }

            return value;
        }

        public static string LimitString(this string value, int maxLength, bool allowTrim = false, bool throwOnError = false)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                if (throwOnError)
                {
                    throw new ArgumentNullException("The string should not be null or full of white spaces!");
                }

                return value;
            }

            if (maxLength < 1)
            {
                if (throwOnError)
                {
                    throw new ArgumentOutOfRangeException("The maximum length must be 1 or more!");
                }

                return value;
            }

            if (allowTrim)
            {
                value = value.Trim();
            }

            return value.Substring(0, maxLength);
        }

        public static bool IsValidUrl(this string url)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(url))
                {
                    return Uri.TryCreate(url.Trim(), UriKind.Absolute, out var uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                }

                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public static T MapJsonString<T>(this string json, bool throwOnError = false, JsonSerializerOptions options = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(json))
                {
                   throw new ArgumentNullException("The string should not be null or full of white spaces!");
                }

                json = json.Trim();

                var genericType = typeof(T);

                if (genericType == typeof(string))
                {
                    return (T)Convert.ChangeType(json, genericType);
                }

                if (genericType.IsValueType)
                {
                    object retVal;

                    if (genericType == typeof(int) || genericType == typeof(int?))
                    {
                        retVal = int.Parse(json);
                    }
                    else if (genericType == typeof(double) || genericType == typeof(double?))
                    {
                        retVal = double.Parse(json);
                    }
                    else if (genericType == typeof(DateTime) || genericType == typeof(DateTime?))
                    {
                        retVal = DateTime.Parse(json);
                    }
                    else if (genericType == typeof(bool) || genericType == typeof(bool?))
                    {
                        retVal = bool.Parse(json.ToLower());
                    }
                    else if (genericType == typeof(decimal) || genericType == typeof(decimal?))
                    {
                        retVal = decimal.Parse(json);
                    }
                    else if (genericType == typeof(float) || genericType == typeof(float?))
                    {
                        retVal = float.Parse(json);
                    }
                    else if (genericType == typeof(Guid) || genericType == typeof(Guid?))
                    {
                        retVal = Guid.Parse(json);
                    }
                    else
                    {
                        throw new Exception($"{genericType.Name} is not supported");
                    }

                    return (T)Convert.ChangeType(retVal, genericType);
                }

                if (options is null)
                {
                    options = new JsonSerializerOptions 
                    {
                        PropertyNameCaseInsensitive = true
                    };
                }

                return JsonSerializer.Deserialize<T>(json, options);
            }
            catch (ArgumentNullException argEx)
            {
                if (throwOnError)
                {
                    throw argEx;
                }
            }
            catch (Exception ex)
            {
                if (throwOnError)
                {
                    throw ex;
                }
            }

            return default(T);
        }

        public static int ToInt(this string value, bool throwOnError = false) => MapJsonString<int>(value, throwOnError);

        public static int? ToNullableInt(this string value, bool throwOnError = false) => MapJsonString<int>(value, throwOnError);

        public static double ToDouble(this string value, bool throwOnError = false) => MapJsonString<double>(value, throwOnError);

        public static double? ToNullableDouble(this string value, bool throwOnError = false) => MapJsonString<double>(value, throwOnError);

        public static float ToFloat(this string value, bool throwOnError = false) => MapJsonString<float>(value, throwOnError);

        public static float? ToNullableFloat(this string value, bool throwOnError = false) => MapJsonString<float?>(value, throwOnError);

        public static bool IsTrue(this string value, bool throwOnError = false) => MapJsonString<bool>(value, throwOnError);

        public static decimal ToDecimal(this string value, bool throwOnError = false) => MapJsonString<decimal>(value, throwOnError);

        public static decimal? ToNullableDecimal(this string value, bool throwOnError = false) => MapJsonString<decimal?>(value, throwOnError);

        public static DateTime ToDateTime(this string value, bool throwOnError = false) => MapJsonString<DateTime>(value, throwOnError);

        public static DateTime? ToNullableDateTime(this string value, bool throwOnError = false) => MapJsonString<DateTime?>(value, throwOnError);

        public static string ToCamelCase(this string value, bool allowTrim = false)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (allowTrim)
                {
                    value = value.Trim();
                }

                for (var i = 0; i < value.Length; i++)
                {
                    if (char.IsLetter(value[i]))
                    {
                        return $"{char.ToLower(value[i])}{value.Substring(1).ToLower()}";
                    }
                }
            }

            return value;
        }
    }
}