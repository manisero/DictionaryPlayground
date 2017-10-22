using System;
using System.Collections.Generic;

namespace DictionaryPlayground.Shared
{
    public static class EnumerableExtensions
    {
        public static IDictionary<TKey, TItem> ToDictWithCapacity<TItem, TKey>(
            this IEnumerable<TItem> items,
            Func<TItem, TKey> keyGetter,
            int capacity)
        {
            var result = new Dictionary<TKey, TItem>(capacity);

            foreach (var item in items)
            {
                result.Add(keyGetter(item), item);
            }

            return result;
        }
    }
}
