using System;
using System.Windows.Forms;
using System.Collections.Generic;

using BUS;
using DTO;
using System.Data;

namespace GUI
{
    public partial class fManHinhChinh : Form
    {
        private TaiKhoan taiKhoan;
        public TaiKhoan TaiKhoan
        {
            get { return taiKhoan; }
            set { taiKhoan = value; }
        }

        public fManHinhChinh()
        {
            InitializeComponent();
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            lsbLoaiDiaMua.DataSource = LoadLoaiDia();
            lsbLoaiDiaMua.DisplayMember = "TenLoai";
            lsbLoaiDiaMua.ValueMember = "MaSo";

            lsbLoaiDiaThue.DataSource = LoadLoaiDia();
            lsbLoaiDiaThue.DisplayMember = "TenLoai";
            lsbLoaiDiaThue.ValueMember = "MaSo";

            LoadDanhSachChon();
            lblChao.Text = "Chào " + taiKhoan.TenHienThi;
            if (taiKhoan.LoaiTaiKhoan != "QL")
                quảnLíToolStripMenuItem.Enabled = false;
        }

        #region Chuc Nang
        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDoiMatKhau f = new fDoiMatKhau();
            f.TaiKhoan = taiKhoan;
            f.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void quảnLíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanLy f = new fQuanLy();
            f.TenDangNhapHienTai = taiKhoan.TenDangNhap;
            f.Show();
        }
        #endregion

