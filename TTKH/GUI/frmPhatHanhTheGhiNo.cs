﻿using AGRIBANKHD.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AGRIBANKHD.Entities;
using System.Threading;
using System.IO;
using AGRIBANKHD.DAL;

namespace AGRIBANKHD.GUI
{
    public partial class frmPhatHanhTheGhiNo : Form
    {
        private const string fileNamePhatHanhMoi = "PHAT_HANH_MOI";
        private const string fileNamePhatHanhLai = "PHAT_HANH_LAI";
        private const string fileNameHopDong = "HOP_DONG";
        private const string fileNameGiayHen = "GIAY_HEN";

        private List<TextBox> listTxtNotNull;

        private NguoiDaiDien[] dsNguoiDaiDien;

        private List<string>
            ttchung_nguon,
            ttchung_dich,
            phat_hanh_moi_nguon,
            phat_hanh_moi_dich,
            phat_hanh_lai_nguon,
            phat_hanh_lai_dich,
            hop_dong_nguon,
            hop_dong_dich,
            giay_hen_nguon,
            giay_hen_dich;

        public frmPhatHanhTheGhiNo()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

            ttchung_dich = new List<string>();
            ttchung_nguon = new List<string>();
            phat_hanh_moi_dich = new List<string>();
            phat_hanh_moi_nguon = new List<string>();
            phat_hanh_lai_dich = new List<string>();
            phat_hanh_lai_nguon = new List<string>();
            hop_dong_dich = new List<string>();
            hop_dong_nguon = new List<string>();
            giay_hen_dich = new List<string>();
            giay_hen_nguon = new List<string>();

            //Phat hanh moi
            clbND_Moi.SetItemChecked(0, true);
            clbQT_Moi.SetItemChecked(0, true);
            clbHangThe_Moi.SetItemChecked(0, true);
            clbHTPhatHanh_Moi.SetItemChecked(0, true);
            clbHTNhanThe_Moi.SetItemChecked(0, true);

            //Phat hanh lai
            clbND_Lai.SetItemChecked(0, true);
            clbQT_Lai.SetItemChecked(0, true);
            clbHangThe_Lai.SetItemChecked(0, true);
            clbHTPhatHanh_Lai.SetItemChecked(0, true);

            //Hop dong
            //Lay thong tin nguoi dai dien
            dsNguoiDaiDien = DAL.PhatHanhTheGhiNoDAL.DanhSachNguoiDaiDien(Thong_tin_dang_nhap.ma_pb);
            
            if (dsNguoiDaiDien != null)
            {
                //sap xep dsNguoiDaiDien
                for (int i = 0; i < dsNguoiDaiDien.Length; i++)
                {
                    var temp = dsNguoiDaiDien[0];
                    if (dsNguoiDaiDien[i].chucVu == "Giám đốc")
                    {
                        dsNguoiDaiDien[0] = dsNguoiDaiDien[i];
                        dsNguoiDaiDien[i] = temp;
                    }
                }

                for (int i = 0; i < dsNguoiDaiDien.Length; i++)
                {
                    cbNguoiDaiDien_BenA.Items.Add(dsNguoiDaiDien[i].hoTen);
                }
                if (cbNguoiDaiDien_BenA.Items.Count > 0)
                    cbNguoiDaiDien_BenA.SelectedIndex = 0;
            }

            //TTKH
            cbTimKiem.SelectedIndex = 0;
            txtTimKiem.Focus();
        }

        void MyInit() {
            listTxtNotNull = new List<TextBox>();
            //listTxtNotNull.Add(txt)
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiemKH();
        }

        void TimKiemKH() {
            if (string.IsNullOrEmpty(txtTimKiem.Text))
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm!", "Thông báo", MessageBoxButtons.OK);
            else
            {
                Entities.KhachHangDV kh = null;
                try
                {
                    if (cbTimKiem.SelectedIndex == 1)
                        kh = DAL.PhatHanhTheGhiNoDAL.TimKiemKH_TheoMaKH(txtTimKiem.Text);
                    else
                        kh = DAL.PhatHanhTheGhiNoDAL.TimKiemKH_TheoCMND(txtTimKiem.Text);
                    if (kh == null)
                    {
                        KhongTimThayKH();
                    }
                    else
                    {
                        TimThayKH(kh);
                    }
                }
                catch
                {
                    DAL.ErrorMessageDAL.DataAccessError();
                }
            }
        }


        void KhongTimThayKH() {
            MessageBox.Show(@"Không tìm thấy khách hàng!", "Thông báo", MessageBoxButtons.OK);
            //SetTextBoxStatus_TTKH(true);
            tCtrDichVu.Enabled = false;
            ClearAllTextBox();

        }

        void TimThayKH(Entities.KhachHangDV kh) {
            cbSoTK.Items.Clear();
            //Thong tin chung
            txtNgayCap.Text = kh.ngay_cap.ToString("dd/MM/yyyy");
            txtCMT.Text = kh.cmt;
            txtNoiCap.Text = PhatHanhTheGhiNoDAL.DV_GET_NOICAPCMND(kh.noi_cap);
            txtMaKH.Text = kh.ma_KH;
            txtHoTen.Text = kh.ho_ten;
            txtNgaySinh.Text = kh.ngay_sinh.ToString("dd/MM/yyyy");
            txtSoDienThoai.Text = kh.dien_thoai;
            txtEmail.Text = kh.email;
            txtDiaChi.Text = kh.dia_chi;
            txtQuocTich.Text = "Việt Nam";

            //Thong tin ben B
            txtHoTen_BenB.Text = kh.ho_ten;
            txtCMT_BenB.Text = kh.cmt;
            txtDiaChi_BenB.Text = kh.dia_chi;
            txtNgayCap_BenB.Text = kh.ngay_cap.ToString("dd/MM/yyyy");
            txtNoiCap_BenB.Text = txtNoiCap.Text;
            txtNgayDeNghi_BenB.Text = DateTime.Now.ToString("dd/MM/yyyy");

            if (kh.gioi_tinh)
            {
                cbGioiTinh.SelectedIndex = 0;
            }
            else {
                cbGioiTinh.SelectedIndex = 1;
            }

            //Lay cac so TK cua KH
            try
            {
                DataTable dt = DAL.PhatHanhTheGhiNoDAL.TimSoTK(kh.ma_KH);
                for (int i = 0; i < dt.Rows.Count; i++) {
                    string soTK = dt.Rows[i]["SOTK"].ToString();
                    char loaiTK = soTK[4];
                    if (loaiTK == '1' || loaiTK == '2')
                        cbSoTK.Items.Add(soTK);
                }
                if (cbSoTK.Items.Count > 0)
                {
                    cbSoTK.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Khách hàng chưa có số tài khoản!\nHãy điền vào số tài khoản!", "Thông báo", MessageBoxButtons.OK);
                    cbSoTK.Focus();
                }
                SetTabControlStatus(true);
            }
            catch {
                DAL.ErrorMessageDAL.DataAccessError();
            }

        }

        void SetTabControlStatus(bool status) {
            tCtrDichVu.Enabled = status;
            btnLuuHoSo.Enabled = status;
        }

