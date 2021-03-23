using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Models;
using System.Net;

namespace Application.Controllers
{
    public class AddResourceController : Controller
    {
        TeacherStudentConnectEntities db = new TeacherStudentConnectEntities();
        // GET: AddResource
        public ActionResult Index()
        {
            return View(db.resources.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, resource res)
        {

            string filename = Path.GetFileName(file.FileName);
            string _filename = DateTime.Now.ToString("yymmssff") + filename;

            string extension = Path.GetExtension(file.FileName);
            string path = Path.Combine(Server.MapPath("~/User_Images/"), _filename);
            res.images = "~/User_Images/" + _filename;

            if (extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".jpeg")
            {
                db.resources.Add(res);
                if (db.SaveChanges() > 0)
                {
                    file.SaveAs(path);
                    ViewBag.msg = "Resource Added Successfully";
                    ModelState.Clear();
                }
            }
            else
            {
                ViewBag.msg = "Invalid file type";
            }
            return View();
        }
        //public ActionResult Edit(int? Id)
        //{
        //    //ResourceClass resource = UpdateClass.GetResourceList.Single(List => List.ResId == Id);
        //    //return View(resource);
        //    if (Id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    var resource = db.resource.Find(Id);
        //    if (resource == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(resource);
        //}
    }
}