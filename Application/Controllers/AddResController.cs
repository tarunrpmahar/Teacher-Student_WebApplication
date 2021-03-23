using Application.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using System.Diagnostics;

namespace Application.Controllers
{
    public class AddResController : Controller
    {
        TeacherStudentConnectEntities db = new TeacherStudentConnectEntities();


        // GET: AddRes
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

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var reso = db.resources.Find(id);
            Session["imgPath"] = reso.images;
            if (reso == null)
            {
                return HttpNotFound();
            }
            return View(reso);
        }

        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase file, resource res)
        {
            //if (ModelState.IsValid)
            //{
            if (file != null)
            {
                string filename = Path.GetFileName(file.FileName);
                string _filename = DateTime.Now.ToString("yymmssff") + filename;
                string extension = Path.GetExtension(file.FileName);
                string path = Path.Combine(Server.MapPath("~/User_Images/"), _filename);

                res.images = "~/User_Images/" + _filename;

                if (extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".jpeg")
                {
                    db.Entry(res).State = EntityState.Modified;
                    string oldImgPath = Request.MapPath(Session["imgPath"].ToString());
                    if (db.SaveChanges() > 0)
                    {
                        file.SaveAs(path);
                        if (System.IO.File.Exists(oldImgPath))
                        {
                            System.IO.File.Delete(oldImgPath);
                        }
                        TempData["msg"] = "Resource Updated Successfully";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewBag.msg = "Invalid file type";
                }
            }
            else
            {
                res.images = Session["imgPath"].ToString();
                db.Entry(res).State = EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    TempData["msg"] = "Resource Updated";
                    return RedirectToAction("Index");
                }
            }
            //}
            return View();
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var resource = db.resources.Find(id);

            if (resource == null)
            {
                return HttpNotFound();
            }
            string currentImg = Request.MapPath(resource.images);
            db.Entry(resource).State = EntityState.Deleted;
            if (db.SaveChanges() > 0)
            {
                if (System.IO.File.Exists(currentImg))
                {
                    System.IO.File.Delete(currentImg);
                }
                TempData["msg"] = "Resource Deleted";
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}