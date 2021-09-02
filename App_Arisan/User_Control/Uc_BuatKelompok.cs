using System;
//using System.Collections.Generic;
//using System.ComponentModel;
using System.Drawing;
using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlTypes;

namespace App_Arisan.User_Control
{
    public partial class Uc_BuatKelompok : UserControl
    {
        Models.Models_Uc_BuatKelompok mBuatKel = new Models.Models_Uc_BuatKelompok();
        private static Uc_BuatKelompok instance;
        private string kodeKelompok, namaKelompok, kodeBendahara, namaBendahara, txtErr, txtMsg;
        private int urutanKodeAnggotaBaru;
        private string kodeAnggotaBaru;
        private string kodeAnggotaTerdaftar, namaAnggotaTerdaftar, noTelpAnggotaTerdaftar;
        private string kodeHariIni = DateTime.Now.ToString("yyMMdd") + "-" + "AGT" + "-";
        private enum JnsAnggota { Baru, Terdaftar, False}
        private JnsAnggota kdsAnggota = JnsAnggota.False;
        private bool hapus = false;
        private bool edit = false;
        private enum AksesDgv { Edit, Hapus }
        private AksesDgv kdsAksesDgv;

        public Uc_BuatKelompok()
        {
            InitializeComponent();
        }

        public static Uc_BuatKelompok Instance
        {
            get
            {
                if (instance == null)
                    instance = new Uc_BuatKelompok();
                return instance;
            }
        }

        public string SetKodeBendahara
        {
            set
            {
                this.kodeBendahara = value;
                this.namaBendahara = this.mBuatKel.GetNamaBendahara(this.kodeBendahara);
                this.ClearForm();

                int jmlKode = this.mBuatKel.HitungJmlKodeAnggota(this.kodeHariIni);
                this.urutanKodeAnggotaBaru = jmlKode;
            }
        }

        private void ClearForm()
        {
            this.dgvAnggota.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.txtKodeKelompok.Focus();
            this.txtKodeKelompok.Clear();
            this.txtNamaKelompok.Clear();
            this.txtNamaKelompok.Enabled = false;
            this.txtBendahara.Text = this.namaBendahara + " (" + this.kodeBendahara + ")";
            this.txtNominal.Clear();
            this.txtNominal.Enabled = false;
            this.gbAnggota.Enabled = false;
            this.rbAnggotaBaru.Checked = false;
            this.rbAnggotaTerdaftar.Checked = false;
            this.RadioButtonAnggota();
            this.ClearFormAnggotaBaru();
            this.ClearFormAnggotaTerdaftar();
            int jmlRowDgv = this.dgvAnggota.RowCount;
            if (jmlRowDgv > 1)
                this.dgvAnggota.Rows.Clear();
            this.txtJmlAnggota.Text = "0";
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            this.txtMsg = "Anda yakin akan membatalkan dan hapus semua data yang telah di input?";
            DialogResult dialogBatal = MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogBatal == DialogResult.Yes)
                this.ClearForm();
        }

        // << DESKRIPSI KELOMPOK
        // KODE KELOMPOK
        private void txtKodeKelompok_TextChanged(object sender, EventArgs e)
        {
            if(this.txtKodeKelompok.TextLength > 10)
            {
                this.txtErr = "Kode kelompok maksimal 10 karakter!";
                this.errorProvider1.SetError(this.txtKodeKelompok, this.txtErr);
            }
            else
            {
                bool kodeBaru = this.mBuatKel.CekKodeKelompokBaru(this.txtKodeKelompok.Text);
                if (!kodeBaru)
                {
                    this.txtErr = "Kode kelompok sudah terdaftar! \nBuat kode kelompok lain.";
                    this.errorProvider1.SetError(this.txtKodeKelompok, this.txtErr);
                    this.txtNamaKelompok.Enabled = false;
                }
                else if(kodeBaru && this.txtKodeKelompok.TextLength >= 1)
                {
                    this.errorProvider1.SetError(this.txtKodeKelompok, "");
                    this.txtNamaKelompok.Enabled = true;
                    this.kodeKelompok = this.txtKodeKelompok.Text;
                }
                else
                {
                    this.errorProvider1.SetError(this.txtKodeKelompok, "");
                    this.txtNamaKelompok.Enabled = false;
                }
            }
        }

