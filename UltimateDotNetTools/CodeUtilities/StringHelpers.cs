using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

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

        public static string SafeTrim(this string value) => value != null ? value.Trim() : string.Empty;

        public static string SeperateCapitalLetters(this string value, bool removeWhitespaces = false, bool throwOnError = false)
        {
            if (value.IsNullOrWhiteSpace())
            {
                if (throwOnError)
                {
                    throw new ArgumentNullException("The string should not be null or full of white spaces!");
                }

                return value;
            }

            if (removeWhitespaces)
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

        public static string SetFirstLetterToUpperCase(this string value, bool removeWhitespaces = false)
        {
            if (value.IsNotNullOrWhiteSpace())
            {
                if (removeWhitespaces)
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

        public static string LimitString(this string value, int maxLength, bool removeWhitespaces = false, bool throwOnError = false)
        {
            if (value.IsNullOrWhiteSpace())
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

            if (removeWhitespaces)
            {
                value = value.Trim();
            }

            return value.Substring(0, maxLength);
        }

        public static bool IsValidUrl(this string url)
        {
            try
            {
                if (url.IsNotNullOrWhiteSpace())
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
                if (json.IsNullOrWhiteSpace())
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
                    else if (genericType == typeof(sbyte) || genericType == typeof(sbyte?))
                    {
                        retVal = sbyte.Parse(json);
                    }
                    else if (genericType == typeof(byte) || genericType == typeof(byte?))
                    {
                        retVal = byte.Parse(json);
                    }
                    else if (genericType == typeof(short) || genericType == typeof(short?))
                    {
                        retVal = short.Parse(json);
                    }
                    else if (genericType == typeof(ushort) || genericType == typeof(ushort?))
                    {
                        retVal = ushort.Parse(json);
                    }
                    else if (genericType == typeof(uint) || genericType == typeof(uint?))
                    {
                        retVal = uint.Parse(json);
                    }
                    else if (genericType == typeof(ulong) || genericType == typeof(ulong?))
                    {
                        retVal = ulong.Parse(json);
                    }
                    else if (genericType == typeof(char) || genericType == typeof(char?))
                    {
                        retVal = char.Parse(json);
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

        public static int ToInt(this string value, bool throwOnError = false) => value.MapJsonString<int>(throwOnError);

        public static int? ToNullableInt(this string value, bool throwOnError = false) => value.MapJsonString<int>(throwOnError);

        public static double ToDouble(this string value, bool throwOnError = false) => value.MapJsonString<double>(throwOnError);

        public static double? ToNullableDouble(this string value, bool throwOnError = false) => value.MapJsonString<double>(throwOnError);

        public static float ToFloat(this string value, bool throwOnError = false) => value.MapJsonString<float>(throwOnError);

        public static float? ToNullableFloat(this string value, bool throwOnError = false) => value.MapJsonString<float?>(throwOnError);

        public static bool IsTrue(this string value, bool throwOnError = false) => value.MapJsonString<bool>(throwOnError);

        public static decimal ToDecimal(this string value, bool throwOnError = false) => value.MapJsonString<decimal>(throwOnError);

        public static decimal? ToNullableDecimal(this string value, bool throwOnError = false) => value.MapJsonString<decimal?>(throwOnError);

        public static DateTime ToDateTime(this string value, bool throwOnError = false) => value.MapJsonString<DateTime>(throwOnError);

        public static DateTime? ToNullableDateTime(this string value, bool throwOnError = false) => value.MapJsonString<DateTime?>(throwOnError);

        public static Guid ToGuid(this string value, bool throwOnError = false) => value.MapJsonString<Guid>(throwOnError);

        public static Guid? ToNullableGuid(this string value, bool throwOnError = false) => value.MapJsonString<Guid?>(throwOnError);

        public static string ToCamelCase(this string value, bool removeWhitespaces = false)
        {
            if (value.IsNotNullOrWhiteSpace())
            {
                if (removeWhitespaces)
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

        public static bool IsNullOrWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value.SafeTrim());

        public static bool IsNotNullOrWhiteSpace(this string value) => !string.IsNullOrWhiteSpace(value.SafeTrim());

        public static string ToWebApiFromUrlArgument<T>(this IList<T> args, string argumentName, bool throwOnError = false)
        {
            try
            {
                if (args.IsNullOrEmpty())
                {
                    throw new ArgumentNullException("The lists of guids are empty!");
                }

                if (argumentName.IsNullOrWhiteSpace())
                {
                    throw new ArgumentNullException("The argument name cannot be null!");
                }

                var retVal = new StringBuilder("?");
                
                var genericType = typeof(T);

                if (genericType == typeof(string))
                {
                    for (var i = 0; i < args.Count; i++)
                    {
                        var valueAsString = ((string)Convert.ChangeType(args[i], genericType)).SafeTrim();
                        retVal.Append($"{argumentName}={valueAsString}&");
                    }
                }
                else if (genericType.IsValueType)
                {
                    for (var i = 0; i < args.Count; i++)
                    {
                        var valueAsString = ((T)Convert.ChangeType(args[i], genericType)).ToString().SafeTrim();
                        retVal.Append($"{argumentName}={valueAsString.MapJsonString<T>(throwOnError)}&");
                    }
                }
                else   
                {
                    for (var i = 0; i < args.Count; i++)
                    {
                        retVal.Append($"{argumentName}={JsonSerializer.Serialize<T>(args[i])}&");
                    }
                }

                return retVal.ToSafeString().RemoveLastCharacter();
            }
            catch (ArgumentNullException anex)
            {
                if (throwOnError)
                {
                    throw anex;
                }
            }
            catch (Exception ex)
            {
                if (throwOnError)
                {
                    throw ex;
                }
            }

            return string.Empty;
        }

        public static string ToSafeString(this StringBuilder sb) => sb is null ? string.Empty : sb.ToString().SafeTrim();

        public static string RemoveLastCharacter(this string value, bool removeWhitespaces = false, bool throwOnError = false) => value.RemoveEndCharacters(1, removeWhitespaces, throwOnError);

        public static string RemoveEndCharacters(this string value, int endCharactersToRemove, bool removeWhitespaces = false, bool throwOnError = false)
        {
            if (value.IsNullOrWhiteSpace())
            {
                if (throwOnError)
                {
                    throw new ArgumentNullException("String cannot be null or empty");
                }

                return string.Empty;
            }

            if (endCharactersToRemove < 1)
            {
                if (throwOnError)
                {
                    throw new ArgumentOutOfRangeException("Please specifiy a character greater than zero!");
                }

                return string.Empty;
            }

            if (removeWhitespaces)
            {
                value = value.Trim();
            }
            
            return value.Remove(value.Length - endCharactersToRemove);
        }

        public static List<string> GetTextBetweenTwoCharacters(string value, char characterBeginning, char characterEnd, bool throwOnError = false)
        {
            var retVal = new List<string>();

            if (value.IsNullOrWhiteSpace() 
                || characterBeginning == default(char) || characterBeginning == ' '
                || characterEnd == default(char) || characterEnd == ' ')
            {
                if (throwOnError)
                {
                    throw new ArgumentNullException("All three slots must be filled in!");
                }

                return retVal;
            }
            
            if (value.Contains(characterBeginning))
            {
                var leftSplit = value.Split(characterBeginning).ToList();

                if (leftSplit.IsNotNullOrEmpty())
                {
                    foreach (var firstSplit in leftSplit.Where(x => x.IsNotNullOrWhiteSpace()))
                    {
                        if (firstSplit.Contains(characterEnd))
                        {
                            var rightSplit = firstSplit.SafeTrim().Split(characterEnd).ToList();

                            if (rightSplit.IsNotNullOrEmpty())
                            {
                                retVal.AddRange(rightSplit.Where(x => x.IsNotNullOrWhiteSpace()).Select(x => x.SafeTrim()));
                            }
                        }
                    }
                }
                else
                {
                    if (throwOnError)
                    {
                        throw new ArgumentOutOfRangeException("There are no text after the first character");
                    }
                }
            }
            else
            {
                if (throwOnError)
                {
                    throw new ArgumentOutOfRangeException("Could not locate the beginning character!");
                }
            }
            
            return retVal;
        }

        public static bool ContainsSQLInjection(this string value)
        {
            if (value.IsNotNullOrWhiteSpace())
            {
                var invalidSqlCode = new List<string>
                { 
                    "--",
                    ";--",
                    ";",
                    "/*",
                    "*/",
                    "@@",
                    "@",
                    "%%",
                    "%",
                    "char",
                    "nchar",
                    "varchar",
                    "nvarchar",
                    "alter",
                    "begin",
                    "cast",
                    "create",
                    "cursor",
                    "declare",
                    "delete",
                    "drop",
                    "end",
                    "exec",
                    "execute",
                    "fetch",
                    "insert",
                    "kill",
                    "select",
                    "sys",
                    "sysobjects",
                    "syscolumns",
                    "table",
                    "update",
                    "like"
                };

                string CheckString = value.Replace("'", "''").SafeTrim();

                foreach (var code in invalidSqlCode)
                {
                    if ((CheckString.IndexOf(code, StringComparison.OrdinalIgnoreCase) >= 0))
                    {   
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool ContainsSQLInjection(this IEnumerable<string> collection) => collection.IsNotNullAndAny(x => x.ContainsSQLInjection());

        public static IEnumerable<int> GetCollectionIndexContainingSQLInjection(this IList<string> collection)
        {
            var retVal = new List<int>();

            if (collection.IsNotNullOrEmpty())
            {
                for (var i = 0; i < collection.Count; i++)
                {
                    if (collection[i].ContainsSQLInjection())
                    {
                        retVal.Add(i);
                    }
                }
            }
            
            return retVal;
        }

        public static Dictionary<int, bool> GetDictionaryInformationOfSqlInjection(this IList<string> collection)
        {
            var retVal = new Dictionary<int, bool>();

            if (collection.IsNotNullOrEmpty())
            {
                for (var i = 0; i < collection.Count; i++)
                {
                    retVal.Add(i, collection[i].ContainsSQLInjection());
                }
            }
            
            return retVal;
        }

        public static bool AllCharactersIsUpper(this string value, bool throwOnError = false)
        {
            if (value.IsNullOrWhiteSpace())
            {
                if (throwOnError)
                {
                    throw new ArgumentNullException("String cannot be empty or full of whitespaces");
                }

                return true;
            }

            return value.ToCharArray().Where(x => char.IsLetter(x)).All(x => char.IsUpper(x));
        }
        public static bool AllCharactersIsLower(this string value, bool throwOnError = false)
        {
            if (value.IsNullOrWhiteSpace())
            {
                if (throwOnError)
                {
                    throw new ArgumentNullException("String cannot be empty or full of whitespaces");
                }

                return true;
            }
            
            return value.ToCharArray().Where(x => char.IsLetter(x)).All(x => char.IsLower(x));
        }
    }
}