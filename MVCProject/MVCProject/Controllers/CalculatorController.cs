using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Model obj)
        {
            int z = obj.x + obj.y;
            ViewData["result"] = z;
            return View();
        }
        public IActionResult Sub(Model obj)
        {
            if (Request.Method == "POST")
            {
                TempData["result"] = obj.x - obj.y;
            }

            return View();
        }
    }
}
