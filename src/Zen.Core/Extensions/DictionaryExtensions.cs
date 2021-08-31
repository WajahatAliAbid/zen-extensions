namespace System.Collections.Generic
{
    public static class DictionaryExtensions
    {
        public static bool TryAdd<K, V>(this IDictionary<K, V> dict, K key, V value)
        {
            if (!dict.ContainsKey(key))
            {
                dict[key] = value;
                return true;
            }
            return false;
        }

        public static V TryGetValue<K, V>(this IDictionary<K, V> dict, K key, V defaultValue = default)
        {
            if (dict.ContainsKey(key))
                return dict[key];
            return defaultValue;
        }
    }
}