using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class DivyamGayController : Controller
    {
        public IActionResult Whiskey()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Whiskey(string selection, MyValues obj)
        {
            int result = 0;

            ViewData["input"] = obj.input;
            if (selection == "kmtometre")
            {
                ViewData["from"] = "km";
                result = obj.input * 1000;
                ViewData["to"] = "metre";
            }
            if (selection == "hourtosecond")
            {
                ViewData["from"] = "hour";
                result = obj.input * 360;
                ViewData["to"] = "second";
            }
            if (selection == "feettoinch")
            {
                ViewData["from"] = "feet";
                result = obj.input * 12;
                ViewData["to"] = "inch";
            }

            ViewData["result"] = result;
            return View();
        }
    }
}
