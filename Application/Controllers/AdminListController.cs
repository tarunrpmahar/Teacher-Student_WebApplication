using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Models;
using System.Data;
using System.Data.SqlClient;

namespace Application.Controllers
{
    public class AdminListController : Controller
    {
        // GET: AdminList
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowAdminListAction()
        {
            ShowAdminList showAdminList = new ShowAdminList();
            return View(showAdminList.GetTempAdminList());
        }

        public ActionResult Approve()
        {
            return View();
            /*return RedirectToAction("Login","Admin")*/;
        }

        public ActionResult Delete(int Id)//
        {
            ShowAdminList showAdminList = new ShowAdminList();
            AdminClass adminClass = new AdminClass();
            showAdminList.GetTempAdminList().Single(List => List.Id == Id);
            ViewBag.msg = adminClass.Username;
            using (SqlConnection con = new SqlConnection(Helper.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spRejectAdmin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Adminid", Id);
                cmd.ExecuteNonQuery();
            }
            return View();
        }
    }
}