using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace ClassroomConnect.Web.Models
{
    public class MemoryCacheProvider : iCacheProvider
    {
        /// <summary>
        /// Adds an item to the global cache.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public bool Set(string key, object value, int minutes)
        {
            // Save to memory cache.
            ObjectCache cache = MemoryCache.Default;

            if (cache[key] != null)
                cache.Remove(key);

            CacheItemPolicy policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(minutes)
            };

            cache.Set(key, value, policy);

            return true;
        }

        /// <summary>
        /// Returns the cached item for the given key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            ObjectCache cache = MemoryCache.Default;

            var item = cache.Get(key);

            if (item is T)
                return (T)item;
            else
                return default(T);
        }

        /// <summary>
        /// Removes an item from the cache.
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            ObjectCache cache = MemoryCache.Default;

            cache.Remove(key);
        }
    }
}

