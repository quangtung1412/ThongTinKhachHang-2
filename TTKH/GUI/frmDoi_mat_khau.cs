using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AGRIBANKHD.BUS;
using AGRIBANKHD.Entities;
using AGRIBANKHD.DAL;
using AGRIBANKHD.Utilities;

namespace AGRIBANKHD.GUI
{
    public partial class frmDoi_mat_khau : Form
    {
        UserBUS uBUS = new UserBUS();
        public frmDoi_mat_khau()
        {
            InitializeComponent();
            txtTen_dang_nhap.Text = Utilities.Thong_tin_dang_nhap.ten_dang_nhap;
            this.AcceptButton = btnDoi_mat_khau;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDoi_mat_khau_Click(object sender, EventArgs e)
        {
                //kiểm tra mật khẩu mới và xác nhận mật khẩu mới có giống nhau không
                if (txtMat_khau_moi.Text != txtXac_nhan_mat_khau_moi.Text)
                {
                    MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu mới không trùng nhau. Đề nghị kiểm tra lại!");
                    return;
                }
                if (uBUS.DOI_MAT_KHAU(txtTen_dang_nhap.Text, txtMat_khau_moi.Text))
                {
                    MessageBox.Show("Đổi mật khẩu thành công. đề nghị đăng nhập lại bằng mật khẩu mới!");
                    //this.close();
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra trong quá trình đổi mật khẩu");
                }
        }

        //private void btnDoi_mat_khau_Click(object sender, EventArgs e)
        //{
        //    
        //}
    }
}
