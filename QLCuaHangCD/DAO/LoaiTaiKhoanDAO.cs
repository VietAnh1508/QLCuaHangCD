using System;
using System.Data;

namespace DAO
{
    public class LoaiTaiKhoanDAO
    {
        private static LoaiTaiKhoanDAO instance;
        public static LoaiTaiKhoanDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoaiTaiKhoanDAO();
                return instance;
            }
        }
        private LoaiTaiKhoanDAO() { }

        public DataTable LoadLoaiTaiKhoan()
        {
            try
            {
                string query = "SELECT * FROM dbo.LoaiTaiKhoan";
                return DataProvider.Instance.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}