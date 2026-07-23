using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    public interface ILHMRepo
    {
        public bool AddPatient(Patient patient);
        public Patient GetPatientById(int id);
        public List<Patient> GetAllPatients();
        public bool AddAppointment(Appointment appointment);
        public List<Appointment> GetAllAppointments();
    }
}
