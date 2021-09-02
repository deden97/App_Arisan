using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Arisan.User_Control
{
    public partial class Uc_UndiArisan : UserControl
    {
        Models.Models_Uc_UndiArisan mUndiArisan = new Models.Models_Uc_UndiArisan();
        private int jumlahAnggota, urutanUndian, undiDetik, waktuUndi;
        private Random undi;
        private string kodeKelompok, kodeAnggotaPemenang, txtMsg, tglUndian;
        private string[] listUndian;
        private string[] anggotaYangSudahMenang;
        private char[] selamat = { 'S', 'e', 'l', 'a', 'm', 'a', 't', ' ', '!' };
        private int idxSelamat = -1;
        
        public Uc_UndiArisan()
        {
            InitializeComponent();
        }

        public static Uc_UndiArisan instance;
        public static Uc_UndiArisan Instance
        {
            get
            {
                if (instance == null)
                    instance = new Uc_UndiArisan();

                return instance;
            }
        }

        private string kodeBendahara;
        public string SetKodeBendahara
        {
            set
            {
                this.kodeBendahara = value;
                this.UpdateCmb();
                this.ClearForm();
            }
        }

        public void ResfreshForm() => this.UpdateCmb();

        private void ClearForm()
        {
            this.kodeKelompok = "";
            this.cmbNamaKelompok.Text = "--Pilih--";
            this.txtKodeKelompok.Clear();
            this.txtBendahara.Clear();
            this.txtTotNominal.Clear();
            this.txtUndianKe.Clear();
            this.txtJumlahAnggota.Clear();
            this.ClearFormUndian();
            this.ButtonFormUndian(false, false, false);
        }

        private void ClearFormUndian()
        {
            this.lblPemenang.Text = "";
            this.lblSelamat.Text = "";
            this.tSelamat.Stop();
            this.idxSelamat = -1;
            this.lblNoTelpPemenang.Text = "";
            this.pbFotoPemenang.Visible = false;
        }

        private void ButtonFormUndian(bool undi, bool batal, bool cetak)
        {
            this.btnUndi.Enabled = undi;
            this.btnBatalUndian.Enabled = batal;
            this.btnCetakHasilUndian.Enabled = cetak;
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            this.txtMsg = "Bersihkan Form?";
            DialogResult dialogBersihkanForm = MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialogBersihkanForm == DialogResult.Yes)
            {
                this.ClearForm();
                this.ClearFormUndian();
                this.btnUndi.Text = "Undi Arisan";
            }
        }

        private void UpdateCmb()
        {
            string kelTerpilih = this.cmbNamaKelompok.Text;
            if(kelTerpilih != "--Pilih--")
            {
                this.cmbNamaKelompok.DataSource = this.mUndiArisan.ListKelompokUntukCmb(this.kodeBendahara);
                this.cmbNamaKelompok.DisplayMember = "NAMA_KELOMPOK";
                this.cmbNamaKelompok.ValueMember = "KODE_KELOMPOK";
                this.cmbNamaKelompok.Text = kelTerpilih;
            }
            else
            {
                this.cmbNamaKelompok.DataSource = this.mUndiArisan.ListKelompokUntukCmb(this.kodeBendahara);
                this.cmbNamaKelompok.DisplayMember = "NAMA_KELOMPOK";
                this.cmbNamaKelompok.ValueMember = "KODE_KELOMPOK";
                this.cmbNamaKelompok.Text = "--Pilih--";
                this.ClearForm();
            }
        }

        private void cmbNamaKelompok_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.cmbNamaKelompok.Text != "--Pilih--")
            {
                this.btnUndi.Text = "Undi Arisan";
                this.ButtonFormUndian(true, false, false);
                this.ClearFormUndian();

                // isi informasi kelompok arisan
                this.kodeKelompok = this.cmbNamaKelompok.SelectedValue.ToString();
                this.urutanUndian = Convert.ToInt32(this.mUndiArisan.UrutanUndian(this.kodeKelompok) + 1);
                this.txtKodeKelompok.Text = this.kodeKelompok;
                DataTable dtInfo = this.mUndiArisan.GetInfoKelompok(this.kodeKelompok);
                foreach (DataRow dtRow in dtInfo.Rows)
                {
                    this.txtBendahara.Text = dtRow["BENDAHARA"].ToString();
                    string totNominal = dtRow["TOTAL_NOMINAL"].ToString();
                    totNominal = totNominal.Remove(totNominal.Length - 5);
                    int panjangNominal = totNominal.Length;
                    int jmlTitik = 0;

                    if ((panjangNominal % 3) > 0)
                        jmlTitik = panjangNominal / 3;
                    else
                        jmlTitik = (panjangNominal / 3) - 1;
                    if (!totNominal.Contains("."))
                    {
                        int idxTitik = panjangNominal;
                        for (int idx = 1; idx <= jmlTitik; idx++)
                        {
                            idxTitik -= 3;
                            totNominal = totNominal.Insert(idxTitik, ".");
                        }
                    }
                    this.txtTotNominal.Text = totNominal;
                    this.txtUndianKe.Text = this.urutanUndian.ToString();
                    this.jumlahAnggota = Convert.ToInt32(dtRow["JUMLAH_ANGGOTA"]);
                    this.txtJumlahAnggota.Text = this.jumlahAnggota.ToString();
                } 
            }
        }

        private void UndiArisan()
        {
            // cek pembayaran (semua anggota harus sudah membayar pembayaran sesuai urutan)
            int jmlAgtLunas = this.mUndiArisan.CekPembayaran(this.kodeKelompok, Convert.ToInt32(this.urutanUndian));
            if (jmlAgtLunas == Convert.ToInt32(this.jumlahAnggota)) // jika semua anggota sudah membayar/lunas
            {
                // isi list anggota yang sudah menang
                int pemenang = this.urutanUndian - 1;
                this.anggotaYangSudahMenang = new string[pemenang];
                DataTable dtAgtYgSdhMenang = this.mUndiArisan.GetListAnggotaYgSudahMenang(this.kodeKelompok);
                int idxPemenang = -1;
                foreach (DataRow dtRow in dtAgtYgSdhMenang.Rows)
                {
                    idxPemenang++;
                    this.anggotaYangSudahMenang[idxPemenang] = dtRow["ANGGOTA"].ToString();
                }

                // isi list undian
                this.listUndian = new string[this.jumlahAnggota - pemenang];
                DataTable dtListUndian = this.mUndiArisan.GetListAnggota(this.kodeKelompok);
                int idxListUndian = -1;
                string agt;
                bool tambahKeList;
                foreach (DataRow dtRow in dtListUndian.Rows)
                {
                    agt = dtRow["ANGGOTA"].ToString();
                    tambahKeList = true;
                    // cek nama anggota dengan anggota yagn sudah menang(pemenang)
                    for (int idx = 0; idx < this.anggotaYangSudahMenang.Length; idx++)
                    {
                        if (agt == this.anggotaYangSudahMenang[idx])
                            tambahKeList = false;
                    }

                    // jika anggota belum menang, maka ditambah ke 'listUndian'
                    if (tambahKeList)
                    {
                        idxListUndian++;
                        this.listUndian[idxListUndian] = agt;
                    }
                }

                this.undi = new Random();
                this.waktuUndi = 30000;
                this.tUndiArisan.Start();
            }
            else // jika ada anggota yang belum bayar/lunas
            {
                this.txtMsg = $"Undian ke - '{this.urutanUndian}' tidak bisa dilakukan, karena " +
                              "ada anggota yang belum bayar/lunas! Silahkan cek di 'Pembayaran'";
                MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.ClearForm();
                this.ClearFormUndian();
            }
        }

        private void btnUndi_Click(object sender, EventArgs e)
        {
            this.ButtonFormUndian(true, true, false);
            if(this.btnUndi.Text == "Undi Arisan")
            {
                this.UndiArisan();
                this.btnUndi.Text = "Undi Ulang";
            }
            else
            {
                this.txtMsg = "Anda yakin akan undi ulang?";
                DialogResult dialogUndiUlang = MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dialogUndiUlang == DialogResult.Yes)
                {
                    this.mUndiArisan.HapusPemenang(this.kodeKelompok, this.kodeAnggotaPemenang);
                    this.ClearFormUndian();
                    this.UndiArisan();
                    this.btnUndi.Text = "Undi Ulang";
                }
            }
        }

        private void SimpanPemenangUndian()
        {
            this.tglUndian = DateTime.Now.ToString("dd-MM-yyyy");
            this.mUndiArisan.SimpanUndian(this.tglUndian, this.kodeKelompok, this.kodeAnggotaPemenang, this.urutanUndian);
            if (this.urutanUndian == this.jumlahAnggota)
                this.mUndiArisan.UpdataStatusKelompok(this.kodeKelompok);
        }

        private void StopUndian()
        {
            this.undiDetik = 0;
            this.tUndiArisan.Stop();
            this.lblSelamat.Visible = true;
            string kodePemenang = this.lblPemenang.Text;
            kodePemenang = kodePemenang.Remove(kodePemenang.Length - 1);
            this.kodeAnggotaPemenang = kodePemenang.Remove(0, kodePemenang.IndexOf('(') + 1);
            DataTable dtInfoPemenang = this.mUndiArisan.GetInfoPemenang(this.kodeAnggotaPemenang);
            foreach (DataRow dtRow in dtInfoPemenang.Rows)
            {
                this.lblNoTelpPemenang.Text = dtRow["NO_TELP"].ToString();
                this.pbFotoPemenang.Visible = true;
                using (System.IO.MemoryStream mStream = new System.IO.MemoryStream((byte[])dtRow["FOTO_ANGGOTA"]))
                    this.pbFotoPemenang.Image = Image.FromStream(mStream);
            }
            this.SimpanPemenangUndian();
            this.tSelamat.Start();
            this.ButtonFormUndian(true, false, true);
        }

        private void tUndiArisan_Tick(object sender, EventArgs e)
        {
            if (this.listUndian.Length > 1)
            {
                if (this.undiDetik < this.waktuUndi)
                {
                    this.undiDetik += 250;
                    this.lblSelamat.Visible = false;
                    this.lblPemenang.Text = this.listUndian[this.undi.Next(this.listUndian.Length)];
                }
                else
                    this.StopUndian();
            }
            else
            {
                this.lblPemenang.Text = this.listUndian[0];
                this.StopUndian();
            }
        }

        private void tSelamat_Tick(object sender, EventArgs e)
        {
            if (this.idxSelamat < 8)
            {
                this.idxSelamat++;
                this.lblSelamat.Text += Convert.ToString(this.selamat[this.idxSelamat]);
            }
            else
            {
                this.idxSelamat = -1;
                this.lblSelamat.Text = "";
            }
        }

        private void btnBatalUndian_Click(object sender, EventArgs e)
        {
            this.txtMsg = "Anda yakin akan membatalkan undian?";
            DialogResult dialogBatalUndian = MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialogBatalUndian == DialogResult.Yes)
            {
                this.tUndiArisan.Stop();
                this.waktuUndi = 30000;
                this.undiDetik = 0;
                this.ClearFormUndian();
                this.ButtonFormUndian(true, false, false);
            }
        }

        private void btnCetakHasilUndian_Click(object sender, EventArgs e)
        {
            List<string> dtRpt = new List<string>();
            dtRpt.Insert(0, this.tglUndian);
            dtRpt.Insert(1, this.cmbNamaKelompok.Text + $" ({this.kodeKelompok})");
            dtRpt.Insert(2, this.txtBendahara.Text);
            dtRpt.Insert(3, this.txtTotNominal.Text);
            dtRpt.Insert(4, this.txtUndianKe.Text);
            dtRpt.Insert(5, this.lblPemenang.Text);
            dtRpt.Insert(6, this.lblNoTelpPemenang.Text);

            ReportView.frmRptPemenangArisan rptPemenang = new ReportView.frmRptPemenangArisan(dtRpt);
            rptPemenang.Show();
            this.ButtonFormUndian(false, false, true);
        }
    }
}