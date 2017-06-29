namespace DTO
{
    public class KhachHang
    {
        public string CMND { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }

        public KhachHang() { }

        public KhachHang(string CMND, string hoTen, string soDienThoai)
        {
            this.CMND = CMND;
            this.HoTen = hoTen;
            this.SoDienThoai = soDienThoai;
        }
    }
}