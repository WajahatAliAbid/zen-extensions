using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic
{
    public static class DictionaryExtensions
    {
        public static bool TryAdd<K, V>([NotNull] this IDictionary<K, V> dict, K key, V value)
        {
            if (dict is null)
            {
                throw new ArgumentNullException(nameof(dict));
            }

            if (!dict.ContainsKey(key))
            {
                dict[key] = value;
                return true;
            }
            return false;
        }

        public static V TryGetValue<K, V>([NotNull] this IDictionary<K, V> dict, K key, V defaultValue = default)
        {
            if (dict is null)
            {
                throw new ArgumentNullException(nameof(dict));
            }

            if (dict.ContainsKey(key))
                return dict[key];
            return defaultValue;
        }

        public static bool TryRemoveValue<K,V>([NotNull] this IDictionary<K, V> dict, K key)
        {
            if(dict.ContainsKey(key))
            {
                dict.Remove(key);
                return true;
            }
            return false;
        }

        public static bool TryRemoveValue<K,V>([NotNull] this IDictionary<K, V> dict, K key, out V value)
        {
            if(dict.ContainsKey(key))
            {
                dict.Remove(key, out value);
                return true;
            }
            value = default;
            return false;
        }
    }
}