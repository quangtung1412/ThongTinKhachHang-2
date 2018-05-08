using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AGRIBANKHD.DAL
{
    class ToVanChuyenDAL
    {
        public static DataTable DV_GET_THONGTINNHANVIEN_MACN(string maCN)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("@manv", maCN)
            };
            DataTable dt = db.dt("DV_GET_THONGTINNHANVIEN_MANV", Params);
            return dt;
        }
    }
}
