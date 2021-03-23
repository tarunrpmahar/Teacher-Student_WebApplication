using Application.Models;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Application.Controllers
{
    public class ResourceController : Controller
    {
        // GET: Resource
        public ActionResult AddTblResource()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTblResource(ResourceClass uc, HttpPostedFileBase file)
        {
            using (SqlConnection con = new SqlConnection(Helper.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spresource", con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (file != null && file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string imgpath = Path.Combine(Server.MapPath("~/Cover_page/"), filename);
                    file.SaveAs(imgpath);
                }
                cmd.Parameters.AddWithValue("@images", "~/Cover_page/" + file.FileName);
                cmd.Parameters.AddWithValue("@title", uc.Title);
                cmd.Parameters.AddWithValue("@author", uc.Author);
                cmd.Parameters.AddWithValue("@subjects", uc.Subject);
                cmd.Parameters.AddWithValue("@years", uc.Years);
                cmd.Parameters.AddWithValue("@descriptions", uc.Files);                
                cmd.ExecuteNonQuery();
            }
            return View("AddedStatus");
        }
        public ActionResult AddedStatus()
        {
            return View();
        }
    }
}