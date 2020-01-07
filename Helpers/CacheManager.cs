using ClassroomConnect.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomConnect.Web.Helpers
{
    public class CacheManager
    { 
    // <summary>
    /// Global var for the initialized Global Cache Manager object.
    /// </summary>
    private static iCacheProvider _GlobalCacheManager = null;
    private static string _CacheKeyPrefix = null;

    private static iCacheProvider CachingObject
    {
        get
        {
            if (_GlobalCacheManager == null)
                _GlobalCacheManager = new Models.MemoryCacheProvider();  // Default to Redis

            return _GlobalCacheManager;
        }
    }

    /// <summary>
    /// Gets the Global Cache Key prefix
    /// </summary>
    private static string CacheKeyPrefix
    {
        get
        {
            if (string.IsNullOrEmpty(_CacheKeyPrefix))
            {
                
                // Get the application title from the assembly.
                System.Reflection.Assembly assembly;

                StackFrame[] frames = new StackTrace().GetFrames();

                for (int i = 0; i < frames.Length; i++)
                {
                    if (frames[i].GetMethod() != null && frames[i].GetMethod().ReflectedType != null)
                    {
                        assembly = frames[i].GetMethod().ReflectedType.Assembly;

                        object[] attrs = assembly.GetCustomAttributes(typeof(System.Reflection.AssemblyTitleAttribute), false);

                        if (attrs.Length == 1 && ((System.Reflection.AssemblyTitleAttribute)attrs[0]).Title.Contains("classroomConnect"))
                            _CacheKeyPrefix = ((System.Reflection.AssemblyTitleAttribute)attrs[0]).Title;
                        else
                            break;
                    }
                }
            }

            return _CacheKeyPrefix ?? "classroomConnect";
        }
    }

    /// <summary>
    /// Initializer for the Global Cache Manager object.
    /// </summary>
    /// <param name="globalCacheManager"></param>
    public static void Init(iCacheProvider globalCacheManager)
    {
        _GlobalCacheManager = globalCacheManager;
    }

    /// <summary>
    /// Adds a key to the keys list. This list is used to remove all cached items. 
    /// As long as the cached item was added to this list it can be cleared manually.
    /// </summary>
    /// <param name="key">Cache key of the item to return.</param>
    public static void AddCachedKey(string key)
    {
        bool listCached = true;
        string keysKey = GetCacheKey("keys"); // Cache key to the list of cached keys ;)

        List<string> keys = Get<List<string>>(keysKey);

        if (keys == null)
        {
            listCached = false;
            keys = new List<string>();
        }

        // Add key to the list.
        if (!keys.Contains(key))
        {
            keys.Add(key);

            if (listCached)
                Remove(keysKey);

            Set(keysKey, keys, 60);
        }
    }

    /// <summary>
    /// Removes all items that have been listed as being cached.
    /// </summary>
    public static void ClearAllCachedItems()
    {
        string keysKey = GetCacheKey("keys"); // Cache key to the list of cached keys ;)

        List<string> keys = Get<List<string>>(keysKey); // List of cached keys.

        if (keys != null)
        {
            // Loop through each key and remove it from the cache.
            foreach (string key in keys)
            {
                try
                {
                    Remove(key);
                }
                catch
                { }
            }
        }
    }

    /// <summary>
    /// Returns a fully qualified application level cache key.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string GetCacheKey(string key)
    {
        return string.Format("{0}.{1}", CacheKeyPrefix, key);
    }

    /// <summary>
    /// Adds an item to the global cache.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="minutes"></param>
    /// <returns></returns>
    public static bool Set(string key, object value, int minutes)
    {
        CachingObject.Set(GetCacheKey(key), value, minutes);

        return true;
    }

    /// <summary>
    /// Returns the cached item for the given key.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    public static T Get<T>(string key)
    {
        return CachingObject.Get<T>(GetCacheKey(key));
    }

    /// <summary>
    /// Removes an item from the cache.
    /// </summary>
    /// <param name="key"></param>
    public static void Remove(string key)
    {
        CachingObject.Remove(GetCacheKey(key));
    }
}
}
