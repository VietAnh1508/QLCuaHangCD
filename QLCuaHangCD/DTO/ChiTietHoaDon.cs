namespace DTO
{
    public class ChiTietHoaDon
    {
        public int MaDia { get; set; }
        public int MaHoaDon { get; set; }
        public int SoLuong { get; set; }

        public ChiTietHoaDon() { }

        public ChiTietHoaDon(int maDia, int maHoaDon, int soLuong)
        {
            this.MaDia = maDia;
            this.MaHoaDon = maHoaDon;
            this.SoLuong = soLuong;
        }
    }
}