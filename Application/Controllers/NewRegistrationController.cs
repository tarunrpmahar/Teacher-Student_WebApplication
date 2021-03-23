using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeacherStudentConnect.Models;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using Application.Models;

namespace TeacherStudentConnect.Controllers
{
    public class NewRegistrationController : Controller
    {
        // GET: NewRegistration
        public ActionResult NewUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewUser(UserClass uc, HttpPostedFileBase file)
        {
            //string myconstr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(Helper.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spNewUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@fname", uc.Fname);
                cmd.Parameters.AddWithValue("@lname", uc.Lname);
                cmd.Parameters.AddWithValue("@age", uc.Age);
                cmd.Parameters.AddWithValue("@gender", uc.Gender);
                cmd.Parameters.AddWithValue("@contact", uc.Contact);
                cmd.Parameters.AddWithValue("@category", uc.Category);
                cmd.Parameters.AddWithValue("@username", uc.Username);
                cmd.Parameters.AddWithValue("@password", uc.Password);
                if (file != null && file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string imgpath = Path.Combine(Server.MapPath("~/User_Images/"), filename);
                    file.SaveAs(imgpath);
                }
                cmd.Parameters.AddWithValue("@picture", "~/User_Images/"+file.FileName);
                cmd.ExecuteNonQuery();               
            }
            return RedirectToAction("UserStatus","NewRegistration");
            //ViewData["Message"] = "User Record" + uc.Username + "Is saved successfully";
        }
        public ActionResult UserStatus()
        {
            return View();
        }
    }
}