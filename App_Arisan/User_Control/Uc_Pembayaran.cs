using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlTypes;

namespace App_Arisan.User_Control
{
    public partial class Uc_Pembayaran : UserControl
    {
        public static Uc_Pembayaran instance;
        Models.Models_Uc_Pembayaran mPembayaran = new Models.Models_Uc_Pembayaran();
        private string kodeBendahara, txtMsg;
        private int jumlahAnggota;

        public Uc_Pembayaran()
        {
            InitializeComponent();
        }

        public static Uc_Pembayaran Instance
        {
            get
            {
                if (instance == null)
                    instance = new Uc_Pembayaran();
                return instance;
            }
        }

        public string SetKodeBendahara
        {
            set
            {
                this.kodeBendahara = value;
                this.RefreshCmb();
                this.ClearForm();
            }
        }

        public void ResfreshForm() => this.RefreshCmb();

        private void RefreshCmb()
        {
            string kelTerpilih = this.cmbNamaKelompok.Text;
            if(kelTerpilih != "--Pilih--")
            {
                this.cmbNamaKelompok.DataSource = mPembayaran.ListKelompokUntukCmb(this.kodeBendahara);
                this.cmbNamaKelompok.DisplayMember = "NAMA_KELOMPOK";
                this.cmbNamaKelompok.ValueMember = "KODE_KELOMPOK";
                this.cmbNamaKelompok.Text = kelTerpilih;
            }
            else
            {
                this.cmbNamaKelompok.DataSource = mPembayaran.ListKelompokUntukCmb(this.kodeBendahara);
                this.cmbNamaKelompok.DisplayMember = "NAMA_KELOMPOK";
                this.cmbNamaKelompok.ValueMember = "KODE_KELOMPOK";
                this.cmbNamaKelompok.Text = "--Pilih--";
                this.ClearForm();
            }
        }

        private void ClearForm()
        {
            this.cmbNamaKelompok.Text = "--Pilih--";
            this.lblAnggotaKelompok.Text = "Anggota Kelompok : ";
            this.txtKodeKelompok.Clear();
            this.txtBendahara.Clear();
            this.txtNominal.Clear();
            this.txtJmlAnggota.Text = "0";
            this.dgvAnggota.Columns.Clear();
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            this.txtMsg = "Anda yakin akan membersihkan form?";
            DialogResult dialogClearFrm = MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogClearFrm == DialogResult.Yes)
            {
                this.RefreshCmb();
                this.ClearForm();
            }  
        }

        private void UpdateDgv(string kodeKelompok, int jmlAnggota)
        {
            this.jumlahAnggota = jmlAnggota;
            this.dgvAnggota.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewTextBoxColumn idKel = new DataGridViewTextBoxColumn();
            idKel.HeaderText = "ID";
            idKel.Name = "id";
            idKel.DataPropertyName = "ID";
            idKel.ReadOnly = true;
            idKel.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            idKel.FillWeight = 10;
            idKel.Width = 20;
            this.dgvAnggota.Columns.Add(idKel);
            idKel.Visible = false;

            DataGridViewTextBoxColumn no = new DataGridViewTextBoxColumn();
            no.HeaderText = "No.";
            no.Name = "no";
            no.ReadOnly = true;
            no.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            no.FillWeight = 5;
            this.dgvAnggota.Columns.Add(no);

            DataGridViewTextBoxColumn kode = new DataGridViewTextBoxColumn();
            kode.HeaderText = "Kode Anggota";
            kode.Name = "kode";
            kode.DataPropertyName = "KODE";
            kode.ReadOnly = true;
            kode.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            kode.FillWeight = 10;
            this.dgvAnggota.Columns.Add(kode);

            DataGridViewTextBoxColumn anggota = new DataGridViewTextBoxColumn();
            anggota.HeaderText = "Anggota";
            anggota.Name = "agt";
            anggota.DataPropertyName = "ANGGOTA";
            anggota.ReadOnly = true;
            anggota.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            anggota.FillWeight = 10;
            this.dgvAnggota.Columns.Add(anggota);

            DataGridViewTextBoxColumn NoTelp = new DataGridViewTextBoxColumn();
            NoTelp.HeaderText = "No. Telp.";
            NoTelp.Name = "noTelp";
            NoTelp.DataPropertyName = "TELP";
            NoTelp.ReadOnly = true;
            NoTelp.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            NoTelp.FillWeight = 10;
            this.dgvAnggota.Columns.Add(NoTelp);

            // Isi data anggota
            this.dgvAnggota.DataSource = this.mPembayaran.ListAnggota(kodeKelompok);

            if (this.dgvAnggota.RowCount > 1)
            {
                int nomor;
                for (int idx = 0; idx < this.jumlahAnggota; idx++)
                {
                    nomor = idx;
                    this.dgvAnggota.Rows[idx].Cells["no"].Value = ++nomor;
                }

                string cellNamePyr;
                int idAnggota;
                for (int idx = 1; idx <= this.jumlahAnggota; idx++)
                {
                    // buat column checkbox pembayaran ke - 1..n
                    DataGridViewCheckBoxColumn clmBayar = new DataGridViewCheckBoxColumn();
                    clmBayar.HeaderText = "Pembayaran Ke - " + idx.ToString();
                    cellNamePyr = "byr - " + idx.ToString();
                    clmBayar.Name = cellNamePyr;
                    clmBayar.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                    clmBayar.FillWeight = 10;
                    this.dgvAnggota.Columns.Add(clmBayar);

                    // cek lalu isi ke column pembayaran ke - 1..n dari baris pertama sampai akhir
                    for (int idxRow = 0; idxRow < this.jumlahAnggota; idxRow++)
                    {
                        idAnggota = Convert.ToInt32(this.dgvAnggota.Rows[idxRow].Cells["id"].Value);
                        this.dgvAnggota.Rows[idxRow].Cells[cellNamePyr].Value = this.mPembayaran.Pembayaran(idAnggota, idx);
                    }
                }
            }
        }

