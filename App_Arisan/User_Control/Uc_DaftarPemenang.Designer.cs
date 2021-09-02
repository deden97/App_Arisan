
namespace App_Arisan.User_Control
{
    partial class Uc_DaftarPemenang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label17 = new System.Windows.Forms.Label();
            this.btnClearForm = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lvKel = new System.Windows.Forms.ListView();
            this.clmNomor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmKodeKel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmNmKel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTotAnggota = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmStatusKel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTgl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBuatLaporan = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblAnggotaKelompok = new System.Windows.Forms.Label();
            this.dgvListPemenang = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.txtJmlPemenang = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.clmUndianKe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTglUndian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmKodeAnggota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNamaAnggota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNoTelp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFoto = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListPemenang)).BeginInit();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tempus Sans ITC", 22.2F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(16, 17);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(433, 50);
            this.label17.TabIndex = 48;
            this.label17.Text = "Daftar Pemenang Arisan";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClearForm
            // 
            this.btnClearForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearForm.BackColor = System.Drawing.Color.PeachPuff;
            this.btnClearForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearForm.Location = new System.Drawing.Point(1546, 20);
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.Size = new System.Drawing.Size(251, 45);
            this.btnClearForm.TabIndex = 58;
            this.btnClearForm.Text = "Batal / Bersihkan Form";
            this.btnClearForm.UseVisualStyleBackColor = false;
            this.btnClearForm.Click += new System.EventHandler(this.btnClearForm_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnClearSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.lvKel);
            this.panel1.Controls.Add(this.lblTgl);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnBuatLaporan);
            this.panel1.Location = new System.Drawing.Point(17, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 651);
            this.panel1.TabIndex = 59;
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.BackColor = System.Drawing.Color.OrangeRed;
            this.btnClearSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearSearch.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClearSearch.Location = new System.Drawing.Point(524, 39);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(30, 30);
            this.btnClearSearch.TabIndex = 72;
            this.btnClearSearch.Text = "X";
            this.btnClearSearch.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(181, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 25);
            this.label1.TabIndex = 71;
            this.label1.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 25);
            this.label2.TabIndex = 70;
            this.label2.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(210, 38);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(312, 30);
            this.txtSearch.TabIndex = 69;
            // 
            // lvKel
            // 
            this.lvKel.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvKel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvKel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvKel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmNomor,
            this.clmKodeKel,
            this.clmNmKel,
            this.clmTotAnggota,
            this.clmStatusKel});
            this.lvKel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvKel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvKel.FullRowSelect = true;
            this.lvKel.GridLines = true;
            this.lvKel.HideSelection = false;
            this.lvKel.Location = new System.Drawing.Point(14, 74);
            this.lvKel.Name = "lvKel";
            this.lvKel.Size = new System.Drawing.Size(554, 502);
            this.lvKel.TabIndex = 68;
            this.lvKel.UseCompatibleStateImageBehavior = false;
            this.lvKel.View = System.Windows.Forms.View.Details;
            this.lvKel.Click += new System.EventHandler(this.lvKel_Click);
            // 
            // clmNomor
            // 
            this.clmNomor.Text = "No.";
            this.clmNomor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmNomor.Width = 43;
            // 
            // clmKodeKel
            // 
            this.clmKodeKel.Text = "Kode Kelompok";
            this.clmKodeKel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmKodeKel.Width = 116;
            // 
            // clmNmKel
            // 
            this.clmNmKel.Text = "Nama Kelompok";
            this.clmNmKel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmNmKel.Width = 151;
            // 
            // clmTotAnggota
            // 
            this.clmTotAnggota.Text = "Total Anggota";
            this.clmTotAnggota.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmTotAnggota.Width = 123;
            // 
            // clmStatusKel
            // 
            this.clmStatusKel.Text = "Status Kelompok";
            this.clmStatusKel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmStatusKel.Width = 140;
            // 
            // lblTgl
            // 
            this.lblTgl.AutoSize = true;
            this.lblTgl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTgl.Location = new System.Drawing.Point(205, 6);
            this.lblTgl.Name = "lblTgl";
            this.lblTgl.Size = new System.Drawing.Size(90, 25);
            this.lblTgl.TabIndex = 67;
            this.lblTgl.Text = "hh-bb-tttt";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(181, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 25);
            this.label7.TabIndex = 66;
            this.label7.Text = ":";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 25);
            this.label8.TabIndex = 65;
            this.label8.Text = "Update Per";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(6, 582);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(571, 5);
            this.panel2.TabIndex = 45;
            // 
            // btnBuatLaporan
            // 
            this.btnBuatLaporan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBuatLaporan.BackColor = System.Drawing.Color.PeachPuff;
            this.btnBuatLaporan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuatLaporan.Enabled = false;
            this.btnBuatLaporan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuatLaporan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuatLaporan.Location = new System.Drawing.Point(14, 594);
            this.btnBuatLaporan.Name = "btnBuatLaporan";
            this.btnBuatLaporan.Size = new System.Drawing.Size(193, 45);
            this.btnBuatLaporan.TabIndex = 55;
            this.btnBuatLaporan.Text = "Buat Laporan";
            this.btnBuatLaporan.UseVisualStyleBackColor = false;
            this.btnBuatLaporan.Click += new System.EventHandler(this.btnBuatLaporan_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblAnggotaKelompok);
            this.panel3.Controls.Add(this.dgvListPemenang);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.txtJmlPemenang);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(618, 92);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1179, 651);
            this.panel3.TabIndex = 60;
            // 
            // lblAnggotaKelompok
            // 
            this.lblAnggotaKelompok.AutoSize = true;
            this.lblAnggotaKelompok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnggotaKelompok.Location = new System.Drawing.Point(3, 6);
            this.lblAnggotaKelompok.Name = "lblAnggotaKelompok";
            this.lblAnggotaKelompok.Size = new System.Drawing.Size(190, 25);
            this.lblAnggotaKelompok.TabIndex = 47;
            this.lblAnggotaKelompok.Text = "Anggota Kelompok :";
            // 
            // dgvListPemenang
            // 
            this.dgvListPemenang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListPemenang.BackgroundColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListPemenang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListPemenang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListPemenang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmUndianKe,
            this.clmTglUndian,
            this.clmKodeAnggota,
            this.clmNamaAnggota,
            this.clmNoTelp,
            this.clmFoto});
            this.dgvListPemenang.Enabled = false;
            this.dgvListPemenang.Location = new System.Drawing.Point(8, 39);
            this.dgvListPemenang.Name = "dgvListPemenang";
            this.dgvListPemenang.RowHeadersWidth = 51;
            this.dgvListPemenang.RowTemplate.Height = 24;
            this.dgvListPemenang.Size = new System.Drawing.Size(1163, 563);
            this.dgvListPemenang.TabIndex = 43;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(1083, 614);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(18, 25);
            this.label14.TabIndex = 46;
            this.label14.Text = ":";
            // 
            // txtJmlPemenang
            // 
            this.txtJmlPemenang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJmlPemenang.Enabled = false;
            this.txtJmlPemenang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJmlPemenang.Location = new System.Drawing.Point(1105, 611);
            this.txtJmlPemenang.Name = "txtJmlPemenang";
            this.txtJmlPemenang.ReadOnly = true;
            this.txtJmlPemenang.Size = new System.Drawing.Size(64, 30);
            this.txtJmlPemenang.TabIndex = 44;
            this.txtJmlPemenang.Text = "0";
            this.txtJmlPemenang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(899, 614);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(176, 25);
            this.label15.TabIndex = 45;
            this.label15.Text = "Jumlah Pemenang";
            // 
            // clmUndianKe
            // 
            this.clmUndianKe.DataPropertyName = "UNDIAN_KE";
            this.clmUndianKe.HeaderText = "Undian Ke";
            this.clmUndianKe.MinimumWidth = 6;
            this.clmUndianKe.Name = "clmUndianKe";
            this.clmUndianKe.ReadOnly = true;
            this.clmUndianKe.Width = 125;
            // 
            // clmTglUndian
            // 
            this.clmTglUndian.DataPropertyName = "TGL_UNDI";
            this.clmTglUndian.HeaderText = "Tanggal Undi";
            this.clmTglUndian.MinimumWidth = 6;
            this.clmTglUndian.Name = "clmTglUndian";
            this.clmTglUndian.ReadOnly = true;
            this.clmTglUndian.Width = 125;
            // 
            // clmKodeAnggota
            // 
            this.clmKodeAnggota.DataPropertyName = "KODE_ANGGOTA";
            this.clmKodeAnggota.HeaderText = "Kode Anggota";
            this.clmKodeAnggota.MinimumWidth = 6;
            this.clmKodeAnggota.Name = "clmKodeAnggota";
            this.clmKodeAnggota.ReadOnly = true;
            this.clmKodeAnggota.Width = 167;
            // 
            // clmNamaAnggota
            // 
            this.clmNamaAnggota.DataPropertyName = "NAMA_ANGGOTA";
            this.clmNamaAnggota.HeaderText = "Nama Anggota";
            this.clmNamaAnggota.MinimumWidth = 6;
            this.clmNamaAnggota.Name = "clmNamaAnggota";
            this.clmNamaAnggota.Width = 172;
            // 
            // clmNoTelp
            // 
            this.clmNoTelp.DataPropertyName = "NO_TELP";
            this.clmNoTelp.HeaderText = "Nomor Telepon";
            this.clmNoTelp.MinimumWidth = 6;
            this.clmNoTelp.Name = "clmNoTelp";
            this.clmNoTelp.Width = 176;
            // 
            // clmFoto
            // 
            this.clmFoto.DataPropertyName = "FOTO_ANGGOTA";
            this.clmFoto.HeaderText = "Foto";
            this.clmFoto.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.clmFoto.MinimumWidth = 50;
            this.clmFoto.Name = "clmFoto";
            this.clmFoto.Width = 50;
            // 
            // Uc_DaftarPemenang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Peru;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClearForm);
            this.Controls.Add(this.label17);
            this.Name = "Uc_DaftarPemenang";
            this.Size = new System.Drawing.Size(1815, 800);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListPemenang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnClearForm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnBuatLaporan;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblAnggotaKelompok;
        private System.Windows.Forms.DataGridView dgvListPemenang;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtJmlPemenang;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblTgl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView lvKel;
        private System.Windows.Forms.ColumnHeader clmKodeKel;
        private System.Windows.Forms.ColumnHeader clmNmKel;
        private System.Windows.Forms.ColumnHeader clmTotAnggota;
        private System.Windows.Forms.ColumnHeader clmStatusKel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ColumnHeader clmNomor;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUndianKe;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTglUndian;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmKodeAnggota;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNamaAnggota;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNoTelp;
        private System.Windows.Forms.DataGridViewImageColumn clmFoto;
    }
}
