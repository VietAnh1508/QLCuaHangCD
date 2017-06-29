using System.Windows.Forms;

using BUS;
using DTO;

namespace GUI
{
    public partial class fDoiMatKhau : Form
    {
        private TaiKhoan taiKhoan;
        public TaiKhoan TaiKhoan
        {
            get { return taiKhoan; }
            set { taiKhoan = value; }
        }

        public fDoiMatKhau()
        {
            InitializeComponent();
        }

        private void fDoiMatKhau_Load(object sender, System.EventArgs e)
        {
            txtTaiKhoan.Text = taiKhoan.TenDangNhap;
        }

        private void btnXacNhan_Click(object sender, System.EventArgs e)
        {
            if (txtMatKhauCu.Text == "" || txtMatKhauMoi.Text == "" || txtNhapLaiMatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            if (txtMatKhauCu.Text != taiKhoan.MatKhau)
            {
                MessageBox.Show("Mật khẩu cũ không đúng");
                txtMatKhauCu.Focus();
                return;
            }

            if (txtMatKhauMoi.Text != txtNhapLaiMatKhau.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không đúng", "Lỗi");
                txtNhapLaiMatKhau.Focus();
                return;
            }

            if (TaiKhoanBUS.Instance.DoiMatKhau(txtTaiKhoan.Text, txtMatKhauMoi.Text))
            {
                MessageBox.Show("Đổi mật khẩu thành công", "Thông báo");
                txtMatKhauCu.Clear();
                txtMatKhauMoi.Clear();
                txtNhapLaiMatKhau.Clear();
            }
            else
                MessageBox.Show("Đổi mật khẩu thất bại!", "Lỗi");
        }

        private void btnHuy_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void fDoiMatKhau_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtMatKhauCu.Text != "" || txtMatKhauMoi.Text != "" || txtNhapLaiMatKhau.Text != "")
            {
                if (MessageBox.Show("Các thay đổi có thể chưa được lưu\n Bạn có chắc chắn muốn thoát?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    e.Cancel = true;
            }
        }
    }
}