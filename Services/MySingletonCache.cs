using System;
using myWebApp.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace myWebApp.Services
{
    public class MySingletonCache : IMySingletonCache
    {
        private static IMemoryCache _myCache;

        public MySingletonCache(IMemoryCache myCache)
        {
            _myCache = myCache;
        }

        public bool TryGetValue<T>(String key, out T t)
        {
            return _myCache.TryGetValue<T>(key, out t);
        }

        public void SetNX<T>(String key, T value, DateTimeOffset timeOffset)
        {
            if (!_myCache.TryGetValue<T>(key, out T t)) {
                _myCache.Set<T>(key, value, timeOffset);
            }
        }
    }
}