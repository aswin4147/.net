using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IRepo;
using Service.Models;

namespace LearnWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _repo;

        public UserController(IUser repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var res = await _repo.GetUsersAsync();

            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserData user)
        {
            await _repo.AddUserAsync(user);

            return CreatedAtAction("GetUser", user);
        }
    }
}
