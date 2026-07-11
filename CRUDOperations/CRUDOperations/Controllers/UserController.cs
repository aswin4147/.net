using BusinessLogic.IRepo;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDOperations.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepo _repo;

        public UserController(IUserRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> DisplayUsers()
        {
            var data = await _repo.GetUsersAsync();
            return View(data);
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        public async Task<IActionResult> AddUser(UserData data)
        {
            await _repo.AddUserAsync(data);
            return RedirectToAction("DisplayUsers");
        }
    }
}
