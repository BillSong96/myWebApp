using System;
using myWebApp.Interfaces;

namespace myWebApp.Services
{
    public class CurrentTime : ICurrentTime
    {
        public DateTime GetTime()
        {
            return DateTime.Now;
        }
    }
}