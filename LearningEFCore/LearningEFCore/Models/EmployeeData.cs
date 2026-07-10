using System.ComponentModel.DataAnnotations;

namespace LearningEFCore.Models
{
    public class EmployeeData
    {
        [Key]
        public int EmpID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Dob { get; set; }

    }
}
