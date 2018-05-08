﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using AGRIBANKHD.Entities;
using System.Data;

namespace AGRIBANKHD.DAL
{
    class ThongTinTheDAL
    {
        public static DataRow LayThongTinThe(string soTk, string loaiThe)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[]{
                new SqlParameter("@sotk", soTk),
                new SqlParameter("@loaithe", loaiThe)
            };

            DataRow row = db.dt("DV_LAYTHONGTINTHE", Params).Rows[0];
            return row;
        }

        public static void NhanThe(The the)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[] { 
            new SqlParameter("@sotk", the.soTK),
            new SqlParameter("@loaithe", the.loaiThe),
            new SqlParameter("@sothe", the.soThe),
            new SqlParameter("@ngaynhan", the.ngayNhan)
            };

            db.dt("DV_NHANTHE", Params);
        }

        public static void GiaoThe(The the)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[] { 
            new SqlParameter("@sotk", the.soTK),
            new SqlParameter("@loaithe", the.loaiThe),
            new SqlParameter("@ngaygiao", the.ngayGiao)
            };

            db.dt("DV_GIAOTHE", Params);
        }

        public static DataRow LayPhongBan(string maPB) {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[] { 
            new SqlParameter("@mapb", maPB)
            };
            return db.dt("DV_LAYPHONGBAN", Params).Rows[0];
        }

        public static string LayTenChiNhanh(string maPb)
        {
            DataAccess db = new DataAccess();
            SqlParameter[] Params = new SqlParameter[] { 
            new SqlParameter("@mapb", maPb)
            };
            return db.dt("DV_LAYTENCN_THONGTINTHE", Params).Rows[0]["TENCN"].ToString();
        }
    }
}
