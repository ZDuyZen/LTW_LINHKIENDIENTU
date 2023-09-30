using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using QuanLyThietBi.Models;
using System.Drawing;

namespace QuanLyThietBi.Controllers
{
    public class KhachHangController : Controller
    {
        //
        // GET: /KhachHang/
        ThietBiDataContext db = new ThietBiDataContext();
        public ActionResult Index_KH()
        {
            List<SANPHAM> sp = db.SANPHAMs.ToList();
            Session["TenDM"] = "Tất cả sản phẩm";

            return View(sp);
        }

        public ActionResult DS_LoaiSanPham()
        {
            List<LOAISP> lsp = db.LOAISPs.ToList();
            return PartialView(lsp);
        }

        public ActionResult DS_LoaiHang_LoaiSP()
        {
            List<LOAIHANG> lh = db.LOAIHANGs.ToList();
            List<LOAISP> lsp = db.LOAISPs.ToList();
            ViewBag.lsp = lsp; 
            return PartialView(lh);
        }

        public ActionResult DS_SanPham_theo_LoaiSP(int id)
        {
            List<SANPHAM> sp = db.SANPHAMs.Where(t=>t.MALSP == id).ToList();
            Session["TenDM"] = db.LOAISPs.FirstOrDefault(t => t.MALSP  == id).TENLSP;
            return View("Index_KH", sp);
        }

        public ActionResult XemChiTiet(int id)
        {
            SANPHAM sp = db.SANPHAMs.FirstOrDefault(t => t.MASP == id);
            List<LOAIHANG> lh = db.LOAIHANGs.ToList();
            List<LOAISP> lsp = db.LOAISPs.ToList();
            List<NHAXUATXU> nxx = db.NHAXUATXUs.ToList();

            ViewBag.lh = lh;
            ViewBag.lsp = lsp;
            ViewBag.nxx = nxx;
            Session["maSP"] = sp.MASP;

            return View(sp);
        }

        public ActionResult TimKiem()
        {
            ViewBag.lsp = db.LOAISPs.ToList();
            return View();
        }

        [HttpPost]

        public ActionResult XL_TimKiem(FormCollection fc)
        {
            string tenSP = fc["txtTen"];
            int LSP=Convert.ToInt32(fc["LSP"]);
            int giatritren, giatriduoi;
            giatritren = Convert.ToInt32(fc["txtgiaTren"]);
            giatriduoi = Convert.ToInt32(fc["txtgiaDuoi"]);

            List<SANPHAM> sp = db.SANPHAMs.Where(t => t.MALSP == LSP && t.TENSP.Contains(tenSP) && t.GIABAN >= giatriduoi && t.GIABAN <= giatritren).ToList();
            ViewBag.tt = "Sản phẩm " + tenSP + " có giá từ " + giatriduoi.ToString() + " VND đến " + giatritren.ToString() + "VND";
            return View(sp);

        }

        public void LuuGioHang(GioHang gio)
        {
            Session["gh"] = gio;
        }

        public GioHang layGioHang()
        {
            GioHang gio = (GioHang)Session["gh"];
            return gio;
        }

        public ActionResult ChonMua(int id)
        {
            GioHang gio = layGioHang();

            if (gio == null)
            {
                gio = new GioHang();
                gio.Them(id, 1);
            }
            else
            {
                Item s = gio.lstSP.FirstOrDefault(t => t.idSP == id);
                if (s == null)
                {
                    gio.Them(id, 1);
                }
                else
                {
                    s.soLuong++;
                }
            }

            LuuGioHang(gio);
            return RedirectToAction("Index_KH");

        }

        public ActionResult xemGioHang()
        {
            List<Item> ds = null;
            GioHang gio = layGioHang();
            if (gio != null)
            {
                ds = gio.lstSP;
            }
            return View(ds);
        }
        [HttpPost]
        public ActionResult themNhieuSP(FormCollection fc)
        {
            int soluong = 1;
            if (fc["txtSoluong"] != "")
            {
                soluong = Convert.ToInt32(fc["txtSoluong"].ToString());
            }
            int maSP=Convert.ToInt32(Session["maSP"]);
            for (int i = 0; i < soluong; i++)
            {
                ChonMua(maSP);
            }
            return RedirectToAction("XemGioHang");
        }

        public ActionResult truGioHang(int id)
        {
            GioHang g = layGioHang();
            Item a = g.lstSP.FirstOrDefault(x => x.idSP == id);
            if (a.soLuong == 1)
                g.lstSP.Remove(a);
            else
                a.soLuong -= 1;
            return RedirectToAction("xemGioHang");
        }
        public ActionResult congGioHang(int id)
        {
            GioHang g = layGioHang();
            Item a = g.lstSP.FirstOrDefault(x => x.idSP == id);
            a.soLuong += 1;
            return RedirectToAction("xemGioHang");
        }
        public ActionResult xoaGioHang()
        {
            Session["gh"] = null;
            return RedirectToAction("xemGioHang");
        }

