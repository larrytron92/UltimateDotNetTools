using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UltimateDotNetTools
{
    public static class ListHelpers
    {
        #region IEnumerable...
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection) => collection is null || collection.Count() == 0;

        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> collection) => collection != null && collection.Count() > 0;

        public static bool IsNotNullAndAny<T>(this IEnumerable<T> collection, Func<T, bool> predicate) => collection != null && collection.Any(predicate);

        public static bool IsNotNullAndContains<T>(this IEnumerable<T> collection, T item) => collection != null && collection.Contains(item);

        public static bool IsNotNullAndAll<T>(this IEnumerable<T> collection, Func<T, bool> predicate) => collection != null && collection.All(predicate);

        public static IEnumerable<T> IsNotNullAndExcept<T>(this IEnumerable<T> collection, IEnumerable<T> second)
        {
            if (collection is null)
            {
                collection = new List<T>();
            }

            if (second is null)
            {
                second = new List<T>();
            }

            return collection.Except(second);
        }
        
        public static IEnumerable<IEnumerable<T>> ConvertListToPage<T>(this IEnumerable<T> source, int pageSize)
        {
            if (source.IsNullOrEmpty())
            {
                throw new ArgumentNullException("List cannot be empty!");
            }

            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException("Page size cannot be lower that 1!");
            }

            using (var enumerator = source.GetEnumerator())
            {
                var currentPage = new List<T>(pageSize)
                {
                    enumerator.Current
                };

                while (currentPage.Count < pageSize && enumerator.MoveNext())
                {
                    currentPage.Add(enumerator.Current);
                }

                yield return new ReadOnlyCollection<T>(currentPage);
            }
        }
        #endregion

        #region ICollection...
        public static bool IsNotNullOrEmpty<T>(this ICollection<T> collection) => collection != null && collection.Count > 0;

        public static bool IsNullOrEmpty<T>(this ICollection<T> collection) => collection is null || collection.Count == 0;

        public static bool IsNotNullAndAny<T>(this ICollection<T> collection, Func<T, bool> predicate) => collection != null && collection.Any(predicate);

        public static bool IsNotNullAndContains<T>(this ICollection<T> collection, T item) => collection != null && collection.Contains(item);

        public static bool IsNotNullAndAll<T>(this ICollection<T> collection, Func<T, bool> predicate) => collection != null && collection.All(predicate);
        #endregion
    }
}
