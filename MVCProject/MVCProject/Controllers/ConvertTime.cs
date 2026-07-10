using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class ConvertTime : Controller
    {
        public IActionResult Convert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Convert(TimeModel obj)
        {
            int seconds = obj.hour * 360;
            ViewData["result"] = seconds;
            return View();
        }
    }
}
