using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNPMNC.Models;

namespace CNPMNC.Areas.admin.Controllers
{
    public class MonHocController : BaseController
    {
        private DBEntities db = new DBEntities();
        // GET: admin/MonHoc
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult DsMonHoc(string tuKhoa)
        {
            try
            {
                var dsMonHoc = (from m in db.MonHocs 
                                .Where(x => x.DaXoa !=1 && x.TenMonHoc.ToLower().Contains(tuKhoa))
                                join l in db.Lops on m.MaLop equals l.MaLop
                                select new
                             {
                                 MaLop = m.MaLop,
                                 TenMonHoc = m.TenMonHoc,
                                 Meta = m.Meta,
                                 TenLop = l.TenLop


                             }).ToList();
                return Json(new { code = 200, dsMonHoc = dsMonHoc, msg = "Lấy danh sách môn học thành công !" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { code = 500, msg = "Lấy danh sách môn học thất bại" + ex.Message, JsonRequestBehavior.AllowGet });

            }
        }


        //Thêm môn học
        [HttpPost]
        public JsonResult AddMonHoc(string tenMonHoc, string metaMonHoc, int idLop)
        {
            try
            {
                //Khai báo 1 object Môn học
                var mh = new MonHoc();

                //Gán bằng cái ng dùng nhập vào
                mh.TenMonHoc = tenMonHoc;
                mh.Meta = metaMonHoc;
                mh.MaLop = idLop;

                db.MonHocs.Add(mh);
                
                db.SaveChanges();

                return Json(new { code = 200, msg = "Thêm mới môn học thành công !" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                return Json(new { code = 500, msg = "Thêm mới môn học thất bại !" + ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }

        //Cập nhật môn học
        [HttpPost]
        public JsonResult EditMonHoc(int id,string tenMonHoc, string metaMonHoc, int idLop)
        {
            try
            {
                //Tìm môn học dựa vào ID truyền vào
                var mh = db.MonHocs.SingleOrDefault(x=>x.MaMonHoc == id);

                //Gán bằng cái ng dùng nhập vào
                mh.TenMonHoc = tenMonHoc;
                mh.Meta = metaMonHoc;
                mh.MaLop = idLop;

                db.SaveChanges();

                return Json(new { code = 200, msg = "Cập nhật môn học thành công !" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                return Json(new { code = 500, msg = "Cập nhật môn học thất bại !" + ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpPost]
        public JsonResult xoa(int id)
        {
            try
            {
                var mh = db.MonHocs.SingleOrDefault(x => x.MaMonHoc == id);
                mh.DaXoa = 1;
                db.SaveChanges();
                return Json(new { code = 200, msg = "Xóa môn học thành công !" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                return Json(new { code = 500, msg = "Xóa môn học thất bại !" + ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpGet]
        public JsonResult ChiTiet(int id)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var mh = db.MonHocs.SingleOrDefault(x => x.MaMonHoc == id);
                return Json(new { code = 200, mh = mh , msg = "Lấy môn học thành công !" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                return Json(new { code = 500, msg = "Lấy môn học thất bại !"+ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpGet]
        public JsonResult AllMonHoc()
        {
            try
            {
                var allMh = (from mh in db.MonHocs.Where(x => x.DaXoa != 1)
                             select new
                             {
                                 MaMonHoc = mh.MaMonHoc,
                                 TenMH = mh.TenMonHoc
                             }).ToList();
                return Json(new { code = 200, allMh = allMh, msg = "Lấy danh sách môn học thành công !" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { code = 200, msg = "Lấy danh sách môn học thất bại !"+ex.Message }, JsonRequestBehavior.AllowGet);

                
            }
        }
    }
}