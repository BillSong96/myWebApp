using System;
using myWebApp.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace myWebApp.Services
{
    public class MySingletonCache : IMySingletonCache
    {
        private IMemoryCache _myCache;

        private IWhiteList _whiteList;

        public MySingletonCache(IMemoryCache myCache, IWhiteList whiteList)
        {
            _myCache = myCache;
            _whiteList = whiteList;
        }

        public bool TryGetValue<T>(string key, out T t)
        {
            return _myCache.TryGetValue<T>(key, out t) && _whiteList.contains(key);
        }

        public void SetNX<T>(string key, T value, DateTimeOffset timeOffset)
        {
            if (!_myCache.TryGetValue<T>(key, out T t) && _whiteList.contains(key)) {
                _myCache.Set<T>(key, value, timeOffset);
            }
        }
    }
}