using Microsoft.AspNetCore.Mvc;

namespace CRUDOperations.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
