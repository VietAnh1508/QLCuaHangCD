using System;

namespace DTO
{
    public class HoaDon
    {
        public int MaHoaDon { get; set; }
        public DateTime NgayLap { get; set; }
        public int GiamGia { get; set; }
        public int GiaTri { get; set; }
        public bool TrangThai { get; set; }

        public HoaDon() { }

        public HoaDon(bool trangThai)
        {
            this.TrangThai = trangThai;
        }

        public HoaDon(int maHoaDon, DateTime ngayLap, int giamGia, int giaTri, bool trangThai)
        {
            this.MaHoaDon = maHoaDon;
            this.NgayLap = ngayLap;
            this.GiamGia = giamGia;
            this.GiaTri = giaTri;
            this.TrangThai = trangThai;
        }
    }
}