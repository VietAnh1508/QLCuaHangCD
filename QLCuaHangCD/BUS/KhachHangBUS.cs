using System.Data;
using System;

using DAO;

namespace BUS
{
    public class KhachHangBUS
    {
        private static KhachHangBUS instance;
        public static KhachHangBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhachHangBUS();
                return instance;
            }
        }
        private KhachHangBUS() { }

        public DataTable LoadKhachHang()
        {
            try
            {
                return KhachHangDAO.Instance.LoadKhachHang();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}