using System;

namespace myWebApp.Interfaces
{
    public interface IMySingletonCache
    {
        bool TryGetValue<T>(string key, out T t);
        void SetNX<T>(string key, T value, DateTimeOffset timeOffset);
    }
}