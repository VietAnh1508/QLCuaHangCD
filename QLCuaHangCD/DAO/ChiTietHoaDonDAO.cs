using DTO;

namespace DAO
{
    public class ChiTietHoaDonDAO
    {
        private static ChiTietHoaDonDAO instance;
        public static ChiTietHoaDonDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChiTietHoaDonDAO();
                return instance;
            }
        }
        private ChiTietHoaDonDAO() { }

        public bool ThemChiTietHoaDon(ChiTietHoaDon chiTiet)
        {
            string query = "USP_ThemChiTietHoaDon @MaDia , @MaHoaDon , @SoLuong";
            int result = DataProvider.Instance.ExecuteNonQuery(query,
                new object[] { chiTiet.MaDia, chiTiet.MaHoaDon, chiTiet.SoLuong });
            return result > 0;
        }

        public bool XoaChiaTietHoaDonTheoMaHoaDon(int maHoaDon)
        {
            string query = "DELETE dbo.ChiTietHoaDon WHERE MaHD = " + maHoaDon;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}