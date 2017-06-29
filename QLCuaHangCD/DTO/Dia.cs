namespace DTO
{
    public class Dia
    {
        public int MaSo { get; set; }
        public string TenDia { get; set; }
        public int SoLuong { get; set; }
        public int GiaBan { get; set; }
        public int GiaThue { get; set; }
        public int MaLoai { get; set; }

        public Dia() { }

        public Dia(int maSo, string tenDia, int soLuong, int giaBan, int giaThue, int maLoai)
        {
            this.MaSo = maSo;
            this.TenDia = tenDia;
            this.SoLuong = soLuong;
            this.GiaBan = giaBan;
            this.GiaThue = giaThue;
            this.MaLoai = maLoai;
        }
    }
}