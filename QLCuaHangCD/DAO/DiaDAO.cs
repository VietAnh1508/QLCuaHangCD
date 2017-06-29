using System;
using System.Data;

using DTO;

namespace DAO
{
    public class DiaDAO
    {
        private static DiaDAO instance;
        public static DiaDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DiaDAO();
                return instance;
            }
        }
        private DiaDAO() { }

        public DataTable LoadDia()
        {
            try
            {
                string query = string.Format("SELECT d.MaSo, d.TenDia, d.SoLuong, d.GiaBan, d.GiaThue, l.TenLoai "
                    + "FROM Dia d, LoaiDia l "
                    + "WHERE d.MaLoai = l.MaSo");
                return DataProvider.Instance.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayDiaTheoMaDanhMuc(int id)
        {
            string query = "USP_LayDiaTheoMaDanhMuc @MaLoai";
            try
            {
                return DataProvider.Instance.ExecuteQuery(query, new object[] { id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ThemDia(Dia dia)
        {
            string query = "USP_ThemDia @TenDia , @SoLuong , @GiaBan , @GiaThue , @MaLoai";
            int result = DataProvider.Instance.ExecuteNonQuery(query,
                new object[] { dia.TenDia, dia.SoLuong, dia.GiaBan, dia.GiaThue, dia.MaLoai });
            return result > 0;
        }

        public bool CapNhatDia(Dia dia)
        {
            string query = "USP_CapNhatDia @TenDia , @SoLuong , @GiaBan , @GiaThue , @MaLoai , @MaSo";
            int result = DataProvider.Instance.ExecuteNonQuery(query,
                new object[] { dia.TenDia, dia.SoLuong, dia.GiaBan, dia.GiaThue, dia.MaLoai, dia.MaSo });
            return result > 0;
        }

        public bool XoaDia(int maSo)
        {
            string query = "USP_XoaDia @MaDia";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maSo });
            return result > 0;
        }

        public bool CapNhatSoLuongDia(int maDia, int soLuong)
        {
            string query = string.Format("UPDATE dbo.Dia SET SoLuong = {0} WHERE MaSo = {1}", soLuong, maDia);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}