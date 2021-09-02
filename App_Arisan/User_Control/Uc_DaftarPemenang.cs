using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Arisan.User_Control
{
    public partial class Uc_DaftarPemenang : UserControl
    {
        public static Uc_DaftarPemenang instance;
        private Models.Models_Uc_DaftarPemenang mDaftarPemenang = new Models.Models_Uc_DaftarPemenang();
        private string txtMsg, kodeBendahara, kodeKelompok;
        private string tgl = DateTime.Now.ToString("dd-MM-yyyy");

        public Uc_DaftarPemenang()
        {
            InitializeComponent();
            this.dgvListPemenang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.lblTgl.Text = this.tgl;
            this.btnClearSearch.Click += delegate { this.txtSearch.Clear(); };
            this.txtSearch.TextChanged += delegate
            {
                DataTable dt = this.mDaftarPemenang.ListKelFromListView(this.kodeBendahara, this.txtSearch.Text);
                this.IsiListView(dt);
            };
        }

        public static Uc_DaftarPemenang Instance
        {
            get
            {
                if (instance == null)
                    instance = new Uc_DaftarPemenang();
                return instance;
            }
        }

        public string SetKodeBendahara
        {
            set
            {
                this.kodeBendahara = value;
                this.ClearForm();
                DataTable dt = this.mDaftarPemenang.ListKelFromListView(this.kodeBendahara);
                this.IsiListView(dt);
            }
        }

        public void RefreshForm()
        {
            DataTable dt = this.mDaftarPemenang.ListKelFromListView(this.kodeBendahara);
            this.IsiListView(dt);
            if (!string.IsNullOrEmpty(this.kodeKelompok))
                this.IsiDtDgv(this.kodeKelompok);
        }

        private void ClearForm()
        {
            this.kodeKelompok = "";
            this.lblAnggotaKelompok.Text = "Anggota Kelompok : ";
            if (this.dgvListPemenang.RowCount > 1)
            {
                while (this.dgvListPemenang.RowCount > 1)
                    this.dgvListPemenang.Rows.RemoveAt(0);
            }
            this.txtJmlPemenang.Text = "0";
            DataTable dt = this.mDaftarPemenang.ListKelFromListView(this.kodeBendahara);
            this.IsiListView(dt);
            this.btnBuatLaporan.Enabled = false;
        }

        private void IsiDtDgv(string kodeKel)
        {
            this.dgvListPemenang.DataSource = this.mDaftarPemenang.GetListPemenang(kodeKel);
            this.txtJmlPemenang.Text = Convert.ToString(dgvListPemenang.RowCount - 1);
        }

        private void IsiListView(DataTable dt)
        {
            this.lvKel.Items.Clear();
            DataTable dtTb = dt;
            int nomor = 0;
            foreach (DataRow dtRow in dtTb.Rows)
            {
                string[] dtArr = new string[5];
                dtArr[0] = Convert.ToString(++nomor);
                dtArr[1] = dtRow["KODE_KELOMPOK"].ToString();
                dtArr[2] = dtRow["NAMA_KELOMPOK"].ToString();
                dtArr[3] = dtRow["JUMLAH_ANGGOTA"].ToString();
                switch(dtRow["STATUS_KELOMPOK"].ToString().ToUpper())
                {
                    case "TRUE": dtArr[4] = "Berjalan";
                        break;
                    case "FALSE": dtArr[4] = "Berakhir";
                        break;
                    default: dtArr[4] = "-";
                        break;
                }
                ListViewItem lstItem = new ListViewItem(dtArr);
                this.lvKel.Items.Add(lstItem);
            }
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            this.txtMsg = "Bersihkan Form?";
            DialogResult dialog = MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
                this.ClearForm();
        }

        private void btnBuatLaporan_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.kodeKelompok))
            {
                List<string> param = new List<string>();
                param.Add(this.mDaftarPemenang.GetNamaBendahara(this.kodeBendahara)); // bendahara (kode Bendahara)
                param.Add(this.kodeKelompok); // kode kelompok
                param.Add(lvKel.SelectedItems[0].SubItems[2].Text); // nama kelompok
                param.Add(lvKel.SelectedItems[0].SubItems[4].Text); // status kelompok
                param.Add(this.tgl); // tanggal update laporan
                param.Add(this.txtJmlPemenang.Text); // jumlah pemenang
                param.Add(lvKel.SelectedItems[0].SubItems[3].Text); // total anggota

                ReportView.FrmRptDaftarPemenangArisan frm = new ReportView.FrmRptDaftarPemenangArisan(param);
                frm.Show();
            }
            else
            {
                this.txtMsg = "Pilih kelompok terlebih dahulu!";
                MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lvKel_Click(object sender, EventArgs e)
        {
            this.kodeKelompok = lvKel.SelectedItems[0].SubItems[1].Text;
            this.IsiDtDgv(this.kodeKelompok);
            if (this.dgvListPemenang.Rows.Count <= 1)
            {
                this.txtMsg = "Belum ada pemenang.";
                MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.btnBuatLaporan.Enabled = false;
            }
            else
                this.btnBuatLaporan.Enabled = true;
        }
    }
}