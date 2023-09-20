using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using QuanLyThietBi.Models;

namespace QuanLyThietBi.Models
{
    public class Item
    {
        ThietBiDataContext db = new ThietBiDataContext();
        public int idSP { set; get; }
        public int id_LSP { set; get; }
        public string tenSP { set; get; }
        public string anhBia { set; get; }
        public double donGia { set; get; }
        public int soLuong { set; get; }

        public double thanhTien
        {
            get
            {
                return soLuong * donGia;
            }
        }

        public Item(int iIDSP, int soluong)
        {
            idSP = iIDSP;
            SANPHAM ns = db.SANPHAMs.Single(s => s.MASP == idSP);
            id_LSP = Convert.ToInt32(ns.MALSP);
            tenSP = ns.TENSP;
            anhBia = ns.HINHSANPHAM;
            donGia = Convert.ToDouble(ns.GIABAN.ToString());
            soLuong = soluong;
        }

       
    }

    public class GioHang
    {
        public List<Item> lstSP;
        public GioHang()
        {
            lstSP = new List<Item>();
        }

        public void Them(int id, int sl)
        {
            Item x = new Item(id, sl);
            lstSP.Add(x);
        }

        public int demSLMatHang()
        {
            return lstSP.Count;
        }

        public int tongSLSP()
        {
            int tong = lstSP.Sum(t => t.soLuong);
            return tong;
        }

        public double tongTien()
        {
            double tongtien = lstSP.Sum(t => t.thanhTien);
            return tongtien;
        }


    }
}