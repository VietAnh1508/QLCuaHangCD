using System.Data;

namespace DTO
{
    public class HoaDonTam
    {
        public int MaSo { get; set; }
        public string TenDia { get; set; }
        public int SoLuong { get; set; }
        public int GiaBan { get; set; }
        public int ThanhTien { get; set; }

        public HoaDonTam() { }

        public HoaDonTam(int maSo, string tenDia, int soLuong, int giaBan, int thanhTien)
        {
            this.MaSo = maSo;
            this.TenDia = tenDia;
            this.SoLuong = soLuong;
            this.GiaBan = giaBan;
            this.ThanhTien = thanhTien;
        }

        public HoaDonTam(DataRow row)
        {
            this.MaSo = (int)row["maSo"];
            this.TenDia = row["tenDia"].ToString();
            this.SoLuong = (int)row["soLuong"];
            this.GiaBan = (int)row["giaBan"];
            this.ThanhTien = (int)row["thanhTien"];
        }
    }
}