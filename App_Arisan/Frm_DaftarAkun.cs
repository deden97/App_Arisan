using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Arisan
{
    public partial class Frm_DaftarAkun : Form
    {
        Models.Models_Frm_DaftarAkun mDaftarAkun = new Models.Models_Frm_DaftarAkun();
        private string kodeAkun, kodeAkunBaru, tglDaftar, namaLengkap, username, password;
        private string txtMsg;
        private byte[] profilUser;

        public Frm_DaftarAkun(string kodeAkun)
        {
            InitializeComponent();
            this.kodeAkun = kodeAkun;
        }

        /* FORM ******************************************************************************************/
        private void Frm_DaftarAkun_Load(object sender, EventArgs e)
        {
            this.UpdateKodeAkunBaru();
        }

        private void Frm_DaftarAkun_Activated(object sender, EventArgs e)
        {
            if(!this.mDaftarAkun.CekStatusAkun(this.kodeAkun))
            {
                this.txtMsg = "Session Expire!";
                MessageBox.Show(this.txtMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        /****************************************************************************************** FORM */

        private void ClearForm()
        {
            this.txtNamaLengkap.Clear();
            this.txtUsername.Clear();
            this.txtPassword.Clear();
            this.txtKonfirmPass.Clear();
            this.pbFotoAkun.Image = App_Arisan.Properties.Resources.profile_user;
            this.UpdateKodeAkunBaru();
        }

        private void UpdateKodeAkunBaru()
        {
            int jmlKode = this.mDaftarAkun.GetJumlahKodeAkun();
            this.kodeAkunBaru = DateTime.Now.ToString("yyMMdd") + "-" + "AKN" + "-" + Convert.ToString(++jmlKode);
            this.txtKodeAkun.Text = this.kodeAkunBaru;
            this.txtNamaLengkap.Focus();
        }

        private void txtNamaLengkap_TextChanged(object sender, EventArgs e)
        {
            string txtErr;
            int txtLength = this.txtNamaLengkap.TextLength;
            if (txtLength > 30)
            {
                txtErr = "Tidak boleh lebih dari 30 karakter! \nNama bisa disingkat.";
                this.errorProvider1.SetError(this.txtNamaLengkap, txtErr);
                this.txtUsername.Enabled = false;
            }
            else if (txtLength > 0 && txtLength <= 30)
            {
                this.errorProvider1.SetError(this.txtNamaLengkap, "");
                string txt = this.txtNamaLengkap.Text;
                string txtSub;
                bool tryPrsToInt;
                int hsl, jmlAngka = 0;
                for (int idx = 0; idx < txt.Length; idx++)
                {
                    txtSub = txt.Substring(idx, 1);
                    tryPrsToInt = int.TryParse(txtSub, out hsl);
                    if (tryPrsToInt)
                        jmlAngka++;
                }

                if (jmlAngka > 0)
                {
                    txtErr = "Nama tidak boleh berisi nomor!";
                    this.errorProvider1.SetError(this.txtNamaLengkap, txtErr);
                    this.txtUsername.Enabled = false;
                }
                else
                {
                    this.errorProvider1.SetError(this.txtNamaLengkap, "");
                    this.namaLengkap = this.txtNamaLengkap.Text;
                    this.txtUsername.Enabled = true;
                }
            }
            else
                this.txtUsername.Enabled = false;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            string txtErr;
            int txtLength = this.txtUsername.TextLength;
            if (txtLength > 15)
            {
                txtErr = "Username maksimal 15 karakter!";
                this.errorProvider1.SetError(this.txtUsername, txtErr);
                this.txtPassword.Enabled = false;
            }
            else if (txtLength > 0 && txtLength <= 15)
            {
                this.errorProvider1.SetError(this.txtUsername, "");
                this.username = this.txtUsername.Text;
                this.txtPassword.Enabled = true;
            }
            else
                this.txtPassword.Enabled = false;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            string txtErr;
            int txtLength = this.txtPassword.TextLength;
            if (txtLength > 225)
            {
                txtErr = "Password tidak boleh lebih dari 225 karakter!";
                this.errorProvider1.SetError(this.txtPassword, txtErr);
                this.txtKonfirmPass.Enabled = false;
            }
            else if (txtLength > 0 && txtLength <= 225)
            {
                this.errorProvider1.SetError(this.txtKonfirmPass, "");
                this.txtKonfirmPass.Enabled = true;
            }
            else
                this.txtKonfirmPass.Enabled = false;
        }

        private void txtKonfirmPass_TextChanged(object sender, EventArgs e)
        {
            string txtErr;
            if(this.txtPassword.TextLength > 0)
            {
                if (this.txtKonfirmPass.Text != this.txtPassword.Text)
                {
                    txtErr = "Password tidak sesuai!";
                    this.errorProvider1.SetError(this.txtKonfirmPass, txtErr);
                    this.btnPilihFoto.Enabled = false;
                    this.btnSubmit.Enabled = false;
                }
                else
                {
                    this.errorProvider1.SetError(this.txtKonfirmPass, "");
                    this.password = this.txtKonfirmPass.Text;
                    this.btnPilihFoto.Enabled = true;
                    this.btnSubmit.Enabled = true;
                }
            }
            else
            {
                this.btnPilihFoto.Enabled = false;
                this.btnSubmit.Enabled = false;
            }
        }

        private void ckbTampilkanPass_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbTampilkanPass.Checked)
            {
                this.txtPassword.UseSystemPasswordChar = false;
                this.txtKonfirmPass.UseSystemPasswordChar = false;
            }
            else
            {
                this.txtPassword.UseSystemPasswordChar = true;
                this.txtKonfirmPass.UseSystemPasswordChar = true;
            }
        }

        private void btnPilihFoto_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "Image File(*.jpg; *.png) | *.jpg; *.png";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pbFotoAkun.Image = Image.FromStream(openFileDialog1.OpenFile());
                System.IO.MemoryStream mStream = new System.IO.MemoryStream();
                this.pbFotoAkun.Image.Save(mStream, System.Drawing.Imaging.ImageFormat.Png);
                this.profilUser = mStream.GetBuffer();
            }    
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.txtMsg = $"Anda akan daftar dengan nama: '{this.namaLengkap}' ?";
            DialogResult dialogDaftarAkun = MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialogDaftarAkun == DialogResult.Yes)
            {
                this.tglDaftar = DateTime.Now.ToString("dd-MM-yyyy");
                int daftarAkun = this.mDaftarAkun.DaftarAkun(this.kodeAkunBaru, this.tglDaftar, this.namaLengkap, this.profilUser, this.username, this.password);
                if (daftarAkun == 1)
                {
                    this.txtMsg = "Daftar sukses, silahkan untuk login.";
                    MessageBox.Show(txtMsg, "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ClearForm();
                    this.Close();
                }
                else
                {
                    this.txtMsg = "Daftar akun gagal, periksa kembali data yang anda input! \nPastikan tidak ada tanda seru merah.";
                    MessageBox.Show(txtMsg, "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.txtMsg = "Anda yakin akan membatalkan pendaftaran \ndan menghapus semua data yang sudah diinput?";
            DialogResult dialogBatal = MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialogBatal == DialogResult.Yes)
            {
                this.ClearForm();
                this.Close();
            }
        }
    }
}