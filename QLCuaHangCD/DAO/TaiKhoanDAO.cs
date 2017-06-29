using System;
using System.Data;

using DTO;

namespace DAO
{
    public class TaiKhoanDAO
    {
        private static TaiKhoanDAO instance;
        public static TaiKhoanDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new TaiKhoanDAO();
                return instance;
            }
        }
        private TaiKhoanDAO() { }

        public bool KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            string query = "USP_DangNhap @TenDangNhap , @MatKhau";
            DataTable result;
            try
            {
                result = DataProvider.Instance.ExecuteQuery(query, new object[] { tenDangNhap, matKhau });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result.Rows.Count > 0;
        }

        public DataTable LayTaiKhoanTheoTenDangNhap(string tenDangNhap)
        {
            try
            {
                string query = "SELECT * FROM dbo.TaiKhoan WHERE TenDangNhap = '" + tenDangNhap + "'";
                return DataProvider.Instance.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DoiMatKhau(string tenDangNhap, string matKhauMoi)
        {
            string query = "USP_DoiMatKhau @MatKhauMoi , @TenDangNhap";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { matKhauMoi, tenDangNhap });
            return result > 0;
        }

        public DataTable LoadTaiKhoan()
        {
            string query = string.Format("SELECT tk.TenDangNhap, tk.TenHienThi, l.TenLoai "
                + "FROM dbo.TaiKhoan AS tk, dbo.LoaiTaiKhoan AS l "
                + "WHERE tk.MaLoaiTaiKhoan = l.MaLoai");
            try
            {
                return DataProvider.Instance.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ThemTaiKhoan(string tenDangNhap, string tenHienThi, string maLoai)
        {
            string query = string.Format("INSERT TaiKhoan (TenDangNhap, TenHienThi, MatKhau, MaLoaiTaiKhoan)"
                + "VALUES('{0}', N'{1}', N'password', '{2}')", tenDangNhap, tenHienThi, maLoai);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool SuaTaiKhoan(string tenDangNhapCu, string tenDangNhapMoi, string tenHienThi, string maLoai)
        {
            string query = string.Format("UPDATE TaiKhoan SET TenDangNhap = '{0}', TenHienThi = N'{1}', MaLoaiTaiKhoan = '{2}'"
                + "WHERE TenDangNhap = '{3}'", tenDangNhapMoi, tenHienThi, maLoai, tenDangNhapCu);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool XoaTaiKhoan(string tenDangNhap)
        {
            string query = "DELETE dbo.TaiKhoan WHERE TenDangNhap = '"+ tenDangNhap + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}