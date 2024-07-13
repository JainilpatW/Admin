using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeModel model = new HomeModel();
            if (Session["Email"] == null)
            {
                return RedirectToAction("Login");
            }
            BLLRepo repo = new BLLRepo();
            var appointment = repo.GetAppointmentList(Session["Email"].ToString() == "admin@gmail.com" ? "" : Session["Email"].ToString());
            if (appointment != null && appointment.Any())
            {
                model.lstAppointment = appointment;
            }
            return View(model);
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult EditAppointment(PatientAppointment appointment)
        {
            BLLRepo repo = new BLLRepo();
            int result = repo.UpdateAppointment(appointment);
            if (result > 0)
            {
                return Json(new { IsSuccess = true, Message = "Sucess" });
            }
            else
            {
                return Json(new { IsSuccess = false, Message = "Fail" });
            }
        }

        [HttpPost]
        public JsonResult removeAppointment(int appointmentId)
        {
            BLLRepo repo = new BLLRepo();
            int result = repo.removeAppointment(appointmentId);
            if (result > 0)
            {
                return Json(new { IsSuccess = true, Message = "Sucess" });
            }
            else
            {
                return Json(new { IsSuccess = false, Message = "Fail" });
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult ValidateLogin(LoginModel obj)
        {
            BLLRepo repo = new BLLRepo();
            ViewBag.Message = "Your contact page.";
            var users = repo.validateUser(obj);
            if (users == null)
            {
                return Json(new { IsSuccess = false, Message = "Invalid Email Or Password!" });
            }
            else
            {
                Session["Email"] = users.Email_ID;
                Session["Name"] = users.FullName;
                return Json(new { IsSuccess = true, Message = "Success" });
            }
        }
    }
}