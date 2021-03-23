using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Models;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace Application.Controllers
{
    public class NewRegAdminController : Controller
    {
        // GET: NewRegAdmin
        public ActionResult NewAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewAdmin(AdminClass uc)
        {
            string myconstr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            SqlConnection con = new SqlConnection(myconstr);
            con.Open();
            SqlCommand cmd = new SqlCommand("spNewAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fname", uc.Fname);
            cmd.Parameters.AddWithValue("@lname", uc.Lname);
            cmd.Parameters.AddWithValue("@age", uc.Age);
            cmd.Parameters.AddWithValue("@gender", uc.Gender);
            cmd.Parameters.AddWithValue("@contact", uc.Contact);
            cmd.Parameters.AddWithValue("@Adminusername", uc.Username);
            cmd.Parameters.AddWithValue("@Adminpassword", uc.Password);
            cmd.ExecuteNonQuery();
            con.Close();
            //ViewData["Message"] = "User Record" + uc.Username + "Is saved successfully";
            return View("RegisterStatus");
        }
        public ActionResult RegisterStatus()
        {
            return View();
        }
    }
}