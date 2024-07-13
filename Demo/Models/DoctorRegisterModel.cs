using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    public class DoctorModel
    {
        public DoctorModel()
        {
            lstDoctor = new List<DoctorRegisterModel>();
        }
        public List<DoctorRegisterModel> lstDoctor { get; set; }
    }
    public class DoctorRegisterModel
    {
        public int Doc_Id { get; set; }
        public int Hospital_Id { get; set; }
        public string Hospital { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Doc_Type { get; set; }
        public DateTime Added_Date { get; set; }
    }
}