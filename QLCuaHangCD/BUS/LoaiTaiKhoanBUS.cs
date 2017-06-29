using System.Data;

using DAO;
using System;

namespace BUS
{
    public class LoaiTaiKhoanBUS
    {
        private static LoaiTaiKhoanBUS instance;
        public static LoaiTaiKhoanBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoaiTaiKhoanBUS();
                return instance;
            }
        }
        private LoaiTaiKhoanBUS() { }

        public DataTable LoadLoaiTaiKhoan()
        {
            try
            {
                return LoaiTaiKhoanDAO.Instance.LoadLoaiTaiKhoan();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}