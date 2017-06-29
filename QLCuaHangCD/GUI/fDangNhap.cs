using System;
using System.Windows.Forms;

using BUS;
using DTO;

namespace GUI
{
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "")
            {
                MessageBox.Show("Tên đăng nhập không hợp lệ", "Lỗi");
                txtTenDangNhap.Focus();
                return;
            }

            if (txtMatKhau.Text == "")
            {
                MessageBox.Show("Mật khẩu không hợp lệ", "Lỗi");
                txtMatKhau.Focus();
                return;
            }

            if (TaiKhoanBUS.Instance.KiemTraDangNhap(txtTenDangNhap.Text, txtMatKhau.Text))
            {
                TaiKhoan tk = new TaiKhoan();
                try
                {
                    tk = TaiKhoanBUS.Instance.LayTaiKhoanTheoTenDangNhap(txtTenDangNhap.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }

                fManHinhChinh f = new fManHinhChinh();
                f.TaiKhoan = tk;
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Lỗi");
                return;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
                e.Cancel = true;
        }
    }
}