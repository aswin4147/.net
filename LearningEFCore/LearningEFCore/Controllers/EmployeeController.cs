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
        public IActionResult EmployeeDisplay()
        {
            IEnumerable<EmployeeData> data = from s in _db.EmployeeTable select s;
            return View(data);
        }

        [HttpGet]
        public IActionResult EmployeeEdit(int EmpID)
        {
            var res = _db.EmployeeTable.FirstOrDefault(x => x.EmpID == EmpID);
            return View(res);
        }

        [HttpPost]
        public IActionResult EmployeeEdit(EmployeeData data)
        {
            _db.EmployeeTable.Update(data);
            _db.SaveChanges();
            return RedirectToAction("EmployeeDisplay");
        }

        [HttpGet]
        public IActionResult EmployeeDelete(int EmpID)
        {
            var res = _db.EmployeeTable.FirstOrDefault(x => x.EmpID == EmpID);
            return View(res);
        }

        [HttpPost, ActionName("EmployeeDelete")]
        public IActionResult EmployeeDeleteConfirm(int EmpID)
        {
            EmployeeData employee = _db.EmployeeTable.FirstOrDefault(x => x.EmpID == EmpID);
            _db.Remove(employee);
            _db.SaveChanges();
            return RedirectToAction("EmployeeDisplay");
        }
    }
}
