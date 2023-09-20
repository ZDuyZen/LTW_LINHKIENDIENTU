using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using QuanLyThietBi.Models;

namespace QuanLyThietBi.Controllers
{
    public class QuanLyController : Controller
    {
        //
        // GET: /QuanLy/
        ThietBiDataContext db = new ThietBiDataContext();

        public ActionResult Index_QL()
        {
            return View();
        }

        public ActionResult QL_LoaiSanPham()
        {
            List<LOAISP> lsp = db.LOAISPs.ToList();
            return View(lsp);
        }
        public ActionResult Tao_LSP()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Tao_LSP(LOAISP loai)
        {
            db.LOAISPs.InsertOnSubmit(loai);
            db.SubmitChanges();
            return RedirectToAction("QL_LoaiSanPham");
        }

        public ActionResult Sua_LSP(int id)
        {
            LOAISP lsp = db.LOAISPs.FirstOrDefault(t => t.MALSP == id);
            return View(lsp);
        }
        [HttpPost]
        public ActionResult Sua_LSP(int id, LOAISP loai)
        {
            LOAISP lsp = db.LOAISPs.FirstOrDefault(t => t.MALSP == id);
            lsp.TENLSP = loai.TENLSP;
            UpdateModel(lsp);
            db.SubmitChanges();
            return RedirectToAction("QL_LoaiSanPham");
        }
        public ActionResult xoa_LSP(int id)
        {
            LOAISP lsp = db.LOAISPs.FirstOrDefault(t => t.MALSP == id);
            return View(lsp);
        }
        [HttpPost]
        public ActionResult xoa_LSP(int id, LOAISP loai)
        {
            LOAISP f = db.LOAISPs.FirstOrDefault(t => t.MALSP == id);
            db.LOAISPs.DeleteOnSubmit(f);
            db.SubmitChanges();
            return RedirectToAction("QL_LoaiSanPham");
        }

        public ActionResult QL_SanPham()
        {
            List<SANPHAM> sp = db.SANPHAMs.ToList();
            return View(sp);
        }

        public ActionResult Them_SP()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Them_SP(SANPHAM loai)
        {
            db.SANPHAMs.InsertOnSubmit(loai);
            db.SubmitChanges();
            return RedirectToAction("QL_SanPham");
        }

        public ActionResult Sua_SP(int id)
        {
            SANPHAM lsp = db.SANPHAMs.FirstOrDefault(t => t.MASP == id);
            return View(lsp);
        }
        [HttpPost]
        public ActionResult Sua_SP(int id, SANPHAM loai)
        {
            SANPHAM lsp = db.SANPHAMs.FirstOrDefault(t => t.MASP == id);
            lsp.MOTA = loai.MOTA;
            lsp.TENSP = loai.TENSP;
            UpdateModel(lsp);
            db.SubmitChanges();
            return RedirectToAction("QL_SanPham");
        }

        public ActionResult xoa_SP(int id)
        {
            SANPHAM lsp = db.SANPHAMs.FirstOrDefault(t => t.MASP == id);
            return View(lsp);
        }
        [HttpPost]
        public ActionResult xoa_SP(int id, SANPHAM loai)
        {
            SANPHAM f = db.SANPHAMs.FirstOrDefault(t => t.MASP == id);
            db.SANPHAMs.DeleteOnSubmit(f);
            db.SubmitChanges();
            return RedirectToAction("QL_SanPham");
        }

        public ActionResult QL_DonHang()
        {
            List<DONHANG> cthd = db.DONHANGs.ToList();
            return View(cthd);
        }

        public ActionResult Them_DH()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Them_DH(DONHANG loai)
        {
            db.DONHANGs.InsertOnSubmit(loai);
            db.SubmitChanges();
            return RedirectToAction("QL_DonHang");
        }

        public ActionResult Sua_DH(int id)
        {
            DONHANG lsp = db.DONHANGs.FirstOrDefault(t => t.MADH == id);
            return View(lsp);
        }
        [HttpPost]
        public ActionResult Sua_DH(int id, DONHANG loai)
        {
            DONHANG lsp = db.DONHANGs.FirstOrDefault(t => t.MADH == id);
            lsp.NGAYDAT = loai.NGAYDAT;
            lsp.NGAYGIAO = loai.NGAYGIAO;
            lsp.DATHANHTOAN = loai.DATHANHTOAN;
            lsp.TINHTRANGGIAOHANG = loai.DATHANHTOAN;
            UpdateModel(lsp);
            db.SubmitChanges();
            return RedirectToAction("QL_DonHang");
        }
      

        public ActionResult xoa_DH(int id)
        {
            DONHANG lsp = db.DONHANGs.FirstOrDefault(t => t.MADH == id);
            return View(lsp);
        }
        [HttpPost]
        public ActionResult xoa_DH(int id, DONHANG loai)
        {
            DONHANG f = db.DONHANGs.FirstOrDefault(t => t.MADH == id);
            db.DONHANGs.DeleteOnSubmit(f);
            db.SubmitChanges();
            return RedirectToAction("QL_DonHang");
        }
    }
}
