using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    public class LHMRepo : ILHMRepo
    {
        private readonly LHMDbContext _context;

        public LHMRepo()
        {
            _context = new LHMDbContext();
        }

        public bool AddPatient(Patient patient)
        {
            try
            {
                _context.Patients.Add(patient);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Patient GetPatientById(int id)
        {
            return _context.Patients.Include(p => p.Appointments).FirstOrDefault(p => p.PatientId == id);
        }

        public List<Patient> GetAllPatients()
        {
            return _context.Patients.ToList();
        }

        public bool AddAppointment(Appointment appointment)
        {
            try
            {
                _context.Appointments.Add(appointment);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Appointment> GetAllAppointments()
        {
            return _context.Appointments.Include(a => a.Patient).ToList();
        }
    }
}
