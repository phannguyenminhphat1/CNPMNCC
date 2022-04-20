using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNPMNC.Models;

namespace CNPMNC.Areas.admin.Controllers
{
    public class GiaoVienController : BaseController
    {
        private DBEntities db = new DBEntities();
        // GET: admin/GiaoVien
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult AllGiaoVien()
        {
            try
            {
                var dsGv = (from gv in db.GiaoViens.Where(x => x.DaXoa != 1)
                            select new
                            {
                                
                                MaGiaoVien = gv.MaGiaoVien,
                                HoTen = gv.HoTen
                            }).ToList();
                return Json(new { code = 200, dsGv = dsGv, msg = "Lấy danh sách giáo viên thành công !" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                return Json(new { code = 500, msg = "Lấy danh sách giáo viên thất bại !"+ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }
    }
}