        // NAMA KELOMPOK
        private void txtNamaKelompok_TextChanged(object sender, EventArgs e)
        {
            this.lblAnggotaKelompok.Text = "Anggota Kelompok : " + this.txtNamaKelompok.Text;
            int panjangNamaKel = this.txtNamaKelompok.TextLength;
            if (panjangNamaKel > 30)
            {
                this.txtErr = "Nama kelompok maksimal 30 karakter!";
                this.errorProvider1.SetError(this.txtNamaKelompok, this.txtErr);
                this.txtNominal.Enabled = false;
            }
            else if(panjangNamaKel <= 30 && panjangNamaKel >= 1)
            {
                this.errorProvider1.SetError(this.txtNamaKelompok, "");
                this.txtNominal.Enabled = true;
                this.namaKelompok = this.txtNamaKelompok.Text;
            }
            else
            {
                this.errorProvider1.SetError(this.txtNamaKelompok, "");
                this.txtNominal.Enabled = false;
            }
        }

        private string Nominal()
        {
            string nominal = this.txtNominal.Text;
            int panjangNominal = nominal.Length;
            int idxTitik = 0;
            for (int idx = 1; idx <= panjangNominal; idx++)
            {
                if (nominal.Contains("."))
                {
                    idxTitik = nominal.IndexOf(".");
                    nominal = nominal.Remove(idxTitik, 1);
                }
            }

            return nominal;
        }

        // NOMINAL PERBAYAR
        private void txtNominal_Enter(object sender, EventArgs e)
        {
            this.gbAnggota.Enabled = false;
            this.txtNominal.Text = this.Nominal();
        }

