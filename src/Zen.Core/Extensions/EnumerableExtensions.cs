using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace System.Collections.Generic
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            if(enumerable is null)
                return true;
            return !enumerable.Any();
        }

        /// <summary>
        /// Trims the subCollection from the start of the list
        /// </summary>
        /// <remarks>Throws <see cref="ArgumentNullException"/> if source or subarray is null</remarks>
        /// <param name="source">the list to trim</param>
        /// <param name="subArray">the sub collection to trim from stat of source list</param>
        /// <typeparam name="T">type of items in a list</typeparam>
        /// <returns>trimmed list</returns>
        /// <exception cref="ArgumentNullException"/>
        public static IEnumerable<T> TrimStart<T>([NotNull] this IEnumerable<T> source, [NotNull] IEnumerable<T> subArray)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (subArray is null)
            {
                throw new ArgumentNullException(nameof(subArray));
            }

            if (source.StartsWith(subArray))
            {
                source = source.Skip(subArray.Count());
            }
            return source;
        }

        /// <summary>
        /// Trims the subCollection from the end of the list
        /// </summary>
        /// <remarks>Throws <see cref="ArgumentNullException"/> if source or subarray is null</remarks>
        /// <param name="source">the list to trim</param>
        /// <param name="subArray">the sub collection to trim from end of source list</param>
        /// <typeparam name="T">type of items in a list</typeparam>
        /// <returns>trimmed list</returns>
        /// <exception cref="ArgumentNullException"/>
        public static IEnumerable<T> TrimEnd<T>([NotNull] this IEnumerable<T> source, [NotNull] IEnumerable<T> subArray)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (subArray is null)
            {
                throw new ArgumentNullException(nameof(subArray));
            }

            if (source.EndsWith(subArray))
            {
                source = source.SkipLast(subArray.Count());
            }
            return source;
        }

        /// <summary>
        /// Checks if a subCollection is present at start of the list
        /// </summary>
        /// <remarks>Throws <see cref="ArgumentNullException"/> if source or subarray is null</remarks>
        /// <param name="source">the list to trim</param>
        /// <param name="subArray">the sub collection to check if it is present at the start of source</param>
        /// <typeparam name="T">type of items in a list</typeparam>
        /// <returns>true if sublist is present at start of the source, else false</returns>
        /// <exception cref="ArgumentNullException"/>
        public static bool StartsWith<T>([NotNull] this IEnumerable<T> source, [NotNull] IEnumerable<T> subArray)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (subArray is null)
            {
                throw new ArgumentNullException(nameof(subArray));
            }

            return source
                .Where((value, index) => index < subArray.Count() && value.Equals(subArray.ElementAt(index)))
                .Count() == subArray.Count();
        }

        /// <summary>
        /// Checks if a subCollection is present at end of the list
        /// </summary>
        /// <remarks>Throws <see cref="ArgumentNullException"/> if source or subarray is null</remarks>
        /// <param name="source">the list to trim</param>
        /// <param name="subArray">the sub collection to check if it is present at the end of source</param>
        /// <typeparam name="T">type of items in a list</typeparam>
        /// <returns>true if sublist is present at end of the source, else false</returns>
        /// <exception cref="ArgumentNullException"/>
        public static bool EndsWith<T>([NotNull] this IEnumerable<T> source, [NotNull] IEnumerable<T> subArray)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (subArray is null)
            {
                throw new ArgumentNullException(nameof(subArray));
            }

            return source
                .Where((value, index) =>
                {
                    var subIndex = index + subArray.Count() - source.Count();
                    if (subIndex < 0 && subIndex < subArray.Count())
                        return false;
                    return value.Equals(subArray.ElementAt(subIndex));
                })
                .Count() == subArray.Count();
        }

        /// <summary>
        /// Adds to the list if the item doesn't already exist in the list. Ignores the null items
        /// </summary>
        /// <remarks>Throws <see cref="ArgumentNullException"/> if list is null</remarks>
        /// <exception cref="ArgumentNullException"/>
        public static void AddIfNotContains<T>([NotNull] this List<T> list, T item)
        {
            if(list is null)
                throw new ArgumentNullException(nameof(list));
            if(item is null)
                return;
            if (!list.Contains(item))
            {
                list.Add(item);
            }
        }

        /// <summary>
        /// Divides the list into different lists divided by the chunk sizes. 
        /// </summary>
        /// <remarks>
        /// <para>Throws <see cref="ArgumentNullException"/> if source is null</para>
        /// <para>Throws <see cref="ArgumentException"/> if chunk size is 1 or smaller</para>
        /// </remarks>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/>
        public static List<List<T>> ChunkBySize<T>(this List<T> source, int chunkSize)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (chunkSize <= 1)
                throw new ArgumentException("Chunk size must be 2 or greater");
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}