using System.Windows.Forms;
using System;

using BUS;
using DTO;
using System.Data;

namespace GUI
{
    public partial class fQuanLy : Form
    {
        BindingSource lstLoaiDia = new BindingSource();
        BindingSource lstDia = new BindingSource();
        BindingSource lstKhachHang = new BindingSource();
        BindingSource lstTaiKhoan = new BindingSource();
        string tenDangNhapDangChon = "";

        private string tenDangNhapHienTai;
        public string TenDangNhapHienTai
        {
            get { return tenDangNhapHienTai; }
            set { tenDangNhapHienTai = value; }
        }

        public fQuanLy()
        {
            InitializeComponent();
            dgvLoaiDia.DataSource = lstLoaiDia;
            dgvDia.DataSource = lstDia;
            dgvKhachHang.DataSource = lstKhachHang;
            dgvTaiKhoan.DataSource = lstTaiKhoan;
        }

        private void fQuanLy_Load(object sender, EventArgs e)
        {
            LoadLoaiDia();
            BindingLoaiDia();

            LoadDia();
            LoadComboBoxLoaiDia();
            BindingDia();

            LoadKhachHang();
            BindingKhachHang();

            LoadDanhSachHoaDon();
            btnXoaHoaDon.Enabled = false;

            LoadTaiKhoan();
            LoadComboBoxLoaiTaiKhoan();
            BindingTaiKhoan();
        }

        #region LoaiDia
        private void LoadLoaiDia()
        {
            try
            {
                lstLoaiDia.DataSource = LoaiDiaBUS.Instance.LayLoaiDia();
                dgvLoaiDia.Columns[0].HeaderText = "Mã danh mục";
                dgvLoaiDia.Columns[1].HeaderText = "Tên danh mục";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex);
            }
        }

        private void BindingLoaiDia()
        {
            txtMaLoai.DataBindings.Add("Text", dgvLoaiDia.DataSource, "MaSo", true, DataSourceUpdateMode.Never);
            txtTenLoai.DataBindings.Add("Text", dgvLoaiDia.DataSource, "TenLoai", true, DataSourceUpdateMode.Never);
        }

        private void btnThemLoaiDia_Click(object sender, EventArgs e)
        {
            if (txtTenLoai.Text == "")
            {
                MessageBox.Show("Tên loại đĩa không hợp lệ", "Lỗi");
                txtTenLoai.Focus();
                return;
            }

            if (LoaiDiaBUS.Instance.ThemLoaiDia(txtTenLoai.Text) == true)
            {
                MessageBox.Show("Thêm thành công", "Thông báo");
                LoadLoaiDia();
            }
            else
                MessageBox.Show("Thêm thất bại", "Lỗi");
        }

