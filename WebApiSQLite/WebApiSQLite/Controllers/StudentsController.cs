using DataAccessLayer.IRepo;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiSQLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepo _repo;

        public StudentsController(IStudentRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _repo.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _repo.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} was not found.");
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Students student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repo.AddStudentAsync(student);

            return CreatedAtAction(nameof(GetStudentById), new { id = student.ID }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Students student)
        {
            if (id != student.ID)
            {
                return BadRequest("The ID in the URL does not match the ID in the request body.");
            }

            var existingStudent = await _repo.GetStudentByIdAsync(id);
            if (existingStudent == null)
            {
                return NotFound($"Student with ID {id} was not found.");
            }

            await _repo.UpdateStudentAsync(student);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var existingStudent = await _repo.GetStudentByIdAsync(id);
            if (existingStudent == null)
            {
                return NotFound($"Student with ID {id} was not found.");
            }

            await _repo.DeleteStudentAsync(id);

            return NoContent();
        }
    }
}
