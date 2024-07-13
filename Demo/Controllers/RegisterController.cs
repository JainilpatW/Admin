using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            DoctorRegisterModel model = new DoctorRegisterModel();
            List<SelectListItem> docType = new List<SelectListItem>();
            docType.Add(new SelectListItem { Text = "Psychiartrist", Value = "Psychiartrist" });
            docType.Add(new SelectListItem { Text = "Cardiologist", Value = "Cardiologist" });
            docType.Add(new SelectListItem { Text = "Neurologist", Value = "Neurologist" });
            ViewBag.DocType = docType;

            List<SelectListItem> hospital = new List<SelectListItem>();
            hospital.Add(new SelectListItem { Text = "Unity Hospital", Value = "18" });
            hospital.Add(new SelectListItem { Text = "Sardar Hospital", Value = "19" });
            hospital.Add(new SelectListItem { Text = "Surbhi Hospital", Value = "20" });
            hospital.Add(new SelectListItem { Text = "Orange Hospital", Value = "21" });
            hospital.Add(new SelectListItem { Text = "Shradha Hospital", Value = "22" });
            ViewBag.Hospitals = hospital;
            return View(model);
        }
        [HttpPost]
        public ActionResult SaveDoctor(DoctorRegisterModel model)
        {
            model.City = "Navsari";
            model.State = "Gujarat";
            model.Added_Date = DateTime.Now;
            BLLRepo repo = new BLLRepo();
            int result = repo.AddDoctor(model);
            if (result > 0)
            {
                return RedirectToAction("DocList");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult DocList()
        {
            DoctorModel model = new DoctorModel();
            BLLRepo repo = new BLLRepo();
            model.lstDoctor = repo.GetDoctorList();
            return View(model);
        }
    }
}