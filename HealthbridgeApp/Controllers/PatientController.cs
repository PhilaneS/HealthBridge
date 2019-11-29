using HealthbridgeApi.Dto;
using HealthbridgeApiHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthbridgeApp.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository) {

            _patientRepository = patientRepository;
        }
        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetPatientList() {
            var response = _patientRepository.GetPatients();
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Register(PatientDto data)
        {
            var response = _patientRepository.Register(data);
            return Json(response,JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetPatientById(int? id) {
            if (id.HasValue && id.Value > 0) //Check Id has value or null
            {
                var patient = _patientRepository.GetPatientById(id); 
                if (patient != null)
                {
                    return Json(patient, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { Status = "Failure" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Detail() {
            return View();
        }
        [HttpPost]
        public JsonResult UpdatePatient(PatientDto dtoToupdate)
        {
            var response = _patientRepository.updatePatient(dtoToupdate);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeletePatient(PatientDto data)
        {
            var response = _patientRepository.DeletePatient(data);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}