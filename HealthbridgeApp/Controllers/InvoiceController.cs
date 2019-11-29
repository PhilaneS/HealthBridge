using HealthbridgeApi.Dto;
using HealthbridgeApiHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthbridgeApp.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceRepository _repo;

        public InvoiceController(IInvoiceRepository repo)
        {
            _repo = repo;
        }
        // GET: Invoice
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetInvoices()
        {
            var response = _repo.GetInvoices();
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        // GET: Invoice/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetInvoiceById(int id)
        {
            var response = _repo.GetInvoiceById(id);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult createInvoice(InvoiceForCaptureDto d)
        {
            var response = _repo.AddInvoice(d);
            return Json(response, JsonRequestBehavior.AllowGet); ;
        }

        [HttpPost]
        public JsonResult updateInvoice(InvoiceForCaptureDto data) {
            var response = _repo.UpdateInvoice(data);
            return Json(response, JsonRequestBehavior.AllowGet); ;
        }

        [HttpPost]
        public JsonResult DeleteInvoiceItem(InvoiceLineDto lineDto)
        {
            var response = _repo.DeleteInvoiceItem(lineDto.InvoiceLineId);
            return Json(response, JsonRequestBehavior.AllowGet); ;
        }
        public ActionResult Capture()
        {
            return View();
        }
    }
}
