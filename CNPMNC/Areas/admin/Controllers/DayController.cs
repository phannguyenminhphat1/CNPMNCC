using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNPMNC.Models;

namespace CNPMNC.Areas.admin.Controllers
{
   
    public class DayController : BaseController
    {
        private DBEntities db = new DBEntities();
        // GET: admin/Day
        public ActionResult Index()
        {
            return View();
        }

        //Lấy ds giảng dạy
        public JsonResult List ()
        {
            try
            {
                var rs = (from d in db.Days.Where(x=>x.DaXoa!=1)
                          join gv in db.GiaoViens on d.MaGiaoVien equals gv.MaGiaoVien
                          join mh in db.MonHocs on d.MaMonHoc equals mh.MaMonHoc
                          select new
                          {
                              MaDay = d.MaDay,
                              TenGv = gv.HoTen,
                              TenMh = mh.TenMonHoc,
                              TuNgay = d.TuNgay,
                              ToiNgay = d.ToiNgay
                          }).ToList();
                return Json(new { code = 200, rs = rs, msg = "Lấy danh sách giảng dạy thành công !" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                return Json(new { code = 500, msg = "Lấy danh sách giảng dạy thất bại !"+ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }

        //Add
        [HttpPost]
        public JsonResult  AddDay(int maGV, int maMH, DateTime tuNgay,DateTime toiNgay)
        {
            try
            {
                var day = new Day();
                day.MaGiaoVien = maGV;
                day.MaMonHoc = maMH;
                day.TuNgay = tuNgay;
                day.ToiNgay = toiNgay;

                db.Days.Add(day);
                db.SaveChanges();

                return Json(new { code = 200, msg = "Thêm mới quá trình giảng dạy thành công !" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { code = 500, msg = "Thêm mới quá trình giảng dạy thất bại !"+ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }


        //Cap nhat
        [HttpPost]
        public JsonResult EditDay(int id,int maGV, int maMH, DateTime tuNgay, DateTime toiNgay)
        {   
            try
            {
                //Lấy ra id cần update
                var day = db.Days.SingleOrDefault(x=>x.MaDay == id);
                day.MaGiaoVien = maGV;
                day.MaMonHoc = maMH;
                day.TuNgay = tuNgay;
                day.ToiNgay = toiNgay;

                db.SaveChanges();

                return Json(new { code = 200, msg = "Cập nhật quá trình giảng dạy thành công !" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { code = 500, msg = "Cập nhật quá trình giảng dạy thất bại !" + ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }



        //Xoa
        [HttpPost]
        public JsonResult DeleteDay(int id)
        {
            try
            {
                //Lấy ra id cần update
                var day = db.Days.SingleOrDefault(x => x.MaDay == id);

                //Cập nhật lại trạng thái đã xóa = 1
                day.DaXoa = 1;

                db.SaveChanges();

                return Json(new { code = 200, msg = "Xóa quá trình giảng dạy thành công !" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { code = 500, msg = "Xóa quá trình giảng dạy thất bại !" + ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }
    }
}