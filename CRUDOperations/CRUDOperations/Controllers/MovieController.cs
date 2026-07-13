using BusinessLogic.IRepo;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDOperations.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepo _repo;
        public MovieController(IMovieRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(MovieDetails details)
        {
            await _repo.SaveMovieAsync(details);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ViewMovies()
        {
            var data = await _repo.GetMoviesAsync();
            return View(data);
        }
    }
}
