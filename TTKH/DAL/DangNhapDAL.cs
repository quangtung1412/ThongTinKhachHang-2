using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AGRIBANKHD.DAL
{
    class DangNhapDAL
    {
        public static string DV_GET_CURRENT_APP_VERSION(string appName)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("@appname", appName)
            };
            return db.dt("DV_GET_CURRENT_APP_VERSION", Params).Rows[0]["APPVERSION"].ToString();
        }
    }
}
