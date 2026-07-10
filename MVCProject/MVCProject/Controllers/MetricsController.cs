using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class MetricsController : Controller
    {
        public IActionResult Convert()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Convert(MetricsModel obj)
        {
            int m = obj.km * 1000;
            ViewData["result"] = m;
            return View();
        }

        public IActionResult Feet()
        {
            return View();
        }
    }
}
