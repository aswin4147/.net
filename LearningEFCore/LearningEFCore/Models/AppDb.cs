using Microsoft.EntityFrameworkCore;

namespace LearningEFCore.Models
{
    public class AppDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MAAL\\SQLEXPRESS;Database=db_Employee;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<EmployeeData> EmployeeTable { get; set; }
    }
}
