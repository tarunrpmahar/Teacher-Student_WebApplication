using System.Web.Mvc;
using System.Data.SqlClient;
using Application.Models;

namespace Application.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        // GET: Account
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
            cmd.CommandText = "select * from tbl_Userlogin where username='" + acc.Name + "' and password='" + acc.password + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return RedirectToAction("AddUserResource");
            }
            else
            {
                con.Close();
                return View("Error");
            }
        }
        public ActionResult AddUserResource()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }
    }
}