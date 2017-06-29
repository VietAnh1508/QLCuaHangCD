using System.Data;

namespace DTO
{
    public class TaiKhoan
    {
        public string TenDangNhap { get; set; }
        public string TenHienThi { get; set; }
        public string MatKhau { get; set; }
        public string LoaiTaiKhoan { get; set; }

        public TaiKhoan() { }

        public TaiKhoan(string tenDangNhap, string matKhau, string loaiTaiKhoan)
        {
            this.TenDangNhap = tenDangNhap;
            this.MatKhau = matKhau;
            this.LoaiTaiKhoan = loaiTaiKhoan;
        }

        public TaiKhoan(string tenDangNhap, string tenHienThi, string matKhau, string loaiTaiKhoan)
        {
            this.TenDangNhap = tenDangNhap;
            this.TenHienThi = tenHienThi;
            this.MatKhau = matKhau;
            this.LoaiTaiKhoan = loaiTaiKhoan;
        }

        public TaiKhoan(DataRow row)
        {
            this.TenDangNhap = row["tenDangNhap"].ToString();
            this.TenHienThi = row["tenHienThi"].ToString();
            this.MatKhau = row["matKhau"].ToString();
            this.LoaiTaiKhoan = row["maLoaiTaiKhoan"].ToString();
        }
    }
}