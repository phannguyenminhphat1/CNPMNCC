using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNPMNC.Models;

namespace CNPMNC.Areas.admin.Controllers
{
    public class DefaultController : Controller
    {
        private DBEntities db = new DBEntities();
        // GET: admin/Default
        [HttpGet]
        public ActionResult Login()
        {
            if(Session["admin"] != null)
            {
                return RedirectToAction("Index", "Home");

            }
            return View();
        }


        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var usr = username;
            var pwd = password;
            var acc = db.Admins.SingleOrDefault(x => x.TaiKhoan == usr && x.MatKhau == pwd);
            if (acc != null)
            {
                Session["admin"] = acc;
                return RedirectToAction("Index", "Home");
            }
            
            return View();
        }
    }
}