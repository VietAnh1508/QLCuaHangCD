using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUS
{
    public class HoaDonTamBUS
    {
        private static HoaDonTamBUS instance;
        public static HoaDonTamBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new HoaDonTamBUS();
                return instance;
            }
        }
        private HoaDonTamBUS() { }

        public List<HoaDonTam> LayHoaDonTam()
        {
            List<HoaDonTam> list = new List<HoaDonTam>();
            DataTable table = new DataTable();
            try
            {
                table = HoaDonTamDAO.Instance.LayHoaDonTam();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            foreach (DataRow row in table.Rows)
            {
                HoaDonTam temp = new HoaDonTam(row);
                list.Add(temp);
            }
            return list;
        }
    }
}