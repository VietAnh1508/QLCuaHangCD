using System;
using System.Data;

using DTO;

namespace DAO
{
    public class LoaiDiaDAO
    {
        private static LoaiDiaDAO instance;
        public static LoaiDiaDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoaiDiaDAO();
                return instance;
            }
        }
        private LoaiDiaDAO() { }

        public DataTable LayLoaiDia()
        {
            string query = "select * from LoaiDia";
            try
            {
                return DataProvider.Instance.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ThemLoaiDia(string tenLoaiDia)
        {
            string query = "INSERT dbo.LoaiDia ( TenLoai ) VALUES  ( N'" + tenLoaiDia +"' )";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool SuaLoaiDia(LoaiDia loaiDia)
        {
            string query = "UPDATE dbo.LoaiDia SET TenLoai = N'"+ loaiDia.TenLoai +"' WHERE MaSo = " + loaiDia.MaSo;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool XoaLoaiDia(int maSo)
        {
            string query = "USP_XoaLoaiDia @MaLoai";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maSo });
            return result > 0;
        }
    }
}