        public ActionResult suaSP_GioHang(int id)
        {
            GioHang g = layGioHang();
            Item a = g.lstSP.FirstOrDefault(x => x.idSP == id);
            return View(a);
        }
        [HttpPost]
        public ActionResult XLsuaSP_GioHang(FormCollection fc)
        {
            GioHang g = layGioHang();
            Item a = g.lstSP.FirstOrDefault(x => x.idSP == Convert.ToInt32(fc["txtIDSP"]));
            a.soLuong = Convert.ToInt32(fc["txtSoluong"]);
            return RedirectToAction("xemGioHang");
        }

        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult XLDangKy(FormCollection fc)
        {            
            TAIKHOAN tk = new TAIKHOAN();
            tk.TENDANGNHAP = fc["txtDT"];
            tk.PASS = fc["txtPass"];
            tk.MALOAITK = 2;

            db.TAIKHOANs.InsertOnSubmit(tk);
            db.SubmitChanges();

            KHACHHANG kh = new KHACHHANG();
            kh.MAKH = db.KHACHHANGs.ToList().Count + 1;
            kh.TENKH = fc["txtTen"];
            if(Convert.ToInt32(fc["gioitinh"])==1)
            {
                kh.GENDER = "Nam";
            }
            else
            {
                kh.GENDER = "Nữ";
            }
            kh.EMAIL = fc["txtEmail"];
            kh.DIACHI = fc["txtDiaChi"];
            kh.DIENTHOAI = fc["txtDT"];

            db.KHACHHANGs.InsertOnSubmit(kh);
            db.SubmitChanges();



            return RedirectToAction("Index_KH");
        }

        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult XLDangNhap(FormCollection col)
        {
            TAIKHOAN kh = db.TAIKHOANs.FirstOrDefault(k => k.TENDANGNHAP == col["txtName"] && k.PASS == col["txtPass"]);
            if (kh != null)
            {
               if(kh.TENDANGNHAP != "admin")
               {
                   Session["KH"] = kh.TENDANGNHAP;
                   Session["DangNhapLoi"] = "";
                   return RedirectToAction("Index_KH", "KhachHang");
               }
               else
               {
                   return RedirectToAction("Index_QL", "QuanLy");
               }
            }
            Session["DangNhapLoi"] = "Sai thông tin đăng nhập";

            return View("DangNhap");
        }

        public ActionResult DangXuat()
        {
            Session["KH"] = null;
            return RedirectToAction("Index_KH");
        }

        public ActionResult ThanhToan()
        {
            // Kiểm tra nếu Session["KH"] không tồn tại hoặc không thể chuyển đổi thành kiểu INT
            if (Session["KH"] == null || !int.TryParse(Session["KH"].ToString(), out int maKhachHang))
            {
                // Xử lý khi Session["KH"] không có giá trị hợp lệ
                // Ví dụ: bạn có thể chuyển hướng hoặc thông báo lỗi tùy ý
                return RedirectToAction("Loi");
            }

            // Lấy danh sách chi tiết đơn hàng của khách hàng cụ thể
            var donHangCuaKhachHang = from donHang in db.DONHANGs
                                      join chiTiet in db.CHITIETDONHANGs
                                      on donHang.MADH equals chiTiet.MADH
                                      join sanPham in db.SANPHAMs
                                      on chiTiet.MASP equals sanPham.MASP
                                      where donHang.MAKH == maKhachHang
                                      select new
                                      {
                                          DonHang = donHang,
                                          ChiTietDonHang = chiTiet,
                                          SanPham = sanPham
                                      };


            List<CHITIETDONHANG> ctdh1 = donHangCuaKhachHang.Select(x => x.ChiTietDonHang).ToList();

            return View(ctdh1);
        }

        public ActionResult XuLyThanhToan()
        {
            GioHang gio = layGioHang();
            if (gio == null || gio.lstSP.Count == 0)
            {
                Session["loiGH"] = "Không thể thanh toán khi giỏ hàng rỗng";
                return RedirectToAction("xemGioHang");
            }

            // Kiểm tra xem có Session["KH"] tồn tại không
            if (Session["KH"] == null || !int.TryParse(Session["KH"].ToString(), out int maKhachHang))
            {
                Session["DangNhapLoi"] = "Vui lòng đăng nhập để thanh toán";
                return RedirectToAction("DangNhap");
            }

            int sodonhang = db.DONHANGs.ToList().Count + 1;
            List<Item> a = gio.lstSP;

            DONHANG dh = new DONHANG();
            DateTime time = DateTime.Today;
            dh.MADH = sodonhang;
            dh.NGAYDAT = time;
            dh.NGAYGIAO = null;
            dh.DATHANHTOAN = "Chưa thanh toán";
            dh.TINHTRANGGIAOHANG = "Đang giao hàng";

            // Lấy thông tin khách hàng từ mã khách hàng
            KHACHHANG kh = db.KHACHHANGs.FirstOrDefault(t => t.MAKH == maKhachHang);
            if (kh != null)
            {
                dh.MAKH = kh.MAKH;

                db.DONHANGs.InsertOnSubmit(dh);
                db.SubmitChanges();

                foreach (var item in a)
                {
                    CHITIETDONHANG ctdh = new CHITIETDONHANG();
                    ctdh.MADH = sodonhang;
                    ctdh.MASP = item.idSP;
                    ctdh.SOLUONG = item.soLuong;
                    ctdh.DONGIA = Convert.ToDecimal(item.donGia) * ctdh.SOLUONG;

                    db.CHITIETDONHANGs.InsertOnSubmit(ctdh);
                    db.SubmitChanges();
                }

                return RedirectToAction("ThanhToan");
            }
            else
            {
                // Xử lý khi không tìm thấy thông tin khách hàng
                // Ví dụ: bạn có thể chuyển hướng hoặc thông báo lỗi tùy ý
                return RedirectToAction("Loi");
            }
        }

    }
}
