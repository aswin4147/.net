using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class BookLogin
    {
        [Key]
        public int Id { get; set; }
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Name can only contain letters and spaces.")]
        [Required(ErrorMessage ="Enter your name")]
        public string Name { get; set; }
        public string Role { get; set; } = "User";
        [Required(ErrorMessage = "Enter your email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter your password")]
        [MinLength(6)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Enter the password again for verification")]
        [NotMapped]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
