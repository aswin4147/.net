using System.ComponentModel.DataAnnotations;

namespace LifelineHospital.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = "Please select a valid Patient.")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Appointment Date and Time is required.")]
        [DataType(DataType.DateTime)]
        public DateTime AppointmentDate { get; set; }
    }
}
