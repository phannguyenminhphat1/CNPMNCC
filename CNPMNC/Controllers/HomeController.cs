using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using CNPMNC.Models;

namespace CNPMNC.Controllers
{
    
    public class HomeController : Controller
    {
        //private TracNghiemEntities db = new TracNghiemEntities();
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult RenderMenu()
        {
            //var dsLop = db.Lops.ToList();
            //ViewBag.listdsLop = dsLop;

            //var dsMH = db.MonHocs.ToList();
            //ViewBag.listMH = dsMH;



            return PartialView("_Navbar");
        }
    }
}