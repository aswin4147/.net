using BusinessLogic.IRepo;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> ViewBooks()
        {
            var data = await _repo.GetBookDataAsync();
            return View(data);
        }
    }
}
