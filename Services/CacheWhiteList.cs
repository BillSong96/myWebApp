using System.Collections.Generic;
using System;
using myWebApp.Interfaces;

namespace myWebApp.Services
{
    public class CacheWhiteList : IWhiteList
    {
        private HashSet<string> _set;

        public CacheWhiteList()
        {
            _set = new HashSet<string>();
            _set.Add("/showtime/index");
        }

        public bool contains(string key)
        {
            return _set.Contains(key);
        }
    }
}