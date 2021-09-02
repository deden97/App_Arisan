using System;
//using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Arisan
{
    public partial class Frm_EditData : Form
    {
        Models.Models_Frm_EditData mEditData = new Models.Models_Frm_EditData();
        private string kodeAkun;
        private string txtMsg, txtErr;

        public Frm_EditData(string kodeAkun)
        {
            InitializeComponent();
            this.kodeAkun = kodeAkun;
        }

        /* FORM *****************************************************************************************/
        private void Frm_EditData_Load(object sender, EventArgs e)
        {
            if (mEditData.CekKodeAkun(this.kodeAkun) != 1)
            {
                MessageBox.Show("Akun Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                this.txtKodeAkun.Text = this.kodeAkun;
                this.txtKodeAkun2.Text = this.kodeAkun;
                this.txtKodeAkun3.Text = this.kodeAkun;
                DataTable infoAkun = mEditData.GetInfoLengkapAkun(this.kodeAkun);
                foreach(DataRow dtRow in infoAkun.Rows)
                {
                    this.txtNamaLengkap.Text = dtRow["NAMA_LENGKAP"].ToString();
                    using (System.IO.MemoryStream mStream = new System.IO.MemoryStream((byte[])dtRow["FOTO"]))
                    {
                        this.pbFotoAkun.Image = Image.FromStream(mStream);
                    }
                }
            }  
        }

        private void Frm_EditData_Activated(object sender, EventArgs e)
        {
            if(!this.mEditData.CekStatusAkun(this.kodeAkun))
            {
                this.txtMsg = "Session Expire!";
                MessageBox.Show(this.txtMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /***************************************************************************************** FORM */

        /* EDIT INFORMASI *****************************************************************************************/
        private void txtNamaLengkap_TextChanged(object sender, EventArgs e)
        {
            if(this.txtNamaLengkap.TextLength > 30)
            {
                this.txtErr = "Nama maksimal 30 karakter! \nNama bisa disingkat.";
                this.errorProvider1.SetError(this.txtNamaLengkap, this.txtErr);
                this.txtPassword.Enabled = false;
            }
            else
            {
                this.errorProvider1.SetError(this.txtNamaLengkap, "");
                this.txtPassword.Enabled = true;
            }
        }

        private void btnPilihFoto_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "Image File(*.jpg; *.png) | *.jpg; *.png";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
                this.pbFotoAkun.Image = Image.FromStream(this.openFileDialog1.OpenFile());
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if(mEditData.CekPassword(this.kodeAkun, this.txtPassword.Text) != 1)
            {
                this.txtErr = "Password salah!";
                this.errorProvider1.SetError(this.txtPassword, this.txtErr);
                this.btnSubmit.Enabled = false;
            }
            else
            {
                this.errorProvider1.SetError(this.txtPassword, "");
                this.btnSubmit.Enabled = true;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                this.UpdateInformasi();
        }

        private void ckbTampilkanPass_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbTampilkanPass.Checked)
                this.txtPassword.UseSystemPasswordChar = false;
            else
                this.txtPassword.UseSystemPasswordChar = true;
        }

        private void UpdateInformasi()
        {
            if (this.btnSubmit.Enabled)
            {
                this.txtMsg = "Edit Informasi Data?";
                DialogResult dialogEditInfo = MessageBox.Show(txtMsg, "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogEditInfo == DialogResult.Yes)
                {
                    string namaLengkap = this.txtNamaLengkap.Text;
                    using (System.IO.MemoryStream mStream = new System.IO.MemoryStream())
                    {
                        this.pbFotoAkun.Image.Save(mStream, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] img = mStream.GetBuffer();
                        int editInfo = mEditData.UpdateInformasi(this.kodeAkun, namaLengkap, img);
                        if (editInfo == 1)
                        {
                            this.txtMsg = "Edit Informasi Sukses.";
                            MessageBox.Show(this.txtMsg, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.txtPassword.Clear();
                            this.errorProvider1.SetError(this.txtPassword, "");
                        }
                        else
                        {
                            this.txtMsg = "Edit Informasi Gagal.";
                            MessageBox.Show(this.txtMsg, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.UpdateInformasi();
        }
        /***************************************************************************************** EDIT INFORMASI */

        /* EDIT USERNAME *****************************************************************************************/

        private void txtUsernameBaru2_TextChanged(object sender, EventArgs e)
        {
            if(this.txtUsernameBaru2.TextLength > 15)
            {
                this.txtErr = "Username maksimal 15 karakter!";
                this.errorProvider1.SetError(this.txtUsernameBaru2, this.txtErr);
                this.txtPassword2.Enabled = false;
            }
            else
            {
                this.errorProvider1.SetError(this.txtPassword2, "");
                this.txtPassword2.Enabled = true;
            }
        }

        private void txtPassword2_TextChanged(object sender, EventArgs e)
        {
            if(mEditData.CekPassword(this.kodeAkun, this.txtPassword2.Text) != 1)
            {
                this.txtErr = "Password Salah!";
                this.errorProvider1.SetError(this.txtPassword2, this.txtErr);
                this.btnSubmit2.Enabled = false;
            }
            else
            {
                this.errorProvider1.SetError(this.txtPassword2, "");
                this.btnSubmit2.Enabled = true;
            }
        }

        private void txtPassword2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                this.UpdateUsername();
        }

        private void ckbTampilPass2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbTampilPass2.Checked)
                this.txtPassword2.UseSystemPasswordChar = false;
            else
                this.txtPassword2.UseSystemPasswordChar = true;
        }

        private void UpdateUsername()
        {
            if (this.btnSubmit2.Enabled)
            {
                this.txtMsg = "Edit Username?";
                DialogResult dialogEditUsername = MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dialogEditUsername == DialogResult.Yes)
                {
                    string usBaru = this.txtUsernameBaru2.Text;
                    if (mEditData.UpdateUsername(this.kodeAkun, usBaru) == 1)
                    {
                        this.txtMsg = "Edit Username Sukses.";
                        MessageBox.Show(this.txtMsg, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtPassword2.Clear();
                        this.errorProvider1.SetError(this.txtPassword2, "");
                    }
                    else
                    {
                        this.txtMsg = "Edit Username Gagal.";
                        MessageBox.Show(this.txtMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSubmit2_Click(object sender, EventArgs e)
        {
            this.UpdateUsername();
        }

        /***************************************************************************************** EDIT USERNAME */

        /* EDIT PASSWORD *****************************************************************************************/
        private void txtPassSaatIni3_TextChanged(object sender, EventArgs e)
        {
            if(mEditData.CekPassword(this.kodeAkun, this.txtPassSaatIni3.Text) != 1)
            {
                this.txtErr = "Password Salah!";
                this.errorProvider1.SetError(this.txtPassSaatIni3, this.txtErr);
                this.txtPassBaru3.Enabled = false;
            }
            else
            {
                this.errorProvider1.SetError(this.txtPassSaatIni3, "");
                this.txtPassBaru3.Enabled = true;
            }
        }

        private void txtPassBaru3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtPassBaru3.Text))
                this.btnSubmit3.Enabled = false;
            else
            {
                if(this.txtPassBaru3.TextLength > 225)
                {
                    this.txtErr = "Password maksimal 225 karakter!";
                    this.errorProvider1.SetError(this.txtPassBaru3, this.txtErr);
                    this.btnSubmit3.Enabled = false;
                }
                else
                {
                    this.errorProvider1.SetError(this.txtPassBaru3, "");
                    this.btnSubmit3.Enabled = true;
                }
            } 
        }

        private void ckbTampilPass3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbTampilPass3.Checked)
            {
                this.txtPassSaatIni3.UseSystemPasswordChar = false;
                this.txtPassBaru3.UseSystemPasswordChar = false;
            }
            else
            {
                this.txtPassSaatIni3.UseSystemPasswordChar = true;
                this.txtPassBaru3.UseSystemPasswordChar = true;
            }
        }

        private void UpdatePassword()
        {
            if (this.btnSubmit3.Enabled)
            {
                this.txtMsg = "Edit Password?";
                DialogResult dialogEditPass = MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dialogEditPass == DialogResult.Yes)
                {
                    string passBaru = this.txtPassBaru3.Text;
                    if(this.mEditData.UpdatePassword(this.kodeAkun, passBaru) == 1)
                    {
                        this.txtMsg = "Edit Password Sukses.";
                        MessageBox.Show(this.txtMsg, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtPassSaatIni3.Clear();
                        this.errorProvider1.SetError(this.txtPassSaatIni3, "");
                        this.txtPassBaru3.Clear();
                    }
                    else
                    {
                        this.txtMsg = "Edit Password Gagal.";
                        MessageBox.Show(this.txtMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtPassBaru3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                this.UpdatePassword();
        }

        private void btnSubmit3_Click(object sender, EventArgs e)
        {
            this.UpdatePassword();
        }
        /***************************************************************************************** EDIT PASSWORD */
    }
}