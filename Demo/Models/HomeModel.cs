using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    public class HomeModel
    {
        public HomeModel()
        {
            lstAppointment = new List<PatientAppointment>();
        }
        public List<PatientAppointment> lstAppointment { get; set; }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class UserModel
    {
        public string FullName { get; set; }
        public string Email_ID { get; set; }
        public string Pwd { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
    }

    public class PatientAppointment
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Email_Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string DocName { get; set; }
        public string HospitalName { get; set; }
        public DateTime App_Date { get; set; }
        public int Age { get; set; }
    }
}