namespace App_Arisan
{
    partial class Frm_AppArisan
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
            this.components = new System.ComponentModel.Container();
            this.tLogin = new System.Windows.Forms.Timer(this.components);
            this.tJam = new System.Windows.Forms.Timer(this.components);
            this.tTitik2 = new System.Windows.Forms.Timer(this.components);
            this.pnlUtama = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnlShowMenu = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMenit = new System.Windows.Forms.Label();
            this.lblTitik2 = new System.Windows.Forms.Label();
            this.lblJam = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnDaftarPemenang = new System.Windows.Forms.Button();
            this.btnPembayaran = new System.Windows.Forms.Button();
            this.btnUndiArisan = new System.Windows.Forms.Button();
            this.pnlBtnMenu = new System.Windows.Forms.Panel();
            this.btnBuatKelompok = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnEditData = new System.Windows.Forms.Button();
            this.btnDaftarAkun = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblKodeAkun = new System.Windows.Forms.Label();
            this.lblNamaLengkap = new System.Windows.Forms.Label();
            this.pbFotoAkun = new System.Windows.Forms.PictureBox();
            this.pnlUtama.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlShowMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoAkun)).BeginInit();
            this.SuspendLayout();
            // 
            // tLogin
            // 
            this.tLogin.Tick += new System.EventHandler(this.tLogin_Tick);
            // 
            // tJam
            // 
            this.tJam.Interval = 1000;
            this.tJam.Tick += new System.EventHandler(this.tJam_Tick);
            // 
            // tTitik2
            // 
            this.tTitik2.Interval = 500;
            this.tTitik2.Tick += new System.EventHandler(this.tTitik2_Tick);
            // 
            // pnlUtama
            // 
            this.pnlUtama.BackColor = System.Drawing.Color.DarkCyan;
            this.pnlUtama.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUtama.Controls.Add(this.panel4);
            this.pnlUtama.Controls.Add(this.panel2);
            this.pnlUtama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUtama.Location = new System.Drawing.Point(0, 0);
            this.pnlUtama.Name = "pnlUtama";
            this.pnlUtama.Size = new System.Drawing.Size(1569, 831);
            this.pnlUtama.TabIndex = 14;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Peru;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.pnlShowMenu);
            this.panel4.Location = new System.Drawing.Point(6, 124);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1555, 699);
            this.panel4.TabIndex = 5;
            // 
            // pnlShowMenu
            // 
            this.pnlShowMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlShowMenu.BackColor = System.Drawing.Color.Peru;
            this.pnlShowMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlShowMenu.Controls.Add(this.label2);
            this.pnlShowMenu.Location = new System.Drawing.Point(16, 15);
            this.pnlShowMenu.Name = "pnlShowMenu";
            this.pnlShowMenu.Size = new System.Drawing.Size(1521, 668);
            this.pnlShowMenu.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tempus Sans ITC", 72F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(603, 157);
            this.label2.TabIndex = 12;
            this.label2.Text = "Dashboard";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.PeachPuff;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblMenit);
            this.panel2.Controls.Add(this.lblTitik2);
            this.panel2.Controls.Add(this.lblJam);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.pnlMenu);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(6, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1555, 113);
            this.panel2.TabIndex = 4;
            // 
            // lblMenit
            // 
            this.lblMenit.AutoSize = true;
            this.lblMenit.Font = new System.Drawing.Font("Stencil", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenit.Location = new System.Drawing.Point(372, 7);
            this.lblMenit.Name = "lblMenit";
            this.lblMenit.Size = new System.Drawing.Size(55, 39);
            this.lblMenit.TabIndex = 15;
            this.lblMenit.Text = "00";
            this.lblMenit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitik2
            // 
            this.lblTitik2.AutoSize = true;
            this.lblTitik2.Font = new System.Drawing.Font("Stencil", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitik2.Location = new System.Drawing.Point(347, 6);
            this.lblTitik2.Name = "lblTitik2";
            this.lblTitik2.Size = new System.Drawing.Size(28, 39);
            this.lblTitik2.TabIndex = 14;
            this.lblTitik2.Text = ":";
            this.lblTitik2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblJam
            // 
            this.lblJam.AutoSize = true;
            this.lblJam.Font = new System.Drawing.Font("Stencil", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJam.Location = new System.Drawing.Point(292, 7);
            this.lblJam.Name = "lblJam";
            this.lblJam.Size = new System.Drawing.Size(55, 39);
            this.lblJam.TabIndex = 13;
            this.lblJam.Text = "00";
            this.lblJam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Peru;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Location = new System.Drawing.Point(-1, 7);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(287, 97);
            this.panel5.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tempus Sans ITC", 27F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 58);
            this.label1.TabIndex = 11;
            this.label1.Text = "App Arisan";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnDaftarPemenang);
            this.pnlMenu.Controls.Add(this.btnPembayaran);
            this.pnlMenu.Controls.Add(this.btnUndiArisan);
            this.pnlMenu.Controls.Add(this.pnlBtnMenu);
            this.pnlMenu.Controls.Add(this.btnBuatKelompok);
            this.pnlMenu.Location = new System.Drawing.Point(291, 56);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(814, 55);
            this.pnlMenu.TabIndex = 12;
            // 
            // btnDaftarPemenang
            // 
            this.btnDaftarPemenang.BackColor = System.Drawing.Color.Peru;
            this.btnDaftarPemenang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDaftarPemenang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDaftarPemenang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDaftarPemenang.Location = new System.Drawing.Point(539, 9);
            this.btnDaftarPemenang.Name = "btnDaftarPemenang";
            this.btnDaftarPemenang.Size = new System.Drawing.Size(201, 40);
            this.btnDaftarPemenang.TabIndex = 11;
            this.btnDaftarPemenang.Text = "Daftar Pemenang";
            this.btnDaftarPemenang.UseVisualStyleBackColor = false;
            this.btnDaftarPemenang.Click += new System.EventHandler(this.btnDaftarPemenang_Click);
            // 
            // btnPembayaran
            // 
            this.btnPembayaran.BackColor = System.Drawing.Color.Peru;
            this.btnPembayaran.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPembayaran.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPembayaran.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPembayaran.Location = new System.Drawing.Point(183, 9);
            this.btnPembayaran.Name = "btnPembayaran";
            this.btnPembayaran.Size = new System.Drawing.Size(176, 40);
            this.btnPembayaran.TabIndex = 10;
            this.btnPembayaran.Text = "Pembayaran";
            this.btnPembayaran.UseVisualStyleBackColor = false;
            this.btnPembayaran.Click += new System.EventHandler(this.btnPembayaran_Click);
            // 
            // btnUndiArisan
            // 
            this.btnUndiArisan.BackColor = System.Drawing.Color.Peru;
            this.btnUndiArisan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUndiArisan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndiArisan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndiArisan.Location = new System.Drawing.Point(4, 9);
            this.btnUndiArisan.Name = "btnUndiArisan";
            this.btnUndiArisan.Size = new System.Drawing.Size(176, 40);
            this.btnUndiArisan.TabIndex = 8;
            this.btnUndiArisan.Text = "Undi Arisan";
            this.btnUndiArisan.UseVisualStyleBackColor = false;
            this.btnUndiArisan.Click += new System.EventHandler(this.btnUndiArisan_Click);
            // 
            // pnlBtnMenu
            // 
            this.pnlBtnMenu.BackColor = System.Drawing.Color.Peru;
            this.pnlBtnMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBtnMenu.Location = new System.Drawing.Point(4, 3);
            this.pnlBtnMenu.Name = "pnlBtnMenu";
            this.pnlBtnMenu.Size = new System.Drawing.Size(176, 6);
            this.pnlBtnMenu.TabIndex = 7;
            // 
            // btnBuatKelompok
            // 
            this.btnBuatKelompok.BackColor = System.Drawing.Color.Peru;
            this.btnBuatKelompok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuatKelompok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuatKelompok.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuatKelompok.Location = new System.Drawing.Point(361, 9);
            this.btnBuatKelompok.Name = "btnBuatKelompok";
            this.btnBuatKelompok.Size = new System.Drawing.Size(176, 40);
            this.btnBuatKelompok.TabIndex = 9;
            this.btnBuatKelompok.Text = "Buat Kelompok";
            this.btnBuatKelompok.UseVisualStyleBackColor = false;
            this.btnBuatKelompok.Click += new System.EventHandler(this.btnBuatKelompok_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Peru;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnEditData);
            this.panel3.Controls.Add(this.btnDaftarAkun);
            this.panel3.Controls.Add(this.btnLogin);
            this.panel3.Controls.Add(this.lblKodeAkun);
            this.panel3.Controls.Add(this.lblNamaLengkap);
            this.panel3.Controls.Add(this.pbFotoAkun);
            this.panel3.Location = new System.Drawing.Point(1111, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(442, 97);
            this.panel3.TabIndex = 5;
            // 
            // btnEditData
            // 
            this.btnEditData.BackColor = System.Drawing.Color.Transparent;
            this.btnEditData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditData.Location = new System.Drawing.Point(210, 57);
            this.btnEditData.Name = "btnEditData";
            this.btnEditData.Size = new System.Drawing.Size(115, 33);
            this.btnEditData.TabIndex = 11;
            this.btnEditData.Text = "Edit Data";
            this.btnEditData.UseVisualStyleBackColor = false;
            this.btnEditData.Click += new System.EventHandler(this.btnEditData_Click);
            // 
            // btnDaftarAkun
            // 
            this.btnDaftarAkun.BackColor = System.Drawing.Color.Transparent;
            this.btnDaftarAkun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDaftarAkun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDaftarAkun.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDaftarAkun.Location = new System.Drawing.Point(331, 57);
            this.btnDaftarAkun.Name = "btnDaftarAkun";
            this.btnDaftarAkun.Size = new System.Drawing.Size(97, 33);
            this.btnDaftarAkun.TabIndex = 10;
            this.btnDaftarAkun.Text = "Daftar";
            this.btnDaftarAkun.UseVisualStyleBackColor = false;
            this.btnDaftarAkun.Visible = false;
            this.btnDaftarAkun.Click += new System.EventHandler(this.btnDaftarAkun_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(107, 57);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(97, 33);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblKodeAkun
            // 
            this.lblKodeAkun.AutoSize = true;
            this.lblKodeAkun.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKodeAkun.Location = new System.Drawing.Point(103, 4);
            this.lblKodeAkun.Name = "lblKodeAkun";
            this.lblKodeAkun.Size = new System.Drawing.Size(44, 20);
            this.lblKodeAkun.TabIndex = 2;
            this.lblKodeAkun.Text = "kode";
            // 
            // lblNamaLengkap
            // 
            this.lblNamaLengkap.AutoSize = true;
            this.lblNamaLengkap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamaLengkap.Location = new System.Drawing.Point(103, 29);
            this.lblNamaLengkap.Name = "lblNamaLengkap";
            this.lblNamaLengkap.Size = new System.Drawing.Size(50, 20);
            this.lblNamaLengkap.TabIndex = 1;
            this.lblNamaLengkap.Text = "nama";
            // 
            // pbFotoAkun
            // 
            this.pbFotoAkun.BackColor = System.Drawing.Color.SeaShell;
            this.pbFotoAkun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFotoAkun.Location = new System.Drawing.Point(1, 1);
            this.pbFotoAkun.Name = "pbFotoAkun";
            this.pbFotoAkun.Size = new System.Drawing.Size(96, 92);
            this.pbFotoAkun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFotoAkun.TabIndex = 0;
            this.pbFotoAkun.TabStop = false;
            // 
            // Frm_AppArisan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(1569, 831);
            this.Controls.Add(this.pnlUtama);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Frm_AppArisan";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "App_Arisan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_AppArisan_FormClosed);
            this.Load += new System.EventHandler(this.Frm_AppArisan_Load);
            this.pnlUtama.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnlShowMenu.ResumeLayout(false);
            this.pnlShowMenu.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoAkun)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tLogin;
        private System.Windows.Forms.Timer tJam;
        private System.Windows.Forms.Timer tTitik2;
        private System.Windows.Forms.Panel pnlUtama;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pnlShowMenu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMenit;
        private System.Windows.Forms.Label lblTitik2;
        private System.Windows.Forms.Label lblJam;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnDaftarPemenang;
        private System.Windows.Forms.Button btnPembayaran;
        private System.Windows.Forms.Button btnUndiArisan;
        private System.Windows.Forms.Panel pnlBtnMenu;
        private System.Windows.Forms.Button btnBuatKelompok;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnEditData;
        private System.Windows.Forms.Button btnDaftarAkun;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblKodeAkun;
        private System.Windows.Forms.Label lblNamaLengkap;
        private System.Windows.Forms.PictureBox pbFotoAkun;
    }
}

