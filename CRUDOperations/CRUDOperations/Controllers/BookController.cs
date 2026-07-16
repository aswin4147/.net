using BusinessLogic.IRepo;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CRUDOperations.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepo _repo;

        public BookController(IBookRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(BookData data)
        {
            await _repo.AddBookAsync(data);
            return RedirectToAction("ViewBooks");
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ViewBooks()
        {

            var data = await _repo.GetBookDataAsync();
            return View(data);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(BookLogin user)
        {
            await _repo.AddUserAsync(user);
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string Email, string Password)
        {
            if (ModelState.IsValid)
            {
                var user = await _repo.GetUserAsync(Email, Password);

                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Role, user.Role)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return RedirectToAction("ViewBooks");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }
            return View();
        }

    }
}
