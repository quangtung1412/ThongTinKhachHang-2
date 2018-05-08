namespace AGRIBANKHD.GUI
{
    partial class frmDoi_mat_khau
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoi_mat_khau));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnDoi_mat_khau = new System.Windows.Forms.Button();
            this.txtXac_nhan_mat_khau_moi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMat_khau_moi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTen_dang_nhap = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnDoi_mat_khau);
            this.groupBox1.Controls.Add(this.txtXac_nhan_mat_khau_moi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMat_khau_moi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTen_dang_nhap);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 190);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(202, 153);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(144, 31);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDoi_mat_khau
            // 
            this.btnDoi_mat_khau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoi_mat_khau.Location = new System.Drawing.Point(33, 153);
            this.btnDoi_mat_khau.Name = "btnDoi_mat_khau";
            this.btnDoi_mat_khau.Size = new System.Drawing.Size(144, 31);
            this.btnDoi_mat_khau.TabIndex = 6;
            this.btnDoi_mat_khau.Text = "Đổi mật khẩu";
            this.btnDoi_mat_khau.UseVisualStyleBackColor = true;
            this.btnDoi_mat_khau.Click += new System.EventHandler(this.btnDoi_mat_khau_Click);
            // 
            // txtXac_nhan_mat_khau_moi
            // 
            this.txtXac_nhan_mat_khau_moi.Location = new System.Drawing.Point(178, 111);
            this.txtXac_nhan_mat_khau_moi.Name = "txtXac_nhan_mat_khau_moi";
            this.txtXac_nhan_mat_khau_moi.PasswordChar = '*';
            this.txtXac_nhan_mat_khau_moi.Size = new System.Drawing.Size(184, 23);
            this.txtXac_nhan_mat_khau_moi.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Xác nhận mật khẩu mới";
            // 
            // txtMat_khau_moi
            // 
            this.txtMat_khau_moi.Location = new System.Drawing.Point(178, 69);
            this.txtMat_khau_moi.Name = "txtMat_khau_moi";
            this.txtMat_khau_moi.PasswordChar = '*';
            this.txtMat_khau_moi.Size = new System.Drawing.Size(184, 23);
            this.txtMat_khau_moi.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu mới";
            // 
            // txtTen_dang_nhap
            // 
            this.txtTen_dang_nhap.Location = new System.Drawing.Point(178, 27);
            this.txtTen_dang_nhap.Name = "txtTen_dang_nhap";
            this.txtTen_dang_nhap.ReadOnly = true;
            this.txtTen_dang_nhap.Size = new System.Drawing.Size(184, 23);
            this.txtTen_dang_nhap.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập";
            // 
            // frmDoi_mat_khau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 213);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDoi_mat_khau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTen_dang_nhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtXac_nhan_mat_khau_moi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMat_khau_moi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDoi_mat_khau;
        private System.Windows.Forms.Button btnThoat;
    }
}