        #region MuaDia
        private DataTable LoadLoaiDia()
        {
            try
            {
                return LoaiDiaBUS.Instance.LayLoaiDia();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.ToString());
                return null;
            }
        }

        private void lsbLoaiDiaMua_Click(object sender, EventArgs e)
        {
            int maDanhMuc = (int)lsbLoaiDiaMua.SelectedValue;
            try
            {
                lsbDiaMua.DataSource = DiaBUS.Instance.LayDiaTheoMaDanhMuc(maDanhMuc);
                lsbDiaMua.DisplayMember = "TenDia";
                lsbDiaMua.ValueMember = "MaSo";
                BindingDia();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.ToString());
            }
        }

        private void BindingDia()
        {
            txtMaDiaMua.DataBindings.Clear();
            txtMaDiaMua.DataBindings.Add("Text", lsbDiaMua.DataSource, "MaSo", true, DataSourceUpdateMode.Never);
            txtTenDiaMua.DataBindings.Clear();
            txtTenDiaMua.DataBindings.Add("Text", lsbDiaMua.DataSource, "TenDia", true, DataSourceUpdateMode.Never);
            txtSoLuongTon.DataBindings.Clear();
            txtSoLuongTon.DataBindings.Add("Text", lsbDiaMua.DataSource, "SoLuong", true, DataSourceUpdateMode.Never);
            txtGiaBan.DataBindings.Clear();
            txtGiaBan.DataBindings.Add("Text", lsbDiaMua.DataSource, "GiaBan", true, DataSourceUpdateMode.Never);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaDiaMua.Text == "")
            {
                MessageBox.Show("Hãy chọn đĩa", "Thông báo");
                return;
            }

            int soLuong = (int)nmSoLuong.Value;
            if (soLuong == 0)
            {
                MessageBox.Show("Hãy chọn số lượng", "Thông báo");
                return;
            }

            int maHoaDon = HoaDonBUS.Instance.LayMaHoaDonChuaThanhToan();

            if (maHoaDon == -1)
            {
                HoaDonBUS.Instance.ThemHoaDon();
                ChiTietHoaDon chiTiet = new ChiTietHoaDon();
                chiTiet.MaDia = int.Parse(txtMaDiaMua.Text);
                chiTiet.MaHoaDon = HoaDonBUS.Instance.LayMaHoaDonChuaThanhToan();
                chiTiet.SoLuong = soLuong;
                ChiTietHoaDonBUS.Instance.ThemChiTietHoaDon(chiTiet);
            }
            else
            {
                ChiTietHoaDon chiTiet = new ChiTietHoaDon(int.Parse(txtMaDiaMua.Text), maHoaDon, soLuong);
                ChiTietHoaDonBUS.Instance.ThemChiTietHoaDon(chiTiet);
            }
            LoadDanhSachChon();
        }

        private void LoadDanhSachChon()
        {
            lsvDanhSachDiaChonMua.Items.Clear();
            List<HoaDonTam> list = new List<HoaDonTam>();
            try
            {
                list = HoaDonTamBUS.Instance.LayHoaDonTam();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.ToString());
            }
            int tongTien = 0;
            foreach (HoaDonTam tam in list)
            {
                ListViewItem item = new ListViewItem(tam.MaSo.ToString());
                item.SubItems.Add(tam.TenDia);
                item.SubItems.Add(tam.SoLuong.ToString());
                item.SubItems.Add(tam.GiaBan.ToString());
                item.SubItems.Add(tam.ThanhTien.ToString());

                tongTien += tam.ThanhTien;
                lsvDanhSachDiaChonMua.Items.Add(item);
            }
            txtTongTien.Text = tongTien.ToString();
        }

        private void btnMua_Click(object sender, EventArgs e)
        {
            if (lsvDanhSachDiaChonMua.Items == null)
                return;

            if (XetSoLuongDiaTon() == false)
            {
                MessageBox.Show("Số lượng đĩa còn lại không đủ!", "Lỗi");
                return;
            }

            int giamGia = (int)nmGiamGia.Value;
            int tongTien = int.Parse(txtTongTien.Text);
            int tienThanhToan = tongTien - ((tongTien * giamGia) / 100);
            int maHoaDon = HoaDonBUS.Instance.LayMaHoaDonChuaThanhToan();

            if (maHoaDon != -1)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thanh toán?", "Xác nhận thanh toán", MessageBoxButtons.YesNo)
                    == DialogResult.Yes)
                {
                    if (HoaDonBUS.Instance.MuaDia(maHoaDon, giamGia, tienThanhToan))
                    {
                        MessageBox.Show("Thanh toán thành công", "Thông báo");
                        CapNhatSoLuongDia();
                        lsvDanhSachDiaChonMua.Items.Clear();
                        ResetTextBox();
                    }
                    else
                        MessageBox.Show("Thanh toán thất bại", "Lỗi");
                }
            }
        }

        private bool XetSoLuongDiaTon()
        {
            foreach (ListViewItem item in lsvDanhSachDiaChonMua.Items)
            {
                int maSo = int.Parse(item.Text);
                int soLuong = int.Parse(item.SubItems[2].Text);
                DataTable tableDia = (DataTable)lsbDiaMua.DataSource;
                foreach (DataRow row in tableDia.Rows)
                {
                    if (maSo == (int)row[0] && soLuong > (int)row[2])
                        return false;
                }
            }
            return true;
        }

        private void CapNhatSoLuongDia()
        {
            foreach (ListViewItem item in lsvDanhSachDiaChonMua.Items)
            {
                int maSo = int.Parse(item.Text);
                int soLuongMua = int.Parse(item.SubItems[2].Text);

                DataTable tableDia = (DataTable)lsbDiaMua.DataSource;
                foreach (DataRow row in tableDia.Rows)
                {
                    if (maSo == (int)row[0])
                    {
                        int soLuongTon = (int)row[2];
                        DiaBUS.Instance.CapNhatSoLuongDia(maSo, soLuongTon - soLuongMua);
                        break;
                    }
                }
            }
        }

        private void ResetTextBox()
        {
            txtMaDiaMua.Clear();
            txtTenDiaMua.Clear();
            txtGiaBan.Clear();
            txtSoLuongTon.Clear();
            txtTongTien.Clear();
        }
        #endregion

        #region ThueDia
        #endregion
    }
}