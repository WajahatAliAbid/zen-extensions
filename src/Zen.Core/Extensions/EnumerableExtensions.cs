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
    }
}