        private void btnSuaLoaiDia_Click(object sender, EventArgs e)
        {
            if (txtMaLoai.Text == "")
            {
                MessageBox.Show("Hãy chọn loại đĩa!");
                return;
            }

            if (txtTenLoai.Text == "")
            {
                MessageBox.Show("Tên loại đĩa không hợp lệ", "Lỗi");
                txtTenLoai.Focus();
                return;
            }

            if (LoaiDiaBUS.Instance.SuaLoaiDia(new LoaiDia(int.Parse(txtMaLoai.Text), txtTenLoai.Text)))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
                LoadLoaiDia();
            }
            else
                MessageBox.Show("Cập nhật thất bại", "Lỗi");
        }

        private void btnXoaLoaiDia_Click(object sender, EventArgs e)
        {
            if (txtMaLoai.Text == null)
            {
                MessageBox.Show("Hãy chọn loại đĩa!");
                return;
            }

            if (LoaiDiaBUS.Instance.XoaLoaiDia(int.Parse(txtMaLoai.Text)))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo");
                LoadLoaiDia();
            }
            else
                MessageBox.Show("Xóa thất bại", "Lỗi");
        }

        private void btnHuyLoaiDia_Click(object sender, EventArgs e)
        {
            txtMaLoai.Clear();
            txtTenLoai.Clear();
        }

        private void btnTaiLaiLoaiDia_Click(object sender, EventArgs e)
        {
            LoadLoaiDia();
            btnHuyLoaiDia_Click(sender, e);
        }
        #endregion

        #region Dia
        private void LoadDia()
        {
            try
            {
                lstDia.DataSource = DiaBUS.Instance.LoadDia();
                dgvDia.Columns[0].HeaderText = "Mã số";
                dgvDia.Columns[1].HeaderText = "Tên đĩa";
                dgvDia.Columns[2].HeaderText = "Số lượng";
                dgvDia.Columns[3].HeaderText = "Giá bán";
                dgvDia.Columns[4].HeaderText = "Giá thuê";
                dgvDia.Columns[5].HeaderText = "Loại";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex);
            }
        }

        private void BindingDia()
        {
            txtMaDia.DataBindings.Add("Text", dgvDia.DataSource, "MaSo", true, DataSourceUpdateMode.Never);
            txtTenDia.DataBindings.Add("Text", dgvDia.DataSource, "TenDia", true, DataSourceUpdateMode.Never);
            nmSoLuongDia.DataBindings.Add("Value", dgvDia.DataSource, "SoLuong", true, DataSourceUpdateMode.Never);
            txtGiaBan.DataBindings.Add("Text", dgvDia.DataSource, "GiaBan", true, DataSourceUpdateMode.Never);
            txtGiaThue.DataBindings.Add("Text", dgvDia.DataSource, "GiaThue", true, DataSourceUpdateMode.Never);
            cmbLoaiDia.DataBindings.Add("Text", dgvDia.DataSource, "TenLoai", true, DataSourceUpdateMode.Never);
        }

        private void LoadComboBoxLoaiDia()
        {
            try
            {
                cmbLoaiDia.DataSource = LoaiDiaBUS.Instance.LayLoaiDia();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex);
            }
            cmbLoaiDia.DisplayMember = "TenLoai";
            cmbLoaiDia.ValueMember = "MaSo";
        }

        private void btnThemDia_Click(object sender, EventArgs e)
        {
            if (txtTenDia.Text == "" || txtGiaBan.Text == "" || txtGiaThue.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi");
                return;
            }

            Dia diaMoi = new Dia();
            diaMoi.TenDia = txtTenDia.Text;
            diaMoi.SoLuong = Convert.ToInt32(nmSoLuongDia.Value);
            diaMoi.GiaBan = int.Parse(txtGiaBan.Text);
            diaMoi.GiaThue = int.Parse(txtGiaThue.Text);
            diaMoi.MaLoai = (int)cmbLoaiDia.SelectedValue;

            if (DiaBUS.Instance.ThemDia(diaMoi))
            {
                MessageBox.Show("Thêm đĩa mới thành công", "Thông báo");
                LoadDia();
            }
            else
                MessageBox.Show("Thêm đĩa thất bại", "Lỗi");
        }

        private void btnSuaDia_Click(object sender, EventArgs e)
        {
            if (txtTenDia.Text == "" || txtGiaBan.Text == "" || txtGiaThue.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi");
                return;
            }

            Dia dia = new Dia();
            dia.MaSo = int.Parse(txtMaDia.Text);
            dia.TenDia = txtTenDia.Text;
            dia.SoLuong = Convert.ToInt32(nmSoLuongDia.Value);
            dia.GiaBan = int.Parse(txtGiaBan.Text);
            dia.GiaThue = int.Parse(txtGiaThue.Text);
            dia.MaLoai = (int)cmbLoaiDia.SelectedValue;

            if (DiaBUS.Instance.CapNhatDia(dia))
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo");
                LoadDia();
            }
            else
                MessageBox.Show("Cập nhật thất bại\n Không thể chỉnh sửa đĩa hiện hành", "Lỗi");
        }

        private void btnXoaDia_Click(object sender, EventArgs e)
        {
            if (txtMaDia.Text == "")
            {
                MessageBox.Show("Hãy chọn đĩa cần xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có thật sự muốn xóa đĩa có mã số " + txtMaDia.Text, "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DiaBUS.Instance.XoaDia(int.Parse(txtMaDia.Text)))
                {
                    MessageBox.Show("Xóa đĩa thành công", "Thông báo");
                    LoadDia();
                }
                else
                {
                    MessageBox.Show("Xóa đĩa thất bại\n Không thể xóa đĩa hiện hành", "Lỗi");
                }
            }
        }

        private void btnHuyDia_Click(object sender, EventArgs e)
        {
            txtMaDia.Clear();
            txtTenDia.Clear();
            nmSoLuongDia.Value = 1;
            txtGiaBan.Clear();
            txtGiaThue.Clear();
        }
        #endregion

        #region KhachHang
        private void LoadKhachHang()
        {
            try
            {
                dgvKhachHang.DataSource = KhachHangBUS.Instance.LoadKhachHang();
                dgvKhachHang.Columns[1].HeaderText = "Họ tên";
                dgvKhachHang.Columns[2].HeaderText = "Số điện thoại";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex);
            }
        }

        private void BindingKhachHang()
        {
            txtCMND.DataBindings.Clear();
            txtCMND.DataBindings.Add("Text", dgvKhachHang.DataSource, "CMND", true, DataSourceUpdateMode.Never);
            txtHoTen.DataBindings.Clear();
            txtHoTen.DataBindings.Add("Text", dgvKhachHang.DataSource, "HoTen", true, DataSourceUpdateMode.Never);
            txtSoDienThoai.DataBindings.Clear();
            txtSoDienThoai.DataBindings.Add("Text", dgvKhachHang.DataSource, "SoDienThoai", true, DataSourceUpdateMode.Never);
        }
        #endregion

        #region HoaDon
        int maHoaDonHienTai = -1;

        private void dgvHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            maHoaDonHienTai = (int)dgvHoaDon.Rows[e.RowIndex].Cells[0].Value;
            btnXoaHoaDon.Enabled = true;
        }

        private void LoadDanhSachHoaDon()
        {
            try
            {
                dgvHoaDon.DataSource = HoaDonBUS.Instance.LoadDanhSachHoaDon();
                dgvHoaDon.Columns[0].HeaderText = "Mã hóa đơn";
                dgvHoaDon.Columns[1].HeaderText = "Ngày lập";
                dgvHoaDon.Columns[2].HeaderText = "Giảm giá (%)";
                dgvHoaDon.Columns[3].HeaderText = "Giá trị";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void btnXoaHoaDon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn xóa hóa đơn có mã số " + maHoaDonHienTai + "?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool xoaChiTietThanhCong = ChiTietHoaDonBUS.Instance.XoaChiTietHoaDonTheoMaHoaDon(maHoaDonHienTai);
                bool xoaHoaDonThanhCong = HoaDonBUS.Instance.XoaHoaDon(maHoaDonHienTai);
                if (xoaChiTietThanhCong && xoaHoaDonThanhCong)
                {
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    btnXoaHoaDon.Enabled = false;
                    LoadDanhSachHoaDon();
                }
                else
                    MessageBox.Show("Xóa hóa đơn thất bại", "Lỗi");
            }
        }

        private void btnReLoadBill_Click(object sender, EventArgs e)
        {
            LoadDanhSachHoaDon();
        }
        #endregion

        #region TaiKhoan
        private void LoadTaiKhoan()
        {
            try
            {
                lstTaiKhoan.DataSource = TaiKhoanBUS.Instance.LoadTaiKhoan();
                dgvTaiKhoan.Columns[0].HeaderText = "Tên đăng nhập";
                dgvTaiKhoan.Columns[1].HeaderText = "Tên hiển thị";
                dgvTaiKhoan.Columns[2].HeaderText = "Loại tài khoản";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex);
            }
        }

        private void BindingTaiKhoan()
        {
            txtTenDangNhap.DataBindings.Add("Text", dgvTaiKhoan.DataSource, "TenDangNhap", true, DataSourceUpdateMode.Never);
            txtTenHienThi.DataBindings.Add("Text", dgvTaiKhoan.DataSource, "TenHienThi", true, DataSourceUpdateMode.Never);
            cmbLoaiTaiKhoan.DataBindings.Add("Text", dgvTaiKhoan.DataSource, "TenLoai", true, DataSourceUpdateMode.Never);
        }

        private void LoadComboBoxLoaiTaiKhoan()
        {
            try
            {
                cmbLoaiTaiKhoan.DataSource = LoaiTaiKhoanBUS.Instance.LoadLoaiTaiKhoan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex);
            }
            cmbLoaiTaiKhoan.DisplayMember = "TenLoai";
            cmbLoaiTaiKhoan.ValueMember = "MaLoai";
        }

        private void btnThemTaiKhoan_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "" || txtTenHienThi.Text == "")
            {
                MessageBox.Show("Vui lòng điền đủ thông tin", "Lỗi");
                return;
            }
            if (TaiKhoanBUS.Instance.ThemTaiKhoan(txtTenDangNhap.Text, txtTenHienThi.Text, cmbLoaiTaiKhoan.SelectedValue.ToString()))
            {
                MessageBox.Show("Thêm tài khoản mới thành công!\n Mật khẩu là 'password', hãy đổi mật khẩu để bảo vệ tài khoản", "Thông báo");
                LoadTaiKhoan();
            }
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tenDangNhapDangChon = dgvTaiKhoan.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btnSuaTaiKhoan_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "")
            {
                MessageBox.Show("Hãy chọn tài khoản cần cập nhật", "Lỗi");
                return;
            }

            if (txtTenDangNhap.Text == tenDangNhapHienTai)
            {
                MessageBox.Show("Không thể sửa thông tin tài khoản hiện hành", "Lỗi");
                return;
            }

            if (TaiKhoanBUS.Instance.SuaTaiKhoan(tenDangNhapDangChon, txtTenDangNhap.Text,
                txtTenHienThi.Text, cmbLoaiTaiKhoan.SelectedValue.ToString()))
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo");
                LoadTaiKhoan();
            }
            else
                MessageBox.Show("Cập nhật thất bại", "Lỗi");
        }

        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "")
            {
                MessageBox.Show("Hãy chọn tài khoản cần xóa", "Lỗi");
                return;
            }

            if (txtTenDangNhap.Text == tenDangNhapHienTai)
            {
                MessageBox.Show("Không thể xóa tài khoản hiện hành", "Lỗi");
                return;
            }

            if (MessageBox.Show("Bạn có thật sự muốn xóa tài khoản " + txtTenDangNhap.Text, "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (TaiKhoanBUS.Instance.XoaTaiKhoan(txtTenDangNhap.Text))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    LoadTaiKhoan();
                }
                else
                    MessageBox.Show("Xóa thất bại", "Lỗi");
            }
        }

        private void btnHuyTaiKhoan_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.Clear();
            txtTenHienThi.Clear();
            cmbLoaiTaiKhoan.SelectedIndex = 0;
        }
        #endregion
    }
}