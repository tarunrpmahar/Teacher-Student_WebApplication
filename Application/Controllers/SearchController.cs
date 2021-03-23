using System.Linq;
using System.Web.Mvc;
using Application.Models;

namespace Application.Controllers
{
    public class SearchController : Controller
    {
        TeacherStudentConnectEntities db = new TeacherStudentConnectEntities();

        // GET: Search
        public ActionResult Index(string search, string SearchBy)
        {
            //ViewBag.sortBytitle = string.IsNullOrEmpty(sortBy) ? "title desc" : "";
            //ViewBag.sortBysubjects = sortBy=="subjects" ? "subjects desc" : "subjects";

            //var res = db.resources.AsQueryable(); 
            if (SearchBy == "subjects")
            {
                var res=db.resources.Where(x => x.subjects.StartsWith(search) || search==null).ToList();
                if (res.Count == 0)
                {
                    ViewBag.msg = "Resource not found";
                }
                return View(res);
            }
            else
            {
                var res = db.resources.Where(x => x.title.StartsWith(search) || search == null).ToList();
                return View(res);
            }
        }
    }
}