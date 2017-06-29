using System;
using System.Data;

namespace DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;
        public static HoaDonDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new HoaDonDAO();
                return instance;
            }
        }
        private HoaDonDAO() { }

        public DataTable LoadDanhSachHoaDon()
        {
            try
            {
                return DataProvider.Instance.ExecuteQuery("select MaHD, NgayLap, GiamGia, GiaTri from HoaDon where TrangThai = 1");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ThemHoaDon()
        {
            string query = "INSERT dbo.HoaDon ( TrangThai ) VALUES ( 0 )";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool XoaHoaDon(int maHoaDon)
        {
            string query = "DELETE dbo.HoaDon WHERE MaHD = " + maHoaDon;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public int LayMaHoaDonChuaThanhToan()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MaHD FROM dbo.HoaDon WHERE TrangThai = 0");
            }
            catch
            {
                return -1;
            }
        }

        public bool MuaDia(int maHoaDon, int giamGia, int tienThanhToan)
        {
            string query = "USP_MuaDia @MaHoaDon , @GiamGia , @TongTien";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maHoaDon, giamGia, tienThanhToan });
            return result > 0;
        }
    }
}