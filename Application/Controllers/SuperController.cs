using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using Application.Models;

namespace TeacherStudentConnect.Controllers
{
    public class SuperController : Controller
    {
        // GET: Super
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        // GET: Admin
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data source=MSI\\SQLEXPRESS; database=TeacherStudentConnect; integrated security=SSPI;";
        }

        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from tbl_Superlogin where Superusername='" + acc.Name + "' and Superpassword='" + acc.password + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return RedirectToAction("ShowAdminListAction","AdminList");
            }
            else
            {
                con.Close();
                return View("Error");
            }
        }

    }
}