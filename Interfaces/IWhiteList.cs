using System;

namespace myWebApp.Interfaces
{
    public interface IWhiteList
    {
        bool contains(string key);
    }
}