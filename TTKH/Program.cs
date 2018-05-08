using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AGRIBANKHD.GUI;
using AGRIBANKHD.Utilities;
using AGRIBANKHD.DAL;
using System.Data.SqlClient;

namespace AGRIBANKHD
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (CommonMethods.IsServerConnected())
            {
                frmDang_nhap frm = new frmDang_nhap();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new frmMain(Thong_tin_dang_nhap.admin, Thong_tin_dang_nhap.chuc_vu));
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("Không kết nối được đến máy chủ, đề nghị kiểm tra kết nối mạng hoặc liên hệ về Phòng Điện toán Agribank tỉnh!", "Lỗi kết nối", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                Application.Exit();
            }
        }
    }
}
