using System.ComponentModel.DataAnnotations;

namespace LifelineHospital.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Please enter the patient's name.")]
        [MinLength(2, ErrorMessage = "Patient Name must be between 2 and 20 characters.")]
        [MaxLength(20, ErrorMessage = "Patient Name must be between 2 and 20 characters.")]
        public string PatientName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Contact number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Please enter a valid 10-digit contact number.")]
        public string ContactNo { get; set; }
    }
}
