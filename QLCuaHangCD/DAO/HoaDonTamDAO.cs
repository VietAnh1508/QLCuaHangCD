using System;
using System.Data;

namespace DAO
{
    public class HoaDonTamDAO
    {
        private static HoaDonTamDAO instance;
        public static HoaDonTamDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new HoaDonTamDAO();
                return instance;
            }
        }
        private HoaDonTamDAO() { }

        public DataTable LayHoaDonTam()
        {
            string query = "SELECT d.MaSo, d.TenDia, c.SoLuong, d.GiaBan, d.GiaBan * c.SoLuong AS ThanhTien "
                + "FROM dbo.Dia AS d, dbo.ChiTietHoaDon AS c, dbo.HoaDon AS hd "
                + "WHERE d.MaSo = c.MaDia AND c.MaHD = hd.MaHD AND hd.TrangThai = 0";
            try
            {
                return DataProvider.Instance.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}