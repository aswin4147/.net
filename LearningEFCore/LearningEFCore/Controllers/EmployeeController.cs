using Microsoft.AspNetCore.Mvc;
using LearningEFCore.Models;

namespace LearningEFCore.Controllers
{
    public class EmployeeController : Controller
    {
        private AppDb _db;
        public EmployeeController()
        {
            _db = new AppDb();
        }
        [HttpGet]
        public IActionResult EmployeeAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EmployeeAdd(EmployeeData Data)
        {
            _db.EmployeeTable.Add(Data);
            _db.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult DisplayEmployee()
        {
            
            return View();
        }
    }
}