        private void txtNominal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.gbAnggota.Enabled = true;
                this.gbAnggota.Focus();
                string nominal = this.txtNominal.Text;
                int panjangNominal = this.txtNominal.TextLength;
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
            }
        }
        // DESKRIPSI KELOMPOK >>

        // << ANGGOTA KELOMPOK
        private void ClearFormAnggotaBaru()
        {
            this.txtNamaAnggota.Clear();
            this.txtNoTelp.Clear();
            this.txtNoTelp.Enabled = false;
            this.pbFotoAnggota1.Image = App_Arisan.Properties.Resources.group;
            this.btnPilihFoto.Enabled = false;
        }

        private void ClearFormAnggotaTerdaftar()
        {
            this.txtCariAnggota.Clear();
            if (this.pbFotoAnggota2.Image != null)
            {
                this.pbFotoAnggota2.Image.Dispose();
                this.pbFotoAnggota2.Image = null;
            }
        }

        // GROUP BOX ANGGOTA
        private void RadioButtonAnggota()
        {
            if (this.rbAnggotaBaru.Checked && !this.rbAnggotaTerdaftar.Checked)
            {
                this.kdsAnggota = JnsAnggota.Baru;
                this.pnlFormAnggotaBaru.Visible = true;
                this.pnlFormAnggotaTerdaftar.Visible = false;
            }
            else if (!this.rbAnggotaBaru.Checked && this.rbAnggotaTerdaftar.Checked)
            {
                this.kdsAnggota = JnsAnggota.Terdaftar;
                this.pnlFormAnggotaBaru.Visible = false;
                this.pnlFormAnggotaTerdaftar.Visible = true;
            }
            else
            {
                this.kdsAnggota = JnsAnggota.False;
                this.pnlFormAnggotaBaru.Visible = false;
                this.pnlFormAnggotaTerdaftar.Visible = false;
            }

            if(this.kdsAnggota == JnsAnggota.Terdaftar)
            {
                this.lbAnggotaTerdaftar.DataSource = mBuatKel.GetListAnggotaTerdaftar(this.kodeBendahara);
                this.lbAnggotaTerdaftar.DisplayMember = "LIST_ANGGOTA";
                this.lbAnggotaTerdaftar.ValueMember = "KODE_ANGGOTA";
            }
        }

        private void rbAnggotaBaru_CheckedChanged(object sender, EventArgs e)
        {
            this.RadioButtonAnggota();
        }

        private void rbAnggotaTerdaftar_CheckedChanged(object sender, EventArgs e)
        {
            this.RadioButtonAnggota();
        }

        // NAMA ANGGOTA
        private void txtNamaAnggota_TextChanged(object sender, EventArgs e)
        {
            int namaLength = this.txtNamaAnggota.TextLength;
            if (namaLength > 30)
            {
                this.txtErr = "Nama maksimal 30 karakter!";
                this.errorProvider1.SetError(this.txtNamaAnggota, this.txtErr);
                this.txtNoTelp.Enabled = false;
            }
            else if (namaLength <= 30 && namaLength > 1)
            {
                this.errorProvider1.SetError(this.txtNamaAnggota, "");
                this.txtNoTelp.Enabled = true;
            }
            else
            {
                this.errorProvider1.SetError(this.txtNamaAnggota, "");
                this.txtNoTelp.Enabled = false;
            }
        }

        // NOMOR TELEPON ANGGOTA
        private void txtNoTelp_TextChanged(object sender, EventArgs e)
        {
            int noTelpLength = this.txtNoTelp.TextLength;
            if (noTelpLength < 7)
                this.btnPilihFoto.Enabled = false;
            else
                this.btnPilihFoto.Enabled = true;
        }

        // PILIH FOTO ANGGOTA
        private void btnPilihFoto_Click(object sender, EventArgs e)
        {
            this.ofd.Filter = "Image File(*.jpg; *.png) | *.jpg; *.png";
            if (this.ofd.ShowDialog() == DialogResult.OK)
            {
                this.pbFotoAnggota1.Image = Image.FromStream(this.ofd.OpenFile());
                this.btnCancelFoto.Enabled = true;
            }
        }

        // CANCEL PILIH FOTO
        private void btnCancelFoto_Click(object sender, EventArgs e)
        {
            this.pbFotoAnggota1.Image = App_Arisan.Properties.Resources.group;
        }

        // SEARCH NAMA ANGGOTA TERDAFTAR
        private void txtCariAnggota_TextChanged(object sender, EventArgs e)
        {
            if (this.txtCariAnggota.TextLength >= 1)
            {
                this.lbAnggotaTerdaftar.DataSource = mBuatKel.GetListAnggotaTerdaftarBySearch(this.txtCariAnggota.Text);
                this.lbAnggotaTerdaftar.DisplayMember = "LIST_ANGGOTA";
                this.lbAnggotaTerdaftar.ValueMember = "KODE_ANGGOTA";
            }
            else
                this.RadioButtonAnggota();
        }

        // PILIH ANGGOTA YANG SUDAH TERDAFTAR
        private void lbAnggotaTerdaftar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string kode = Convert.ToString(this.lbAnggotaTerdaftar.SelectedValue);
            DataTable dtAnggotaTerdaftar = this.mBuatKel.GetInfoAnggotaTerdaftar(kode);
            foreach (DataRow dtRow in dtAnggotaTerdaftar.Rows)
            {
                this.kodeAnggotaTerdaftar = dtRow["KODE_ANGGOTA"].ToString();
                this.namaAnggotaTerdaftar = dtRow["NAMA_ANGGOTA"].ToString();
                this.noTelpAnggotaTerdaftar = dtRow["NO_TELP"].ToString();
                System.IO.MemoryStream mStream = new System.IO.MemoryStream((byte[])dtRow["FOTO_ANGGOTA"]);
                this.pbFotoAnggota2.Image = Image.FromStream(mStream);
            }
        }
        // ANGGOTA KELOMPOK >>

        // << DATA GRID VIEW
        private void UpdateNomorDgv(int idxRow)
        {
            int jmlAnggota = idxRow;
            int no = 0;
            for(int idx = 0; idx <= idxRow; idx++)
            {
                no = idx;
                this.dgvAnggota.Rows[idx].Cells["clmNo"].Value = ++no;
            }
            this.txtJmlAnggota.Text = Convert.ToString(++jmlAnggota);
        }

        // HAPUS DATA PADA DGV
        private void dgvAnggota_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToInt32(e.RowIndex) >= 0 && Convert.ToInt32(e.ColumnIndex) >= 0)
            {
                DataGridViewRow dgv = this.dgvAnggota.Rows[e.RowIndex];
                int row = this.dgvAnggota.Rows.IndexOf(dgv);
                if (this.kdsAksesDgv == AksesDgv.Hapus)
                {
                    this.txtMsg = "Anda yakin akan hapus data terpilih?";
                    DialogResult dialogHapus = MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogHapus == DialogResult.Yes)
                    {
                        if (row < this.dgvAnggota.RowCount - 1)
                        {
                            this.dgvAnggota.Rows.RemoveAt(row);
                            this.UpdateNomorDgv(this.dgvAnggota.RowCount - 2);
                            this.btnHapus_Click(null, null);
                        }
                    }
                }
                else
                {
                    DataGridViewColumn dgvCol = this.dgvAnggota.Columns[e.ColumnIndex];
                    int col = dgvAnggota.Columns.IndexOf(dgvCol);
                    if (col == 4)
                    {
                        this.ofd.Filter = "Image File(*.jpg; *.png) | *.jpg; *.png";
                        if (this.ofd.ShowDialog() == DialogResult.OK)
                        {
                            this.pbEditFotoDiDgv.Image = Image.FromStream(this.ofd.OpenFile());
                            using (System.IO.MemoryStream mStream = new System.IO.MemoryStream())
                            {
                                this.pbEditFotoDiDgv.Image.Save(mStream, System.Drawing.Imaging.ImageFormat.Png);
                                this.dgvAnggota.Rows[row].Cells[col].Value = mStream.GetBuffer();
                            }
                        }
                    }
                }
            }
        }

        private void IsiDgv(int idxRow, string kodeAnggota, string namaAnggota, string noTelp, PictureBox fotoAnggota)
        {
            this.dgvAnggota.Rows[idxRow].Cells["clmKodeAnggota"].Value = kodeAnggota;
            this.dgvAnggota.Rows[idxRow].Cells["clmNamaAnggota"].Value = namaAnggota;
            this.dgvAnggota.Rows[idxRow].Cells["clmNoTelp"].Value = noTelp;
            using (System.IO.MemoryStream mStream = new System.IO.MemoryStream())
            {
                fotoAnggota.Image.Save(mStream, System.Drawing.Imaging.ImageFormat.Png);
                this.dgvAnggota.Rows[idxRow].Cells["clmFoto"].Value = mStream.GetBuffer();
            }
            this.UpdateNomorDgv(idxRow);
        }
        // DATA GRID VIEW >>

        // BUTTON TAMBAH ANGGOTA
        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (this.kdsAnggota == JnsAnggota.Baru)
            { 
                if (this.btnPilihFoto.Enabled)
                {
                    this.dgvAnggota.Rows.Add();
                    int jmlRow = this.dgvAnggota.RowCount - 1;
                    int idxRow = --jmlRow;
                    this.urutanKodeAnggotaBaru++;
                    this.kodeAnggotaBaru = this.kodeHariIni + Convert.ToString(this.urutanKodeAnggotaBaru);
                    this.IsiDgv(idxRow, this.kodeAnggotaBaru, this.txtNamaAnggota.Text, this.txtNoTelp.Text, this.pbFotoAnggota1);
                    this.ClearFormAnggotaBaru();
                }
                else
                {
                    this.txtMsg = "Periksa kembali anggota baru, nama dan nomor telepon!";
                    MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if(this.kdsAnggota == JnsAnggota.Terdaftar)
            {
                if(this.pbFotoAnggota2.Image != null)
                {
                    this.dgvAnggota.Rows.Add();
                    int jmlRow = this.dgvAnggota.RowCount - 1;
                    int idxRow = --jmlRow;
                    this.IsiDgv(idxRow, this.kodeAnggotaTerdaftar, this.namaAnggotaTerdaftar, this.noTelpAnggotaTerdaftar, this.pbFotoAnggota2);
                    this.ClearFormAnggotaTerdaftar();
                }
                else
                {
                    this.txtMsg = "Pilih anggota terlebih dahulu!";
                    MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                this.txtMsg = "Pilih 'anggota baru' atau 'anggota terdaftar' terlebih dahulu!";
                MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // BUTTON TAMBAH ANGGOTA KE DGV
        private void ClickBtnEdit(string txtBtn, bool eldDgv, Cursor crsDgv)
        {
            this.btnEdit.Text = txtBtn;
            this.dgvAnggota.Enabled = eldDgv;
            this.dgvAnggota.Cursor = crsDgv;

            if (eldDgv)
            {
                this.btnTambah.Enabled = false;
                this.btnHapus.Enabled = false;
                this.btnSimpanData.Enabled = false;
            }
            else
            {
                this.btnTambah.Enabled = true;
                this.btnHapus.Enabled = true;
                this.btnSimpanData.Enabled = true;
            }
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.kdsAksesDgv = AksesDgv.Edit;
            string txtBtn = this.btnEdit.Text;
            if (txtBtn == "Edit")
            {
                if (this.dgvAnggota.RowCount <= 1)
                {
                    this.txtMsg = "Data kosong!";
                    MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.edit = false;
                }
                else
                {
                    this.txtMsg = "Pilih data yang akan di edit!";
                    MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.edit = true;
                }
            }
            else
                this.edit = false;

            if (this.edit)
                this.ClickBtnEdit("Selesai", true, Cursors.Hand);
            else
                this.ClickBtnEdit("Edit", false, Cursors.Default);
        }

        // BUTTON HAPUS ANGGOTA DGV
        private void ClickBtnHapus(string txtBtn, bool eldDgv, Cursor crsDgv)
        {
            this.btnHapus.Text = txtBtn;
            this.dgvAnggota.Enabled = eldDgv;
            this.dgvAnggota.Cursor = crsDgv;

            if (eldDgv)
            {
                this.btnTambah.Enabled = false;
                this.btnEdit.Enabled = false;
                this.btnSimpanData.Enabled = false;
            }
            else
            {
                this.btnTambah.Enabled = true;
                this.btnEdit.Enabled = true;
                this.btnSimpanData.Enabled = true;
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                if (this.dgvAnggota.RowCount <= 1)
                {
                    this.txtMsg = "Data kosong!";
                    MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.hapus = false;
                } 
                else
                    this.hapus = !this.hapus;
            }
            else
                this.hapus = false;

            if (this.hapus)
            {
                this.kdsAksesDgv = AksesDgv.Hapus;
                this.ClickBtnHapus("Cancel", true, Cursors.Hand);
                this.txtMsg = "Pilih data yang akan dihapus pada tabel";
                MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                this.ClickBtnHapus("Hapus", false, Cursors.Default);
        }

        // BUTTON SIMPAN DATA KE DB
        private void btnSimpanData_Click(object sender, EventArgs e)
        {
            int jmlData = this.dgvAnggota.RowCount - 1;
            if (jmlData > 0)
            {
                this.txtMsg = "Simpan data?";
                DialogResult dialogSimpan = MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogSimpan == DialogResult.Yes)
                {
                    int anggotaBaruTersimpan = 0;
                    int anggotaTerdaftarKelompok = 0;
                    string kode, nama, noTelp;
                    string tgl = DateTime.Now.ToString("dd-MM-yyy");
                    byte[] foto;

                    for (int idx = 0; idx < jmlData; idx++)
                    {
                        kode = Convert.ToString(this.dgvAnggota.Rows[idx].Cells["clmKodeAnggota"].Value);
                        nama = Convert.ToString(this.dgvAnggota.Rows[idx].Cells["clmNamaAnggota"].Value);
                        noTelp = Convert.ToString(this.dgvAnggota.Rows[idx].Cells["clmNoTelp"].Value);
                        foto = (byte[])this.dgvAnggota.Rows[idx].Cells["clmFoto"].Value;

                        // INPUT/UPDATE KE TB_ANGGOTA
                        if (this.mBuatKel.CekKodeAnggota(kode) == 0) // input
                        {
                            if (this.mBuatKel.InputAnggota(kode, nama, tgl, noTelp, foto) == 1)
                                anggotaBaruTersimpan++;
                        }
                        else // update
                        {
                            if (this.mBuatKel.UpdateAnggota(kode, nama, noTelp, foto) == 1)
                                anggotaBaruTersimpan++;
                        }

                        // INPUT KE TB_ANGGOTA_TERDAFTAR_KELOMPOK
                        if (this.mBuatKel.InputAnggotaTerdaftarKelompok(this.kodeKelompok, kode) == 1)
                            anggotaTerdaftarKelompok++;
                    }

                    // INPUT KE TB_KELOMPOK_ARISAN
                    if (anggotaBaruTersimpan == jmlData && anggotaTerdaftarKelompok == jmlData)
                    {
                        int inputKel = this.mBuatKel.InputKelompok(this.kodeKelompok, this.namaKelompok, tgl, this.kodeBendahara, this.Nominal(), Convert.ToInt32(this.txtJmlAnggota.Text));
                        if (inputKel == 1)
                        {
                            this.txtMsg = "Simpan data berhasil.";
                            MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.ClearForm();
                        }
                        else
                        {
                            this.txtMsg = "Simpan data Gagal!";
                            MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                this.txtMsg = "Data Kosong! Input data terlebih dahulu!";
                MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}