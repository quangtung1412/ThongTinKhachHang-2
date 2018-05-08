using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGRIBANKHD.Entities;
using AGRIBANKHD.DAL;
namespace AGRIBANKHD.BUS
{
    class ChinhanhBUS
    {
        chinhanhDAL dal = new chinhanhDAL();
        public static List<Chinhanh> DanhsachCN()
        {
            return chinhanhDAL.DanhsachCN();
        }

        public static Chinhanh CN_theo_ma(string ma_cn)
        {
            return chinhanhDAL.CN_theo_ma(ma_cn);
        }
    }
}
