using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Models;
using System.Data;
using System.IO;

namespace Application.Controllers
{
    public class ResourceListController : Controller
    {
        // GET: ResourceList
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowResourceListAction()
        {
            ResourceList showResourceList = new ResourceList();
            return View(showResourceList.GetResourceList());
        }

        public ActionResult ShowResourceListForSearching()
        {
            ResourceList showResourceList = new ResourceList();
            return View(showResourceList.GetResourceList());
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            ResourceClass resource = UpdateClass.GetResourceList.Single(List => List.ResId == Id);
            return View(resource);
        }

        [HttpPost]
        public ActionResult Edit(ResourceClass resourceClass, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(Helper.connectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("spUpdateRes", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@re_id", resourceClass.ResId);

                    if (file != null && file.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(file.FileName);
                        var imgpath = Path.Combine(Server.MapPath("~/Temp/"), filename);
                        file.SaveAs(imgpath);
                    }
                    cmd.Parameters.AddWithValue("@images", "~/Temp/" + file.FileName);
                    cmd.Parameters.AddWithValue("@title", resourceClass.Title);
                    cmd.Parameters.AddWithValue("@author", resourceClass.Author);
                    cmd.Parameters.AddWithValue("@subjects", resourceClass.Subject);
                    cmd.Parameters.AddWithValue("@years", resourceClass.Years);
                    cmd.Parameters.AddWithValue("@descriptions", resourceClass.Files);
                    cmd.ExecuteNonQuery();
                }
                return RedirectToAction("UpdateStatus");
            }
            return View(resourceClass);
        }
        public ActionResult UpdateStatus()
        {
            return View();
        }
    }
}