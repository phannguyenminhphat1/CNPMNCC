using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNPMNC.Models;

namespace CNPMNC.Areas.admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: admin/Home
        public ActionResult Index()
        {
            
            return View();
        }
        [ChildActionOnly]
        public ActionResult RenderMenu()
        {
            return PartialView("_Navbar");
        }
    }
}