using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class ShowTimeController : Controller
    {
        [ServiceFilter(typeof(CacheAttribute))]
        public IActionResult Index()
        {
            ViewData["time"] = System.DateTime.Now.ToString();
            return View();
        }
    }
}