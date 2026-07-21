using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepo
{
    public interface IStudentRepo
    {
        Task<IEnumerable<Students>> GetAllStudentsAsync();
        Task<Students?> GetStudentByIdAsync(int id);

        Task AddStudentAsync(Students student);

        Task UpdateStudentAsync(Students student);
        Task DeleteStudentAsync(int id);
    }
}
