using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNPMNC.Models;
using PagedList;

namespace CNPMNC.Areas.admin.Controllers
{
    public class LopController : BaseController
    {
        private DBEntities db = new DBEntities();
        // GET: admin/Lop
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult DsLop(string tuKhoa )
        {
            try
            {
                var dsLop = (from l in db.Lops.Where(x => x.DaXoa != 1 && x.TenLop.ToLower().Contains(tuKhoa))
                             select new
                             {
                                 MaLop = l.MaLop,
                                 TenLop = l.TenLop,
                                 Meta = l.Meta,
                                 DaXoa = l.DaXoa,

                             }).ToList();
                return Json(new { code = 200, dsLop = dsLop,msg ="Lấy danh sách lớp thành công !" },JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { code = 500,msg =  "Lấy danh sách lớp thất bại" + ex.Message, JsonRequestBehavior.AllowGet });

            }
        }


        [HttpGet]
        public JsonResult AllLop()
        {
            try
            {
                var allLop = (from l in db.Lops.Where(x => x.DaXoa != 1) select new {
                    MaLop = l.MaLop,
                    TenLop = l.TenLop
                }).ToList();
                return Json(new { code = 200, allLop = allLop, msg = "Load danh sách lớp thành công !" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                return Json(new { code = 500, msg = "Load danh sách lớp thất bại" + ex.Message, JsonRequestBehavior.AllowGet });

            }
        }
        [HttpPost]
        public JsonResult AddLop(string tenLop, string meta)
        {
            try
            {
                var l = new Lop();
                l.TenLop = tenLop;
                l.Meta = meta;
                db.Lops.Add(l);
                db.SaveChanges();
                return Json(new { code = 200, msg = "Thêm lớp mới thành công !" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Thêm lớp mới thất bại !"+ex.Message }, JsonRequestBehavior.AllowGet);

                throw;
            }
        }

        [HttpGet]
        public JsonResult ChiTiet(int id)
        {
            try
            {
                var l = db.Lops.SingleOrDefault(x => x.MaLop == id);
                return Json(new { code = 200, L = l ,  msg = "Lấy thông tin chi tiết lớp thành công !" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Lấy thông tin lớp thất bại !" + ex.Message }, JsonRequestBehavior.AllowGet);
                throw;
            }
        }

        [HttpPost]

        public JsonResult CapNhat(int id,string tenLop, string meta)
        {
            try
            {
                var l = db.Lops.SingleOrDefault(x => x.MaLop == id);

                l.TenLop = tenLop;
                l.Meta = meta;
                db.SaveChanges();

                return Json(new { code = 200, msg = "Cập nhật lớp thành công !" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { code = 500, msg = "Cập nhật lớp thất bại !" + ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpPost]
        public JsonResult XoaLop(int id)
        {
            try
            {
                var l = db.Lops.SingleOrDefault(x => x.MaLop == id);
                l.DaXoa = 1; 
                db.SaveChanges();
                return Json(new { code = 200, msg = "Xóa lớp thành công !" }, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {

                return Json(new { code = 500, msg = "Xóa lớp học thất bại !" + ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }
    }
}