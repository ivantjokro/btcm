using Microsoft.Extensions.Caching.Memory;
using System;

namespace btcm.Common.Caching
{
    public class CacheProvider : ICacheProvider
    {

        IMemoryCache _memoryCache;

        public CacheProvider(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T Get<T>(string key, Func<T> fetch, bool hasDependency = false) where T : class
        {
            if (_memoryCache.TryGetValue(key, out T function))
            {
                return function;
            }
            else
            {
                return _memoryCache.Set(key, fetch());
            }
        }
    }
}
