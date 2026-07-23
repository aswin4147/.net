using BusinessLogic.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifelineHospital.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        private readonly ILHMRepo _repo;

        public PatientController(ILHMRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LifelineHospital.Models.Patient patient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = new BusinessLogic.Models.Patient
                    {
                        PatientName = patient.PatientName,
                        DateOfBirth = patient.DateOfBirth,
                        ContactNo = patient.ContactNo
                    };

                    bool isSaved = _repo.AddPatient(data);
                    if (isSaved)
                    {
                        return RedirectToAction("Index");
                    }
                    ViewBag.ErrorMessage = "Database error: Could not save patient.";
                }
                return View(patient);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An unexpected error occurred: " + ex.Message;
                return View(patient);
            }
        }

        public IActionResult Index()
        {
            var patients = _repo.GetAllPatients();
            return View(patients);
        }

        public IActionResult Details(int id)
        {
            var patient = _repo.GetPatientById(id);
            if (patient == null) return NotFound();

            return View(patient);
        }
    }
}
