using System;
using System.Data;

using DAO;
using DTO;

namespace BUS
{
    public class LoaiDiaBUS
    {
        private static LoaiDiaBUS instance;
        public static LoaiDiaBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoaiDiaBUS();
                return instance;
            }
        }
        private LoaiDiaBUS() { }

        public DataTable LayLoaiDia()
        {
            try
            {
                return LoaiDiaDAO.Instance.LayLoaiDia();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ThemLoaiDia(string tenLoaiDia)
        {
            return LoaiDiaDAO.Instance.ThemLoaiDia(tenLoaiDia);
        }

        public bool SuaLoaiDia(LoaiDia loaiDia)
        {
            return LoaiDiaDAO.Instance.SuaLoaiDia(loaiDia);
        }

        public bool XoaLoaiDia(int maSo)
        {
            return LoaiDiaDAO.Instance.XoaLoaiDia(maSo);
        }
    }
}