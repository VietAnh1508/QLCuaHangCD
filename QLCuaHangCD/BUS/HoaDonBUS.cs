using DAO;
using System;
using System.Data;

namespace BUS
{
    public class HoaDonBUS
    {
        private static HoaDonBUS instance;
        public static HoaDonBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new HoaDonBUS();
                return instance;
            }
        }
        private HoaDonBUS() { }

        public DataTable LoadDanhSachHoaDon()
        {
            try
            {
                return HoaDonDAO.Instance.LoadDanhSachHoaDon();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ThemHoaDon()
        {
            return HoaDonDAO.Instance.ThemHoaDon();
        }

        public bool XoaHoaDon(int maHoaDon)
        {
            return HoaDonDAO.Instance.XoaHoaDon(maHoaDon);
        }

        public int LayMaHoaDonChuaThanhToan()
        {
            return HoaDonDAO.Instance.LayMaHoaDonChuaThanhToan();
        }

        public bool MuaDia(int maHoaDon, int giamGia, int tienThanhToan)
        {
            return HoaDonDAO.Instance.MuaDia(maHoaDon, giamGia, tienThanhToan);
        }
    }
}