using DAO;
using DTO;
using System;
using System.Data;

namespace BUS
{
    public class DiaBUS
    {
        private static DiaBUS instance;
        public static DiaBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new DiaBUS();
                return instance;
            }
        }
        private DiaBUS() { }

        public DataTable LoadDia()
        {
            try
            {
                return DiaDAO.Instance.LoadDia();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LayDiaTheoMaDanhMuc(int id)
        {
            try
            {
                return DiaDAO.Instance.LayDiaTheoMaDanhMuc(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ThemDia(Dia dia)
        {
            return DiaDAO.Instance.ThemDia(dia);
        }

        public bool CapNhatDia(Dia dia)
        {
            return DiaDAO.Instance.CapNhatDia(dia);
        }

        public bool XoaDia(int maSo)
        {
            return DiaDAO.Instance.XoaDia(maSo);
        }

        public bool CapNhatSoLuongDia(int maDia, int soLuong)
        {
            return DiaDAO.Instance.CapNhatSoLuongDia(maDia, soLuong);
        }
    }
}