        private void cmbNamaKelompok_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbNamaKelompok.Text != "--Pilih--")
            {
                this.dgvAnggota.Columns.Clear();
                string kodeKel = this.cmbNamaKelompok.SelectedValue.ToString();
                this.txtKodeKelompok.Text = kodeKel;
                int jmlAgt = 0;
                DataTable dt = this.mPembayaran.InfoKelompok(this.txtKodeKelompok.Text);
                foreach(DataRow dtRow in dt.Rows)
                {
                    this.txtBendahara.Text = dtRow["BENDAHARA"].ToString();
                    string nominal = dtRow["NOMINAL_PERBAYAR"].ToString();
                    nominal = nominal.Remove(nominal.Length - 5, 5);
                    int panjangNominal = nominal.Length;
                    int jmlTitik = 0;

                    if ((panjangNominal % 3) > 0)
                        jmlTitik = panjangNominal / 3;
                    else
                        jmlTitik = (panjangNominal / 3) - 1;

                    if (!nominal.Contains("."))
                    {
                        int idxTitik = panjangNominal;
                        for (int idx = 1; idx <= jmlTitik; idx++)
                        {
                            idxTitik -= 3;
                            nominal = nominal.Insert(idxTitik, ".");
                        }
                    }

                    this.txtNominal.Text = nominal;
                    jmlAgt = Convert.ToInt32(dtRow["JUMLAH_ANGGOTA"]);
                    this.txtJmlAnggota.Text = jmlAgt.ToString();
                }

                // dgv
                this.lblAnggotaKelompok.Text = "Anggota Kelompok : " + this.cmbNamaKelompok.Text;
                this.UpdateDgv(kodeKel, jmlAgt);
            }
        }

        private void btnSimpanPembayaran_Click(object sender, EventArgs e)
        {
            // dialog
            this.txtMsg = "Anda yakin akan simpan data pembayaran?";
            DialogResult dialogSavePembayaran = MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialogSavePembayaran == DialogResult.Yes)
            {
                int jmlDtRow = this.dgvAnggota.RowCount - 1;
                int dtYgBelumTersimpan = 0;
                int dtTersimpan = 0;
                for (int row = 0; row < jmlDtRow; row++) //row
                {
                    string cellNamePyr;
                    bool lunas;
                    for(int col = 1; col <= this.jumlahAnggota; col++) //column (pembayaran)
                    {
                        // cek pembayaran (lunas/belum)
                        cellNamePyr = "byr - " + col.ToString();
                        lunas = Convert.ToBoolean(this.dgvAnggota.Rows[row].Cells[cellNamePyr].Value);
                        if (lunas)
                        {
                            // cek pembayaran (sudah tersimpan / belum)
                            int idKel = Convert.ToInt32(this.dgvAnggota.Rows[row].Cells["id"].Value);
                            string tglPyr = DateTime.Now.ToString("dd-MM-yyyy");
                            int urtPembayaran = col;
                            if (!this.mPembayaran.CekPembayaran(idKel, urtPembayaran))
                            {
                                dtYgBelumTersimpan++;
                                if (this.mPembayaran.SimpanPembayaran(idKel, tglPyr, urtPembayaran) == 1)
                                    dtTersimpan++;
                            }
                        }
                    }
                }

                if(dtYgBelumTersimpan == dtTersimpan)
                {
                    this.txtMsg = "Pembayaran telah disimpan.";
                    MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}