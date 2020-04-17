using Microsoft.AspNetCore.Mvc;
using myWebApp.Interfaces;

namespace myWebApp.Controllers
{
    public class ShowTimeController : Controller
    {
        private ICurrentTime _currentTime { get; set; }
        public ShowTimeController(ICurrentTime currentTime)
        {
            _currentTime = currentTime;
        }

        [RedirectAttribute("User-Agent", "Mobile", "http://www.baidu.com")]
        [CacheAttribute("text/html; charset=utf-8", "/showtime/index")]
        public IActionResult Index()
        {
            ViewData["time"] = _currentTime.GetTime().ToString();
            return View();
        }
    }
}