using System.Web.Mvc;
using System.Data.SqlClient;
using Application.Models;

namespace TeacherStudentConnect.Controllers
{
    public class AdminController : Controller
    {
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
            cmd.CommandText = "select * from tbl_Adminlogin where Adminusername='" + acc.Name + "' and Adminpassword='" + acc.password + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return RedirectToAction("AddResource");
            }
            else
            {
                con.Close();
                return View("Error");
            }
        }

        public ActionResult AddResource()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }
    }
}