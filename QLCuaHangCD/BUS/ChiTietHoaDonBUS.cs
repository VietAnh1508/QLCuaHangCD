using DAO;
using DTO;

namespace BUS
{
    public class ChiTietHoaDonBUS
    {
        private static ChiTietHoaDonBUS instance;
        public static ChiTietHoaDonBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChiTietHoaDonBUS();
                return instance;
            }
        }
        private ChiTietHoaDonBUS() { }

        public bool ThemChiTietHoaDon(ChiTietHoaDon chiTiet)
        {
            return ChiTietHoaDonDAO.Instance.ThemChiTietHoaDon(chiTiet);
        }

        public bool XoaChiTietHoaDonTheoMaHoaDon(int maHoaDon)
        {
            return ChiTietHoaDonDAO.Instance.XoaChiaTietHoaDonTheoMaHoaDon(maHoaDon);
        }
    }
}