using System;

namespace myWebApp.Interfaces
{
    public interface IMySingletonCache
    {
        bool TryGetValue<T>(String key, out T t);
        void SetNX<T>(String key, T value, DateTimeOffset timeOffset);
    }
}