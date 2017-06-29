using DAO;
using DTO;
using System;
using System.Data;

namespace BUS
{
    public class TaiKhoanBUS
    {
        private static TaiKhoanBUS instance;
        public static TaiKhoanBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new TaiKhoanBUS();
                return instance;
            }
        }
        private TaiKhoanBUS() { }

        public bool KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            try
            {
                return TaiKhoanDAO.Instance.KiemTraDangNhap(tenDangNhap, matKhau);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TaiKhoan LayTaiKhoanTheoTenDangNhap(string tenDangNhap)
        {
            DataTable table = new DataTable();
            try
            {
                table = TaiKhoanDAO.Instance.LayTaiKhoanTheoTenDangNhap(tenDangNhap);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new TaiKhoan(table.Rows[0]);
        }

        public bool DoiMatKhau(string tenDangNhap, string matKhauMoi)
        {
            return TaiKhoanDAO.Instance.DoiMatKhau(tenDangNhap, matKhauMoi);
        }

        public DataTable LoadTaiKhoan()
        {
            try
            {
                return TaiKhoanDAO.Instance.LoadTaiKhoan();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ThemTaiKhoan(string tenDangNhap, string tenHienThi, string maLoai)
        {
            return TaiKhoanDAO.Instance.ThemTaiKhoan(tenDangNhap, tenHienThi, maLoai);
        }

        public bool SuaTaiKhoan(string tenDangNhapCu, string tenDangNhapMoi, string tenHienThi, string maLoai)
        {
            return TaiKhoanDAO.Instance.SuaTaiKhoan(tenDangNhapCu, tenDangNhapMoi, tenHienThi, maLoai);
        }

        public bool XoaTaiKhoan(string tenDangNhap)
        {
            return TaiKhoanDAO.Instance.XoaTaiKhoan(tenDangNhap);
        }
    }
}