        void SetTextBoxStatus_TTKH(bool status) {
            txtNgayCap.Enabled = status;
            txtNoiCap.Enabled = status;
            //txtMaKH.Enabled = status;
            txtHoTen.Enabled = status;
            txtQuocTich.Enabled = status;
            cbSoTK.Enabled = status;
            txtNgaySinh.Enabled = status;
            txtEmail.Enabled = status;
            txtDiaChi.Enabled = status;
            cbGioiTinh.Enabled = status;
            txtSoDienThoai.Enabled = status;
        }

        void ClearAllTextBox() {
            txtNgayCap.Text = "";
            txtNoiCap.Text = "";
            txtCMT.Text = "";
            txtHoTen.Text = "";
            txtQuocTich.Text = "";
            cbSoTK.SelectedItem = null;
            cbSoTK.Items.Clear();
            cbSoTK.Text = "";
            txtNgaySinh.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            cbGioiTinh.SelectedItem = null;
            txtSoDienThoai.Text = "";
        }

        //Menu Thong tin khach hang
        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TimKiemKH();
            }
        }

        private void txbSoCMT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtSoTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void cbSoTK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (((sender as ComboBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void cbSoTK_Validated(object sender, EventArgs e)
        {
            foreach (var c in cbSoTK.Items)
            {
                if (c.ToString() == cbSoTK.Text) return;
            }
            cbSoTK.Items.Add(cbSoTK.Text);
            cbSoTK.SelectedIndex = cbSoTK.Items.Count - 1;
        }
       
        //Menu tab Phat hanh moi the ghi no
        private void clbND_Moi_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < clbND_Moi.Items.Count; ++ix)
                if (ix != e.Index) clbND_Moi.SetItemChecked(ix, false);
        }

        private void clbQT_Moi_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < clbQT_Moi.Items.Count; ++ix)
                if (ix != e.Index) clbQT_Moi.SetItemChecked(ix, false);
        }

        private void clbHangThe_Moi_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < clbHangThe_Moi.Items.Count; ++ix)
                if (ix != e.Index) clbHangThe_Moi.SetItemChecked(ix, false);
        }

        private void clbHTPhatHanh_Moi_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < clbHTPhatHanh_Moi.Items.Count; ++ix)
                if (ix != e.Index) clbHTPhatHanh_Moi.SetItemChecked(ix, false);
        }

        private void clbHTNhanThe_Moi_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < clbHTNhanThe_Moi.Items.Count; ++ix)
                if (ix != e.Index) clbHTNhanThe_Moi.SetItemChecked(ix, false);
        }

        private void ckbSMS_Moi_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSMS_Moi.Checked) txtDTDD_SMS_Moi.Enabled = true;
            else { 
                txtDTDD_SMS_Moi.Enabled = false;
                txtDTDD_SMS_Moi.Text = "";
            }
        }

        private void ckbInternet_Moi_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbInternet_Moi.Checked) txtHMGD_Moi.Enabled = true;
            else
            {
                txtHMGD_Moi.Enabled = false;
                txtHMGD_Moi.Text = "";
            }
        }

        private void txtDTDD_SMS_Moi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtHMGD_Moi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }


        //Menu tab phat hanh lai the ghi no
        private void clbND_Lai_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < clbND_Lai.Items.Count; ++ix)
                if (ix != e.Index) clbND_Lai.SetItemChecked(ix, false);
        }

        private void clbQT_Lai_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < clbQT_Lai.Items.Count; ++ix)
                if (ix != e.Index) clbQT_Lai.SetItemChecked(ix, false);
        }

        private void clbHangThe_Lai_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < clbHangThe_Lai.Items.Count; ++ix)
                if (ix != e.Index) clbHangThe_Lai.SetItemChecked(ix, false);
        }

        private void clbHTPhatHanh_Lai_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < clbHTPhatHanh_Lai.Items.Count; ++ix)
                if (ix != e.Index) clbHTPhatHanh_Lai.SetItemChecked(ix, false);
        }

        private void ckbSMS_Lai_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSMS_Lai.Checked) txtDTDD_SMS_Lai.Enabled = true;
            else txtDTDD_SMS_Lai.Enabled = false;
        }

        private void ckbInternet_Lai_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbInternet_Lai.Checked) txtHMGD_Lai.Enabled = true;
            else txtHMGD_Lai.Enabled = false;
        }

        private void txtDTDD_SMS_Lai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtHMGD_Lai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        
        //EMenu tab Hop Dong
        private void cbNguoiDaiDien_BenA_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbNguoiDaiDien_BenA.SelectedIndex;
            //if (dsNguoiDaiDien[index].chucVu == "Branch General Manager")
            //    txtChucVu_BenA.Text = "Giám đốc";
            //else txtChucVu_BenA.Text = "Phó giám đốc";
            txtChucVu_BenA.Text = dsNguoiDaiDien[index].chucVu;
            txtDienThoai_BenA.Text = dsNguoiDaiDien[index].Sdt;
            txtFax_BenA.Text = dsNguoiDaiDien[index].Fax;
            txtDiaChi_BenA.Text = dsNguoiDaiDien[index].diaChi;
            txtGiayUyQuyen_BenA.Text = dsNguoiDaiDien[index].giayUQ;
        }

        private void txtCMT_BenB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtNgayCap_BenB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtNgayDeNghi_BenB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        void LuuSoTK()
        {
            try
            {
                PhatHanhTheGhiNoDAL.DV_UPDATE_SOTK(txtMaKH.Text, cbSoTK.Text);
            }
            catch
            {
                ErrorMessageDAL.DataAccessError();
            }
        }

        //Luu ho so
        private void btnLuuHoSo_Click(object sender, EventArgs e)
        {
            KhoiTaoTTChung();
            LuuSoTK();
            //Phat hanh moi the ghi no
            switch (tCtrDichVu.SelectedIndex)
            {
                case 0: //Phat hanh moi 
                    if (CheckNullPhatHanhMoi()) return;

                    //Phat hanh the noi dia
                    if (clbND_Moi.CheckedItems.Count > 0 && clbQT_Moi.CheckedItems.Count == 0) //The noi dia
                    {
                        if (!LuuPhatHanhMoiTheNoiDia()) return;
                    }
                    //Phat hanh the quoc te
                    if (clbQT_Moi.CheckedItems.Count > 0 && clbND_Moi.CheckedItems.Count == 0)
                    {
                        if (!LuuPhatHanhMoiTheQuocTe()) return;
                    }

                    //Phat hanh the noi dia + quoc te
                    if (clbQT_Moi.CheckedItems.Count > 0 && clbND_Moi.CheckedItems.Count > 0)
                    {
                        string soTK = cbSoTK.SelectedItem.ToString();
                        string loaiTheND = StringConverter(clbND_Moi.CheckedItems[0].ToString());
                        string loaiTheQT = StringConverter(clbQT_Moi.CheckedItems[0].ToString());

                        if (PhatHanhTheGhiNoDAL.TimThe(soTK, loaiTheND).Rows.Count > 0 &&
                            PhatHanhTheGhiNoDAL.TimThe(soTK, loaiTheQT).Rows.Count == 0)
                        {
                            MessageBox.Show("Số tài khoản " + soTK + " đã đăng ký loại thẻ " + loaiTheND + "!", "Thông báo", MessageBoxButtons.OK);
                            return;
                        }

                        else if (PhatHanhTheGhiNoDAL.TimThe(soTK, loaiTheND).Rows.Count == 0 &&
                                 PhatHanhTheGhiNoDAL.TimThe(soTK, loaiTheQT).Rows.Count > 0)
                        {
                            MessageBox.Show("Số tài khoản " + soTK + " đã đăng ký loại thẻ " + loaiTheQT + "!", "Thông báo", MessageBoxButtons.OK);
                            return;
                        }
                        else if (PhatHanhTheGhiNoDAL.TimThe(soTK, loaiTheND).Rows.Count > 0 &&
                                 PhatHanhTheGhiNoDAL.TimThe(soTK, loaiTheQT).Rows.Count > 0)
                        {
                            MessageBox.Show("Số tài khoản " + soTK + " đã đăng ký loại thẻ " + loaiTheND + "!", "Thông báo", MessageBoxButtons.OK);
                            MessageBox.Show("Số tài khoản " + soTK + " đã đăng ký loại thẻ " + loaiTheQT + "!", "Thông báo", MessageBoxButtons.OK);
                            return;
                        }
                        else
                        {
                            LuuPhatHanhMoiTheNoiDia();
                            LuuPhatHanhMoiTheQuocTe();
                        }
                    }

                    //Tao file word
                    KhoiTaoPhatHanhMoi();
                    Thread tMoi = new Thread(PhatHanhMoi);
                    tMoi.Start();
                    break;
                case 1: //Phat hanh lai
                    if (CheckNullPhatHanhLai()) return;

                    //Phat hanh the noi dia
                    if (clbND_Lai.CheckedItems.Count > 0 && clbQT_Lai.CheckedItems.Count == 0) //The noi dia
                    {
                        if (!LuuPhatHanhLaiTheNoiDia()) return;
                    }
                    //Phat hanh the quoc te
                    if (clbQT_Lai.CheckedItems.Count > 0 && clbND_Lai.CheckedItems.Count == 0)
                    {
                        if (!LuuPhatHanhLaiTheQuocTe()) return;
                    }

                    //Phat hanh the noi dia + quoc te
                    if (clbQT_Lai.CheckedItems.Count > 0 && clbND_Lai.CheckedItems.Count > 0)
                    {
                        string soTK = cbSoTK.SelectedItem.ToString();
                        string loaiTheND = StringConverter(clbND_Lai.CheckedItems[0].ToString());
                        string loaiTheQT = StringConverter(clbQT_Lai.CheckedItems[0].ToString());

                        if (PhatHanhTheGhiNoDAL.TimThe(soTK, loaiTheND).Rows.Count > 0 &&
                            PhatHanhTheGhiNoDAL.TimThe(soTK, loaiTheQT).Rows.Count == 0)
                        {
                            MessageBox.Show("Số tài khoản " + soTK + " đã đăng ký loại thẻ " + loaiTheND + "!", "Thông báo", MessageBoxButtons.OK);
                            return;
                        }

                        else if (PhatHanhTheGhiNoDAL.TimThe(soTK, loaiTheND).Rows.Count == 0 &&
                                 PhatHanhTheGhiNoDAL.TimThe(soTK, loaiTheQT).Rows.Count > 0)
                        {
                            MessageBox.Show("Số tài khoản " + soTK + " đã đăng ký loại thẻ " + loaiTheQT + "!", "Thông báo", MessageBoxButtons.OK);
                            return;
                        }
                        else if (PhatHanhTheGhiNoDAL.TimThe(soTK, loaiTheND).Rows.Count > 0 &&
                                 PhatHanhTheGhiNoDAL.TimThe(soTK, loaiTheQT).Rows.Count > 0)
                        {
                            MessageBox.Show("Số tài khoản " + soTK + " đã đăng ký loại thẻ " + loaiTheND + "!", "Thông báo", MessageBoxButtons.OK);
                            MessageBox.Show("Số tài khoản " + soTK + " đã đăng ký loại thẻ " + loaiTheQT + "!", "Thông báo", MessageBoxButtons.OK);
                            return;
                        }
                        else
                        {
                            LuuPhatHanhLaiTheNoiDia();
                            LuuPhatHanhLaiTheQuocTe();
                        }
                    }

                    KhoiTaoPhatHanhLai();
                    Thread tLai = new Thread(PhatHanhLai);
                    tLai.Start();
                    break;
                case 2: //Hop dong
                    if (CheckNullHopDong()) return;
                    KhoiTaoHopDong();
                    Thread tHD = new Thread(HopDong);
                    tHD.Start();
                    break;
                case 3: //Giay hen
                    break;
                default: break;
            }
        }

        //Procedures
        private void KhoiTaoTTChung() {
            ttchung_nguon.Clear();
            ttchung_dich.Clear();

            ttchung_nguon.Add(DateTime.Now.Day.ToString());
            ttchung_nguon.Add(DateTime.Now.Month.ToString());
            ttchung_nguon.Add(DateTime.Now.Year.ToString());
            ttchung_nguon.Add(DateTime.Now.ToString("dd/MM/yyyy"));
            if (Thong_tin_dang_nhap.hs)
                ttchung_nguon.Add(Thong_tin_dang_nhap.ten_cn);
            else
                ttchung_nguon.Add(Thong_tin_dang_nhap.tenPb);
            ttchung_nguon.Add(txtCMT.Text);
            ttchung_nguon.Add(txtHoTen.Text);
            ttchung_nguon.Add(txtTimKiem.Text);
            ttchung_nguon.Add(txtSoDienThoai.Text);
            ttchung_nguon.Add(txtEmail.Text);
            ttchung_nguon.Add(txtDiaChi.Text);
            ttchung_nguon.Add(txtNgaySinh.Text);
            ttchung_nguon.Add(txtNgayCap.Text);
            ttchung_nguon.Add(txtNoiCap.Text);
            ttchung_nguon.Add(txtQuocTich.Text);
            ttchung_nguon.Add(cbSoTK.Text);

            ttchung_dich.Add("<NGAY>");
            ttchung_dich.Add("<THANG>");
            ttchung_dich.Add("<NAM>");
            ttchung_dich.Add("<HOM_NAY>");
            ttchung_dich.Add("<CHI_NHANH>");
            ttchung_dich.Add("<CMND>");
            ttchung_dich.Add("<HO_TEN>");
            ttchung_dich.Add("<MA_KH>");
            ttchung_dich.Add("<DIEN_THOAI>");
            ttchung_dich.Add("<EMAIL>");
            ttchung_dich.Add("<DIA_CHI>");
            ttchung_dich.Add("<NGAY_SINH>");
            ttchung_dich.Add("<NGAY_CAP>");
            ttchung_dich.Add("<NOI_CAP>");
            ttchung_dich.Add("<QUOC_TICH>");
            ttchung_dich.Add("<SO_TK>");

            if (cbGioiTinh.SelectedIndex == 0) { //gioi tinh NAM
                ttchung_nguon.Add(((char)0x2611).ToString());
                ttchung_dich.Add("<GT_0>");
                ttchung_nguon.Add(((char)0x2610).ToString());
                ttchung_dich.Add("<GT_1>");
            }
            else if (cbGioiTinh.SelectedIndex == 1) { //gioi tinh NU
                ttchung_nguon.Add(((char)0x2611).ToString());
                ttchung_dich.Add("<GT_1>");
                ttchung_nguon.Add(((char)0x2610).ToString());
                ttchung_dich.Add("<GT_0>");
            }
        }

        private void KhoiTaoPhatHanhMoi()
        {
            phat_hanh_moi_nguon.Clear();
            phat_hanh_moi_dich.Clear();

            phat_hanh_moi_dich.Add("<GN>"); //Ghi no noi dia
            phat_hanh_moi_dich.Add("<LN>"); //Lap nghiep
            phat_hanh_moi_dich.Add("<LKTH>"); //Lien ket thuong hieu
            phat_hanh_moi_dich.Add("<VS>"); //Visa
            phat_hanh_moi_dich.Add("<MC>"); //MasterCard
            phat_hanh_moi_dich.Add("<C>"); //Chuan
            phat_hanh_moi_dich.Add("<V>"); //Vang
            phat_hanh_moi_dich.Add("<PHT>"); //Phat hanh thuong
            phat_hanh_moi_dich.Add("<PHN>"); //Phat hanh nhanh
            phat_hanh_moi_dich.Add("<TNH>"); //Tai ngan hang
            phat_hanh_moi_dich.Add("<TNR>"); //Tai nha rieng
            phat_hanh_moi_dich.Add("<SMS>"); //SMS
            phat_hanh_moi_dich.Add("<SMS_DTDD>");
            phat_hanh_moi_dich.Add("<INTERNET>");
            phat_hanh_moi_dich.Add("<HMGD>"); //Han muc giao dich
            phat_hanh_moi_dich.Add("<HMGD_BANG_CHU>");
            phat_hanh_moi_dich.Add("<OTP_DTDD>");
            phat_hanh_moi_dich.Add("<OTP_EMAIL>");
            phat_hanh_moi_dich.Add("<BAO_HIEM>");
            phat_hanh_moi_dich.Add("<DONG_Y>");
            phat_hanh_moi_dich.Add("<KHONG_DONG_Y>");

            for (int i = 0; i < 26; i++) //Ten in the
            {
                phat_hanh_moi_dich.Add("<" + (i+1) + ">");
            }


            //Noi dia
            CheckedListBoxToString(clbND_Moi, phat_hanh_moi_nguon);
            //Quoc te
            CheckedListBoxToString(clbQT_Moi, phat_hanh_moi_nguon);
            //Hang the
            CheckedListBoxToString(clbHangThe_Moi, phat_hanh_moi_nguon);
            //Hinh thuc phat hanh
            CheckedListBoxToString(clbHTPhatHanh_Moi, phat_hanh_moi_nguon);
            //Hinh thuc nhan the
            CheckedListBoxToString(clbHTNhanThe_Moi, phat_hanh_moi_nguon);
            //SMS
            if (ckbSMS_Moi.Checked)
            {
                phat_hanh_moi_nguon.Add(((char)0x2611).ToString());
                phat_hanh_moi_nguon.Add(txtDTDD_SMS_Moi.Text);
            }
            else
            {
                phat_hanh_moi_nguon.Add(((char)0x2610).ToString());
                phat_hanh_moi_nguon.Add("");
            }

            //Internet
            if (ckbInternet_Moi.Checked)
            {
                phat_hanh_moi_nguon.Add(((char)0x2611).ToString());
                phat_hanh_moi_nguon.Add(txtHMGD_Moi.Text);
                phat_hanh_moi_nguon.Add(Utilities.CommonMethods.ChuyenSoSangChu(txtHMGD_Moi.Text));
            }
            else
            {
                phat_hanh_moi_nguon.Add(((char)0x2610).ToString());
                phat_hanh_moi_nguon.Add("");
                phat_hanh_moi_nguon.Add("");
            }

            phat_hanh_moi_nguon.Add(txtDTDD_SMS_Moi.Text);
            phat_hanh_moi_nguon.Add(txtEmail.Text);

            //Bao hiem
            if (ckbBaoHiem_Moi.Checked)
                phat_hanh_moi_nguon.Add(((char)0x2611).ToString());
            else phat_hanh_moi_nguon.Add(((char)0x2610).ToString());

            phat_hanh_moi_nguon.Add(((char)0x2611).ToString());
            phat_hanh_moi_nguon.Add(((char)0x2610).ToString());

            //Ten in the
            string sTenInThe = CommonMethods.RemoveUnicode(txtHoTen.Text);
            sTenInThe = sTenInThe.ToUpper();
            char[] cTenInThe = new char[26];
            for (int i = 0; i < sTenInThe.Length; i++)
                cTenInThe[i] = sTenInThe[i];
            for (int i = 0; i < cTenInThe.Length; i++)
            {
                if(cTenInThe[i] != '\0'){
                    phat_hanh_moi_nguon.Add(cTenInThe[i].ToString());
                }
                else
                    phat_hanh_moi_nguon.Add("");
            }
        }

        private void KhoiTaoPhatHanhLai()
        {
            phat_hanh_lai_nguon.Clear();
            phat_hanh_lai_dich.Clear();

            // Ghi no noi dia
            phat_hanh_lai_dich.Add("<GNND>");
            phat_hanh_lai_dich.Add("<LN>");
            phat_hanh_lai_dich.Add("<SV>");
            phat_hanh_lai_dich.Add("<LKTH>");

            CheckedListBoxToString(clbND_Lai, phat_hanh_lai_nguon);
            //Ghi no quoc te
            phat_hanh_lai_dich.Add("<GNQT>");
            phat_hanh_lai_dich.Add("<TDQT>");
            phat_hanh_lai_dich.Add("<VS>");
            phat_hanh_lai_dich.Add("<MC>");
            phat_hanh_lai_dich.Add("<JCB>");

            CheckedListBoxToString(clbQT_Lai, phat_hanh_lai_nguon);
            //Hang The
            phat_hanh_lai_dich.Add("<C>");
            phat_hanh_lai_dich.Add("<V>");
            phat_hanh_lai_dich.Add("<BK>");

            CheckedListBoxToString(clbHangThe_Lai, phat_hanh_lai_nguon);
            //Hinh thuc phat hanh
            phat_hanh_lai_dich.Add("<PHT>");
            phat_hanh_lai_dich.Add("<PHN>");

            CheckedListBoxToString(clbHTPhatHanh_Lai, phat_hanh_lai_nguon);

            //Dang ky dich vu
            phat_hanh_lai_dich.Add("<SMS>");
            phat_hanh_lai_dich.Add("<DTDD_OTP>");
            phat_hanh_lai_dich.Add("<EMAIL_OTP>");
            phat_hanh_lai_dich.Add("<INTERNET>");
            phat_hanh_lai_dich.Add("<HMGD>");
            phat_hanh_lai_dich.Add("<BANG_CHU>");
            phat_hanh_lai_dich.Add("<BAO_HIEM>");


            if (ckbSMS_Lai.Checked)
            {
                phat_hanh_lai_nguon.Add(((char)0x2611).ToString());
                phat_hanh_lai_nguon.Add(txtDTDD_SMS_Lai.Text);
                phat_hanh_lai_nguon.Add(txtEmail.Text);
            }
            else
            {
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add("");
                phat_hanh_lai_nguon.Add("");
            }

            if (ckbInternet_Lai.Checked)
            {
                phat_hanh_lai_nguon.Add(((char)0x2611).ToString());
                phat_hanh_lai_nguon.Add(txtHMGD_Lai.Text);
                phat_hanh_lai_nguon.Add(Utilities.CommonMethods.ChuyenSoSangChu(txtHMGD_Lai.Text));
            }
            else
            {
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());
                phat_hanh_lai_nguon.Add("");
                phat_hanh_lai_nguon.Add("");
            }

            if (ckbBaoHiem_Lai.Checked)
                phat_hanh_lai_nguon.Add(((char)0x2611).ToString());
            else
                phat_hanh_lai_nguon.Add(((char)0x2610).ToString());

            //phan danh cho ngan hang
            phat_hanh_lai_dich.Add("<CHAP_NHAN>");
            phat_hanh_lai_nguon.Add(((char)0x2611).ToString());
            phat_hanh_lai_dich.Add("<KHONG_CHAP_NHAN>");
            phat_hanh_lai_nguon.Add(((char)0x2610).ToString());

            phat_hanh_lai_dich.Add("<SO_LUONG_THE>");
            int slThe = 0;
            slThe += clbND_Lai.CheckedItems.Count + clbQT_Lai.CheckedItems.Count;
            phat_hanh_lai_nguon.Add(slThe.ToString());
        }
        private void KhoiTaoHopDong()
        {
            hop_dong_nguon.Clear();
            hop_dong_dich.Clear();

            hop_dong_dich.Add("<CHI_NHANH_0>");
            hop_dong_nguon.Add(Thong_tin_dang_nhap.ten_cn.ToUpper());

            hop_dong_dich.Add("<SO_HD>");
            hop_dong_nguon.Add(txtSoHD.Text);

            //Ben A
            hop_dong_dich.Add("<DAI_DIEN>");
            hop_dong_nguon.Add(cbNguoiDaiDien_BenA.SelectedItem.ToString());

            hop_dong_dich.Add("<CHUC_VU>");
            hop_dong_nguon.Add(txtChucVu_BenA.Text);

            hop_dong_dich.Add("<SDT_CN>");
            hop_dong_nguon.Add(txtDienThoai_BenA.Text);

            hop_dong_dich.Add("<FAX>");
            hop_dong_nguon.Add(txtFax_BenA.Text);

            hop_dong_dich.Add("<DIACHI_CN>");
            hop_dong_nguon.Add(txtDiaChi_BenA.Text);

            hop_dong_dich.Add("<UY_QUYEN>");
            hop_dong_nguon.Add(txtGiayUyQuyen_BenA.Text);

            //Ben B
            hop_dong_dich.Add("<HOTEN_KH>");
            hop_dong_nguon.Add(txtHoTen_BenB.Text);

            hop_dong_dich.Add("<DIACHI_KH>");
            hop_dong_nguon.Add(txtDiaChi_BenB.Text);

            hop_dong_dich.Add("<CMND_KH>");
            hop_dong_nguon.Add(txtCMT_BenB.Text);

            hop_dong_dich.Add("<NGAY_CAP_KH>");
            hop_dong_nguon.Add(txtNgayCap_BenB.Text);

            hop_dong_dich.Add("<NOI_CAP_KH>");
            hop_dong_nguon.Add(txtNoiCap_BenB.Text);

            hop_dong_dich.Add("<NGAY_DE_NGHI>");
            hop_dong_nguon.Add(txtNgayDeNghi_BenB.Text);
        }
        void PhatHanhMoi() {
            var listNguon = ttchung_nguon;
            listNguon.AddRange(phat_hanh_moi_nguon);
            var listDich = ttchung_dich;
            listDich.AddRange(phat_hanh_moi_dich);
            saveFilePhatHanhMoi.Filter = "Word Documents|*.docx";

            string subFolder = @"PhatHanhMoi\";
            if (!CommonMethods.SubFolderExist(subFolder))
                CommonMethods.CreateSubFolder(subFolder);

            string TemplateFileLocation = CommonMethods.TemplateFileLocation(fileNamePhatHanhMoi + ".docx");
            string saveFileLocation = CommonMethods.SaveFileLocation(subFolder + fileNamePhatHanhMoi + "_" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss") + ".docx");


            if (CommonMethods.CreateWordDocument(TemplateFileLocation, saveFileLocation, listDich, listNguon))
            {
                Thread.Sleep(500);
                MessageBox.Show("File đã được tạo tại đường dẫn: " + saveFileLocation, "Tạo file thành công");
                OpenFileWord(saveFileLocation);
            }

            
        }

        void PhatHanhLai()
        {
            var listNguon = ttchung_nguon;
            listNguon.AddRange(phat_hanh_lai_nguon);
            var listDich = ttchung_dich;
            listDich.AddRange(phat_hanh_lai_dich);
            saveFilePhatHanhLai.Filter = "Word Documents|*.docx";

            string subFolder = @"PhatHanhLai\";
            if (!CommonMethods.SubFolderExist(subFolder))
                CommonMethods.CreateSubFolder(subFolder);

            string TemplateFileLocation = CommonMethods.TemplateFileLocation(fileNamePhatHanhLai + ".docx");
            string saveFileLocation = CommonMethods.SaveFileLocation(subFolder + fileNamePhatHanhMoi + "_" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss") + ".docx");

            

            if (CommonMethods.CreateWordDocument(TemplateFileLocation, saveFileLocation, listDich, listNguon))
            {
                Thread.Sleep(500);
                MessageBox.Show("File đã được tạo tại đường dẫn: " + saveFileLocation, "Tạo file thành công");
                OpenFileWord(saveFileLocation);
            }

        }

        void HopDong()
        {
            var listNguon = ttchung_nguon;
            listNguon.AddRange(hop_dong_nguon);
            var listDich = ttchung_dich;
            listDich.AddRange(hop_dong_dich);
            saveFileHopDong.Filter = "Word Documents|*.docx";

            string subFolder = @"HopDong\";
            if (!CommonMethods.SubFolderExist(subFolder))
                CommonMethods.CreateSubFolder(subFolder);

            string TemplateFileLocation = CommonMethods.TemplateFileLocation(fileNameHopDong + ".docx");
            string saveFileLocation = CommonMethods.SaveFileLocation(subFolder + fileNameHopDong + "_" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss") + ".docx");


            if (CommonMethods.CreateWordDocument(TemplateFileLocation, saveFileLocation, listDich, listNguon))
            {
                MessageBox.Show("File đã được tạo tại đường dẫn: " + saveFileLocation, "Tạo file thành công");
                Thread.Sleep(500);
                OpenFileWord(saveFileLocation);

            }
        }

        void OpenFileWord(string fileLocation)
        {
            Microsoft.Office.Interop.Word.Application ap = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document document = ap.Documents.Open(fileLocation);
            //ap.Visible = false;
            //try
            //{
            //    document.PrintOut();
            //}
            //catch
            //{
            //    MessageBox.Show("Vui lòng kiểm tra máy in!", "Thông báo", MessageBoxButtons.OK);
            //}
            //document.Close();
            //ap.Quit();
            ap.Visible = true;
        }

        void CheckedListBoxToString(CheckedListBox clb, List<string> lNguon)
        {
            for (int i = 0; i < clb.Items.Count; i++)
            {
                if (clb.GetItemChecked(i))
                {
                    lNguon.Add(((char)0x2611).ToString());
                }
                else
                    lNguon.Add(((char)0x2610).ToString());
            }
        }

        bool CheckNullPhatHanhMoi()
        {
            if (ckbSMS_Moi.Checked && string.IsNullOrEmpty(txtDTDD_SMS_Moi.Text))
            {
                MessageBox.Show("Vui Lòng nhập số điện thoại nhận SMS!", "Thông báo", MessageBoxButtons.OK);
                txtDTDD_SMS_Moi.Focus();
                return true;
            }

            if (ckbInternet_Moi.Checked && string.IsNullOrEmpty(txtHMGD_Moi.Text))
            {
                MessageBox.Show("Vui Lòng nhập hạn mức giao dịch trên Internet!", "Thông báo", MessageBoxButtons.OK);
                txtHMGD_Moi.Focus();
                return true;
            }

            if (clbQT_Moi.CheckedItems.Count == 0 && clbND_Moi.CheckedItems.Count == 0)
            {
                MessageBox.Show("Vui Lòng chọn ít nhất 1 loại thẻ!", "Thông báo", MessageBoxButtons.OK);
                return true;
            }

            return false;
        }

        bool CheckNullPhatHanhLai()
        {
            if (ckbSMS_Moi.Checked && string.IsNullOrEmpty(txtDTDD_SMS_Moi.Text))
            {
                MessageBox.Show("Vui Lòng nhập số điện thoại nhận SMS!", "Thông báo", MessageBoxButtons.OK);
                txtDTDD_SMS_Moi.Focus();
                return true;
            }

            if (ckbInternet_Moi.Checked && string.IsNullOrEmpty(txtHMGD_Moi.Text))
            {
                MessageBox.Show("Vui Lòng nhập hạn mức giao dịch trên Internet!", "Thông báo", MessageBoxButtons.OK);
                txtHMGD_Moi.Focus();
                return true;
            }

            if (clbQT_Lai.CheckedItems.Count == 0 && clbND_Lai.CheckedItems.Count == 0)
            {
                MessageBox.Show("Vui Lòng chọn ít nhất 1 loại thẻ!", "Thông báo", MessageBoxButtons.OK);
                return true;
            }
            return false;
        }

        bool CheckNullHopDong()
        {
            if (string.IsNullOrEmpty(txtHoTen_BenB.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!");
                txtHoTen_BenB.Focus();
                return true;
            }

            if (string.IsNullOrEmpty(txtCMT_BenB.Text))
            {
                MessageBox.Show("Vui lòng nhập số CMND!");
                txtCMT_BenB.Focus();
                return true;
            }

            if (string.IsNullOrEmpty(txtNgayCap_BenB.Text))
            {
                MessageBox.Show("Vui lòng nhập ngày cấp CMND!");
                txtNgayCap_BenB.Focus();
                return true;
            }

            if (string.IsNullOrEmpty(txtNoiCap_BenB.Text))
            {
                MessageBox.Show("Vui lòng nhập nơi cấp CMND!");
                txtNoiCap_BenB.Focus();
                return true;
            }
            return false;
        }

        private void cbSoTK_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        bool LuuPhatHanhMoiTheNoiDia()
        {
            string sotk = cbSoTK.SelectedItem.ToString();
            string loaithe = StringConverter(clbND_Moi.CheckedItems[0].ToString());
            string hangthe = StringConverter(clbHangThe_Moi.CheckedItems[0].ToString());
            string htPhatHanh = StringConverter(clbHTPhatHanh_Moi.CheckedItems[0].ToString());
            string htNhanThe = StringConverter(clbHTNhanThe_Moi.CheckedItems[0].ToString());
            string dtdd = txtDTDD_SMS_Moi.Text;
            int hmgd = 0;
            int baoHiem = 0;
            if (!string.IsNullOrEmpty(txtHMGD_Moi.Text)) hmgd = int.Parse(txtHMGD_Moi.Text);
            if (ckbBaoHiem_Moi.Checked) baoHiem = 1;

            try //Luu thong tin the noi dia
            {
                PhatHanhTheGhiNoDAL.DangKyThe(sotk, loaithe, hangthe, htPhatHanh, htNhanThe, dtdd, hmgd, baoHiem,Thong_tin_dang_nhap.ten_dang_nhap, Thong_tin_dang_nhap.ma_pb);
                return true;
            }
            catch
            {
                MessageBox.Show("Số tài khoản " + sotk + " đã đăng ký loại thẻ " + loaithe + "!", "Thông báo", MessageBoxButtons.OK);
                return false;
            }

        }

        bool LuuPhatHanhMoiTheQuocTe()
        {
            string sotk = cbSoTK.SelectedItem.ToString();
            string loaithe = StringConverter(clbQT_Moi.CheckedItems[0].ToString());
            string hangthe = StringConverter(clbHangThe_Moi.CheckedItems[0].ToString());
            string htPhatHanh = StringConverter(clbHTPhatHanh_Moi.CheckedItems[0].ToString());
            string htNhanThe = StringConverter(clbHTNhanThe_Moi.CheckedItems[0].ToString());
            string dtdd = txtDTDD_SMS_Moi.Text;
            int hmgd = 0;
            int baoHiem = 0;
            if (!string.IsNullOrEmpty(txtHMGD_Moi.Text)) hmgd = int.Parse(txtHMGD_Moi.Text);
            if (ckbBaoHiem_Moi.Checked) baoHiem = 1;
            try //Luu thong tin the quoc te
            {
                PhatHanhTheGhiNoDAL.DangKyThe(sotk, loaithe, hangthe, htPhatHanh, htNhanThe, dtdd, hmgd, baoHiem,Thong_tin_dang_nhap.ten_dang_nhap, Thong_tin_dang_nhap.ma_pb);
                return true;
            }
            catch
            {
                MessageBox.Show("Số tài khoản " + sotk + " đã đăng ký loại thẻ " + loaithe + "!", "Thông báo", MessageBoxButtons.OK);
                return false;
            }

        }

        bool LuuPhatHanhLaiTheNoiDia()
        {
            string sotk = cbSoTK.SelectedItem.ToString();
            string loaithe = StringConverter(clbND_Lai.CheckedItems[0].ToString());
            string hangthe = StringConverter(clbHangThe_Lai.CheckedItems[0].ToString());
            string htPhatHanh = StringConverter(clbHTPhatHanh_Lai.CheckedItems[0].ToString());
            string htNhanThe = StringConverter(clbHTNhanThe_Moi.CheckedItems[0].ToString());
            string dtdd = txtDTDD_SMS_Lai.Text;
            int hmgd = 0;
            int baoHiem = 0;
            if (!string.IsNullOrEmpty(txtHMGD_Lai.Text)) hmgd = int.Parse(txtHMGD_Lai.Text);
            if (ckbBaoHiem_Lai.Checked) baoHiem = 1;

            try //Luu thong tin the noi dia
            {
                PhatHanhTheGhiNoDAL.DangKyThe(sotk, loaithe, hangthe, htPhatHanh, htNhanThe, dtdd, hmgd, baoHiem, Thong_tin_dang_nhap.ten_dang_nhap, Thong_tin_dang_nhap.ma_pb);
                return true;
            }
            catch
            {
                MessageBox.Show("Số tài khoản " + sotk + " đã đăng ký loại thẻ " + loaithe + "!", "Thông báo", MessageBoxButtons.OK);
                return false;
            }

        }

        bool LuuPhatHanhLaiTheQuocTe()
        {
            string sotk = cbSoTK.SelectedItem.ToString();
            string loaithe = StringConverter(clbQT_Lai.CheckedItems[0].ToString());
            string hangthe = StringConverter(clbHangThe_Lai.CheckedItems[0].ToString());
            string htPhatHanh = StringConverter(clbHTPhatHanh_Lai.CheckedItems[0].ToString());
            string htNhanThe = StringConverter(clbHTNhanThe_Moi.CheckedItems[0].ToString());
            string dtdd = txtDTDD_SMS_Lai.Text;
            int hmgd = 0;
            int baoHiem = 0;
            if (!string.IsNullOrEmpty(txtHMGD_Lai.Text)) hmgd = int.Parse(txtHMGD_Lai.Text);
            if (ckbBaoHiem_Lai.Checked) baoHiem = 1;
            try //Luu thong tin the quoc te
            {
                PhatHanhTheGhiNoDAL.DangKyThe(sotk, loaithe, hangthe, htPhatHanh, htNhanThe, dtdd, hmgd, baoHiem, Thong_tin_dang_nhap.ten_dang_nhap, Thong_tin_dang_nhap.ma_pb);
                return true;
            }
            catch
            {
                MessageBox.Show("Số tài khoản " + sotk + " đã đăng ký loại thẻ " + loaithe + "!", "Thông báo", MessageBoxButtons.OK);
                return false;
            }

        }



        string StringConverter(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            switch (s)
            {
                case "Ghi nợ NĐ":
                    return "GNND";
                case "Lập nghiệp":
                    return "LN";
                case "Sinh viên":
                    return "SV";
                case "Liên kết thương hiệu":
                    return "LKTH";
                case "Ghi nợ QT":
                    return "GNQT";
                case "Tín dụng QT":
                    return "TDQT";
                case "Visa":
                    return "VISA";
                case "MasterCard":
                    return "MC";
                case "Phát hành thường":
                    return "PHT";
                case "Phát hành nhanh":
                    return "PHN";
                case "Tại ngân hàng":
                    return "TNH";
                case "Tại nhà riêng":
                    return "TNR";
                case "Chuẩn":
                    return "C";
                case "Vàng":
                    return "V";
                case "Bạch kim":
                    return "BK";
                default:
                    return s;
            }
        }

        private void btnLayTTKH_Click(object sender, EventArgs e)
        {
            if (openFileTTKH.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileName = openFileTTKH.FileName;
                DataTable dt = CommonMethods.read_excel(fileName);
                if (dt.Rows.Count == 0 || dt == null)
                {
                    MessageBox.Show("File không có dữ liệu");
                    return;
                }
                if (dt.Rows[0][7].ToString() == "Cá nhân")
                {
                    layTTKH(dt);
                }
                txtTimKiem.Focus();
            }
        }

        private void layTTKH(System.Data.DataTable dt_temp)
        {
            System.Data.DataTable dt_temp2 = new System.Data.DataTable();
            dt_temp2.Columns.AddRange
            (
                new DataColumn[39] 
                { 
                    new DataColumn("MAKH", typeof(string)),
                    new DataColumn("HOTEN", typeof(string)),
                    new DataColumn("DIACHI1", typeof(string)),
                    new DataColumn("DIACHI2", typeof(string)),
                    new DataColumn("DIENTHOAI1", typeof(string)),
                    new DataColumn("DIENTHOAI2", typeof(string)),
                    new DataColumn("EMAIL", typeof(string)),
                    new DataColumn("CMND", typeof(string)),
                    new DataColumn("NGAYCAP", typeof(string)),
                    new DataColumn("NOICAP", typeof(string)),
                    new DataColumn("NGAYSINH", typeof(string)),
                    new DataColumn("GIOITINH", typeof(bool)),
                    new DataColumn("LINHVUC", typeof(string)),
                    new DataColumn("WEBSITE", typeof(string)),
                    new DataColumn("GPDK", typeof(string)),
                    new DataColumn("QDTL", typeof(string)),
                    new DataColumn("MST", typeof(string)),
                    new DataColumn("LOAIKH", typeof(int)),
                    new DataColumn("THUNHAP", typeof(decimal)),
                    new DataColumn("SOTHICH", typeof(string)),
                    new DataColumn("MANV", typeof(string)),
                    new DataColumn("NHGIAODICH", typeof(string)),
                    new DataColumn("GHICHU", typeof(string)),
                    new DataColumn("MACN", typeof(string)),
                    new DataColumn("TINHTRANG", typeof(bool)),
                    new DataColumn("CTLOAIKH", typeof(string)),
                    new DataColumn("TINH", typeof(string)),
                    new DataColumn("HUYEN", typeof(string)),
                    new DataColumn("XA", typeof(string)),
                    new DataColumn("LOAIKH_IPCAS", typeof(string)),
                    new DataColumn("NGAYKETHON", typeof(string)),
                    new DataColumn("NGAYTHANHLAP", typeof(string)),
                    new DataColumn("NGAYTAO", typeof(string)),
                    new DataColumn("DOITUONGKH", typeof(string)),
                    new DataColumn("DOITUONGDN", typeof(string)),
                    new DataColumn("VONDAUTU", typeof(decimal)),
                    new DataColumn("SOLAODONG", typeof(decimal)),
                    new DataColumn("DSXNK", typeof(decimal)),
                    new DataColumn("NGAYTLNGANH", typeof(string))
                }
            );
            DataRow dr;

            //Định dạng ngày tháng theo dạng en-US cho hàm convert.todatetie
            IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);

            for (int i = 0; i < dt_temp.Rows.Count; i++)
            {
                try
                {
                    if (dt_temp.Rows[i][0].ToString() != null && dt_temp.Rows[i][0].ToString().Substring(0, 4) == Thong_tin_dang_nhap.ma_cn)
                    {

                        String ngaycap, ngaysinh, didong;
                        String hoten = dt_temp.Rows[i][4].ToString().Replace(",", "-").Replace("'", "-");
                        String diachi1 = dt_temp.Rows[i][22].ToString().Replace(",", "-").Replace("'", "-");
                        String diachi2 = dt_temp.Rows[i][23].ToString().Replace(",", "-").Replace("'", "-");
                        didong = dt_temp.Rows[i][9].ToString();
                        ngaysinh = dt_temp.Rows[i][12].ToString().Trim();
                        if (ngaysinh != "")
                        {
                            //định dạng mm/dd/yyy
                            ngaysinh = ngaysinh.Substring(4, 2) + "/" + ngaysinh.Substring(6, 2) + "/" + ngaysinh.Substring(0, 4);
                        }
                        else
                        {
                            //định dạng mm/dd/yyy
                            ngaysinh = "01/01/1900";
                        }
                        String gt = dt_temp.Rows[i][10].ToString();
                        Int16 gioitinh;
                        if (gt == "Nam" || gt == "Male" || gt == "nam")
                        {
                            gioitinh = 1;
                        }
                        else
                        {
                            gioitinh = 0;
                        }
                        Int16 loaikh = 1;
                        String ngaytao = DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd") + "/" + DateTime.Now.ToString("yyyy");

                        dr = dt_temp2.NewRow();
                        dr["MAKH"] = dt_temp.Rows[i][0].ToString();
                        dr["HOTEN"] = hoten;
                        dr["DIACHI1"] = diachi1;
                        dr["DIACHI2"] = diachi2;
                        dr["DIENTHOAI1"] = didong;
                        dr["DIENTHOAI2"] = "";
                        dr["EMAIL"] = "";
                        if (dt_temp.Rows[i][14].ToString() != "")
                        {
                            //Khách hàng sử dụng chứng minh nhân dân
                            dr["CMND"] = dt_temp.Rows[i][14].ToString();
                            ngaycap = dt_temp.Rows[i][34].ToString().Trim();
                            if (ngaycap != "")
                            {
                                //định dạng mm/dd/yyy
                                ngaycap = ngaycap.Substring(4, 2) + "/" + ngaycap.Substring(6, 2) + "/" + ngaycap.Substring(0, 4);
                            }
                            else
                            {
                                //định dạng mm/dd/yyy
                                ngaycap = "01/01/1900";
                            }
                            dr["NGAYCAP"] = ngaycap;
                            dr["NOICAP"] = dt_temp.Rows[i][33].ToString();
                        }
                        else if (dt_temp.Rows[i][15].ToString() != "")
                        {
                            //Khách hàng sử dụng hộ chiếu
                            dr["CMND"] = dt_temp.Rows[i][15].ToString();
                            ngaycap = dt_temp.Rows[i][36].ToString().Trim();
                            if (ngaycap != "")
                            {
                                //định dạng mm/dd/yyy
                                ngaycap = ngaycap.Substring(4, 2) + "/" + ngaycap.Substring(6, 2) + "/" + ngaycap.Substring(0, 4);
                            }
                            else
                            {
                                //định dạng mm/dd/yyy
                                ngaycap = "01/01/1900";
                            }
                            dr["NGAYCAP"] = ngaycap;
                            dr["NOICAP"] = dt_temp.Rows[i][35].ToString();
                        }
                        else
                        {
                            dr["CMND"] = "";
                            dr["NGAYCAP"] = "01/01/1900";
                            dr["NOICAP"] = "";
                        }
                        //dr["CMND"] = dt_temp.Rows[i][14].ToString();
                        //dr["NGAYCAP"] = ngaycap;
                        //dr["NOICAP"] = dt_temp.Rows[i][33].ToString();
                        dr["NGAYSINH"] = ngaysinh;
                        dr["GIOITINH"] = Convert.ToBoolean(gioitinh);
                        dr["LINHVUC"] = "";
                        dr["WEBSITE"] = "";
                        dr["GPDK"] = dt_temp.Rows[i][31].ToString();
                        dr["QDTL"] = dt_temp.Rows[i][30].ToString();
                        dr["MST"] = dt_temp.Rows[i][45].ToString();
                        dr["LOAIKH"] = loaikh;
                        dr["THUNHAP"] = 0;
                        dr["SOTHICH"] = "";
                        dr["MANV"] = "";
                        dr["NHGIAODICH"] = "";
                        dr["GHICHU"] = "";
                        dr["MACN"] = dt_temp.Rows[i][0].ToString().Substring(0, 4);
                        dr["TINHTRANG"] = true;
                        dr["CTLOAIKH"] = dt_temp.Rows[i][8].ToString();
                        dr["TINH"] = dt_temp.Rows[i][46].ToString();
                        dr["HUYEN"] = dt_temp.Rows[i][47].ToString();
                        dr["XA"] = dt_temp.Rows[i][48].ToString();
                        dr["LOAIKH_IPCAS"] = dt_temp.Rows[i][7].ToString(); // "Cá nhân"
                        dr["NGAYKETHON"] = "01/01/1900";
                        dr["NGAYTHANHLAP"] = "01/01/1900";
                        dr["NGAYTAO"] = ngaytao;
                        dr["DOITUONGKH"] = "14";
                        dr["DOITUONGDN"] = "";
                        dr["VONDAUTU"] = 0;
                        dr["SOLAODONG"] = 0;
                        dr["DSXNK"] = 0;
                        dr["NGAYTLNGANH"] = "01/01/1900";
                        dt_temp2.Rows.Add(dr);
                    }
                }
                catch
                { }
            }
            //Xóa các dòng có cùng mã khách hàng
            dt_temp2 = CommonMethods.RemoveDuplicateRows(dt_temp2, "MAKH");

            //Nhập thông tin vào bảng KHACHHANG
            if (PhatHanhTheGhiNoDAL.UPDATE_KHACHHANG(dt_temp2, Thong_tin_dang_nhap.ten_dang_nhap))
            {
                MessageBox.Show("Hoàn thành nhập thông tin khách hàng.");
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi nhập thông tin khách hàng.");
            }
        }

        private void txtHMGD_Moi_TextChanged(object sender, EventArgs e)
        {
            TachSo(txtHMGD_Moi);
        }

        private void txtHMGD_Lai_TextChanged(object sender, EventArgs e)
        {
            TachSo(txtHMGD_Lai);
        }

        public void TachSo(TextBox luong)
        {
            string txt, txt1;
            txt1 = luong.Text.Replace(",", "");
            txt = "";
            int n = txt1.Length;
            int dem = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                if (dem == 2 && i != 0)
                {
                    txt = "," + txt1.Substring(i, 1) + txt;
                    dem = 0;
                }
                else
                {
                    txt = txt1.Substring(i, 1) + txt;
                    dem += 1;
                }
            }
            luong.Text = txt;
            luong.SelectionStart = luong.Text.Length;
        }
        string XoaDauPhay(string s)
        {
            return s.Replace(",", "");
        }
    }
}
