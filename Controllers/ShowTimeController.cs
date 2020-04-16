using Microsoft.AspNetCore.Mvc;
using myWebApp.Interfaces;

namespace myWebApp.Controllers
{
    public class ShowTimeController : Controller
    {
        private ICurrentTime _iCurrentTime { get; set; }
        public ShowTimeController(ICurrentTime iCurrentTime)
        {
            _iCurrentTime = iCurrentTime;
        }

        [RedirectAttribute("User-Agent", "Mobile", "http://www.baidu.com")]
        [CacheAttribute("text/html; charset=utf-8", "/ShowTime")]
        public IActionResult Index()
        {
            ViewData["time"] = _iCurrentTime.GetTime().ToString();
            return View();
        }
    }
}