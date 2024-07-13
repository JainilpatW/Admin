using Dapper;
using Demo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Demo
{
    public class BLLRepo
    {
        private static string connString = @"Data Source=JAINIL\SQLEXPRESS;Initial Catalog=DbDocter;Integrated Security=True";

        public UserModel validateUser(LoginModel login)
        {
            //string sqlqry = "SELECT * FROM tblRegister WHERE Email_ID = '" + login.Email + "' AND Pwd = '" + login.Password + "';";
            UserModel user = new UserModel();
            using (var connection = new SqlConnection(connString))
            {
                var sp_params = new Dapper.DynamicParameters();
                sp_params.Add("@Email", login.Email);
                sp_params.Add("@Pwd", login.Password);
                user = connection.Query<UserModel>("usp_AuthenticateUser", sp_params, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return user;
        }

        public List<PatientAppointment> GetAppointmentList(string EmailId)
        {
            //string sqlqry = "SELECT * FROM tblPatient WHERE '" + EmailId + "' = '' OR Email_Id = '" + EmailId + "'";
            List<PatientAppointment> appointments = new List<PatientAppointment>();
            using (var connection = new SqlConnection(connString))
            {
                var sp_params = new Dapper.DynamicParameters();
                sp_params.Add("@EmailId", EmailId);
                appointments = connection.Query<PatientAppointment>("usp_GetAppointMentList", param: sp_params, commandType: CommandType.StoredProcedure).ToList();
            }
            return appointments;
        }

        public int UpdateAppointment(PatientAppointment appointment)
        {
            string sqlqry = "UPDATE tblPatient SET App_Date = '" + appointment.App_Date.ToString("dd MMM yyyy hh:mm tt") + "' WHERE PatientId = " + appointment.PatientId;
            int result = 0;
            using (var connection = new SqlConnection(connString))
            {
                result = connection.Execute(sqlqry);
            }
            return result;
        }

        public int removeAppointment(int appointmentId)
        {
            string sqlqry = "DELETE FROM tblPatient WHERE PatientId = " + appointmentId;
            int result = 0;
            using (var connection = new SqlConnection(connString))
            {
                result = connection.Execute(sqlqry);
            }
            return result;
        }

        public int AddDoctor(DoctorRegisterModel model)
        {
            string sqlqry = "INSERT INTO tblDoctor (Hospital_Id, Name, Password, MobileNo, EmailId, Address, Doc_Type, Added_Date, City, State)";
            sqlqry += " VALUES(@Hospital_Id, @Name, @Password, @MobileNo, @EmailId, @Address, @Doc_Type, @Added_Date, @City, @State)";
            int result = 0;
            using (var connection = new SqlConnection(connString))
            {
                result = connection.Execute(sqlqry, new { 
                    model.Hospital_Id,
                    model.Name,
                    model.Password,
                    model.MobileNo,
                    model.EmailId,
                    model.Address,
                    model.Doc_Type,
                    model.Added_Date,
                    model.City,
                    model.State
                });
            }
            return result;
        }

        public List<DoctorRegisterModel> GetDoctorList()
        {
            List<DoctorRegisterModel> appointments = new List<DoctorRegisterModel>();
            using (var connection = new SqlConnection(connString))
            {
                appointments = connection.Query<DoctorRegisterModel>("usp_GetDoctorList").ToList();
            }
            return appointments;
        }
    }
}