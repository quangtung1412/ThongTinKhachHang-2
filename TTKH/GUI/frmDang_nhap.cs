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
using System.Xml;
using System.Diagnostics;

namespace AGRIBANKHD.GUI
{
    public partial class frmDang_nhap : Form
    {
        //CanbotindungBUS cbbus = new CanbotindungBUS();
        UserBUS userBus = new UserBUS();
        public string curVersion = Application.ProductVersion;
        //public Version curVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        //string curVersion = Application.ProductVersion;
        private bool Kiemtracapnhat()
        {
            bool has_update = false;
            string newVersion = "";
            // in newVersion variable we will store the  
            // version info from xml file  
            //Version newVersion = null;
            // and in this variable we will put the url we  
            // would like to open so that the user can  
            // download the new version  
            // it can be a homepage or a direct  
            // link to zip/exe file  
            //string url = "";
            //XmlTextReader reader = null;
            try
            {
                // provide the XmlTextReader with the URL of  
                // our xml document  
                //string xmlURL = "http://192.168.1.150/update_crm.xml";
                ////string xmlURL = "http://10.14.0.30/update_crm.xml";
                //reader = new XmlTextReader(xmlURL);
                //// simply (and easily) skip the junk at the beginning  
                //reader.MoveToContent();
                //// internal - as the XmlTextReader moves only  
                //// forward, we save current xml element name  
                //// in elementName variable. When we parse a  
                //// text node, we refer to elementName to check  
                //// what was the node name  
                //string elementName = "";
                //// we check if the xml starts with a proper  
                //// "ourfancyapp" element node  
                //if ((reader.NodeType == XmlNodeType.Element) &&
                //    (reader.Name == "bss"))
                //{
                //    while (reader.Read())
                //    {
                //        // when we find an element node,  
                //        // we remember its name  
                //        if (reader.NodeType == XmlNodeType.Element)
                //            elementName = reader.Name;
                //        else
                //        {
                //            // for text nodes...  
                //            if ((reader.NodeType == XmlNodeType.Text) &&
                //                (reader.HasValue))
                //            {
                //                // we check what the name of the node was  
                //                switch (elementName)
                //                {
                //                    case "version":
                //                        // thats why we keep the version info  
                //                        // in xxx.xxx.xxx.xxx format  
                //                        // the Version class does the  
                //                        // parsing for us  
                //                        newVersion = new Version(reader.Value);
                //                        break;
                //                    case "url":
                //                        url = reader.Value;
                //                        break;
                //                }
                //            }
                //        }
                //    }
                //}

                newVersion = DangNhapDAL.DV_GET_CURRENT_APP_VERSION(Application.ProductName);
                //newVersion = new Version(newV);
            }
            catch (Exception)
            {
                ErrorMessageDAL.DataAccessError();
            }
            //finally
            //{
            //    //if (reader != null) reader.Close();
            //}

            if (curVersion.CompareTo(newVersion) < 0)
            {
                // ask the user if he would like  
                // to download the new version  
                string title = "Thông báo cập nhật";
                string question = "Phiên bản bạn đang dùng " + curVersion.ToString() + ". Đã có phiên bản mới " + newVersion.ToString() + ". Bạn có muốn tải về?";
                if (DialogResult.Yes ==
                 MessageBox.Show(this, question, title,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question))
                {
                    // navigate the default web  
                    // browser to our app  
                    // homepage (the url  
                    // comes from the xml content)  
                    
                    //System.Diagnostics.Process.Start(url);
                    Process.Start(Application.StartupPath.ToString() + @"\BSS_UPDATE.exe");
                    has_update = true;
                }
            }
            return has_update;
        }

        public frmDang_nhap()
        {
            InitializeComponent();
            Text = "PHẦN MỀM HỖ TRỢ NGHIỆP VỤ - v" + curVersion + " - AGRIBANKHD - ĐĂNG NHẬP";
            //List<Chinhanh> dschinhanh = new List<Chinhanh>();
            //dschinhanh = AGRIBANKHD.BUS.ChinhanhBUS.DanhsachCN();
            this.AcceptButton = btnDang_nhap;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDang_nhap_Click(object sender, EventArgs e)
        {
            string uid = this.txtTen_dang_nhap.Text.Trim();
            string pass = this.txtMat_khau.Text.Trim();
            //string pass_mahoa = mahoa.mahoa(pass);
            //string group_list = "";

            if (uid == "")
            {
                MessageBox.Show("Chưa nhập tên đăng nhập.");
                txtTen_dang_nhap.Focus();
                return;
            }
            else if (pass == "")
            {
                MessageBox.Show("Chưa nhập mật khẩu.");
                txtMat_khau.Focus();
                return;
            }

            DataTable userDt = userBus.XAC_THUC_USER(uid, pass);

            if (userDt.Rows.Count <= 0)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu. Đề nghị kiểm tra lại!");
                return;
            }
            else
            {
                Chinhanh cn = ChinhanhBUS.CN_theo_ma(userDt.Rows[0]["MACN"].ToString());
                Thong_tin_dang_nhap.ten_dang_nhap = uid;
                Thong_tin_dang_nhap.mat_khau = pass;
                Thong_tin_dang_nhap.ma_cn = cn.ma_CN;
                Thong_tin_dang_nhap.ten_cn = cn.ten_CN;
                Thong_tin_dang_nhap.mst_cn = cn.mst;
                Thong_tin_dang_nhap.dia_chi_cn = cn.dia_chi;
                Thong_tin_dang_nhap.ten_cn_day_du = cn.ten_cn_day_du;
                Thong_tin_dang_nhap.ho_ten = userDt.Rows[0]["TENNV"].ToString();
                Thong_tin_dang_nhap.maNV = userDt.Rows[0]["MANV"].ToString();
                Thong_tin_dang_nhap.chuc_vu = userDt.Rows[0]["CHUCVU"].ToString();
                Thong_tin_dang_nhap.ma_pb = userDt.Rows[0]["MAPB"].ToString();
                Thong_tin_dang_nhap.tenPb = userDt.Rows[0]["TENPB"].ToString();
                Thong_tin_dang_nhap.hs = Convert.ToBoolean(userDt.Rows[0]["HS"].ToString());
                this.DialogResult = DialogResult.OK;
                this.Dispose();           
            }
        }

        private void frmDang_nhap_Shown(object sender, EventArgs e)
        {
            if (Kiemtracapnhat())
            {
                Application.Exit();
            }
        }

    }
}
