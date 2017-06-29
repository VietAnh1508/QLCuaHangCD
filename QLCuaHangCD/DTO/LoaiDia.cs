namespace DTO
{
    public class LoaiDia
    {
        public int MaSo { get; set; }
        public string TenLoai { get; set; }

        public LoaiDia() { }

        public LoaiDia(int maSo, string tenLoai)
        {
            this.MaSo = maSo;
            this.TenLoai = tenLoai;
        }
    }
}