using System;
using System.Data;

namespace DAO
{
    public class KhachHangDAO
    {
        private static KhachHangDAO instance;
        public static KhachHangDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhachHangDAO();
                return instance;
            }
        }
        private KhachHangDAO() { }

        public DataTable LoadKhachHang()
        {
            try
            {
                return DataProvider.Instance.ExecuteQuery("select * from KhachHang");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}