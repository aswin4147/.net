using BusinessLogic.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifelineHospital.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private readonly ILHMRepo _repo;

        public AppointmentController(ILHMRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LifelineHospital.Models.Appointment appointment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = new BusinessLogic.Models.Appointment
                    {
                        PatientId = appointment.PatientId,
                        AppointmentDate = appointment.AppointmentDate
                    };

                    bool isSaved = _repo.AddAppointment(data);
                    if (isSaved)
                    {
                        return RedirectToAction("Index");
                    }
                    ViewBag.ErrorMessage = "Database error: Could not save appointment.";
                }
                return View(appointment);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An unexpected error occurred: " + ex.Message;
                return View(appointment);
            }
        }

        public IActionResult Index()
        {
            var appointments = _repo.GetAllAppointments();
            return View(appointments);
        }
    }
}
