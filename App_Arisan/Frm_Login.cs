using System;
//using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Arisan
{
    public partial class Frm_Login : Form
    {
        public bool Login { get; set; }
        public bool CancelLogin { get; set; }
        public string Kode { get; set; }
        public string NamaLengkap { get; set; }
        public byte[] Foto { get; set; }
        Models.Models_Frm_Login mLogin = new Models.Models_Frm_Login();

        public Frm_Login()
        {
            InitializeComponent();
        }

        private void ckbTampilkanPass_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbTampilkanPass.Checked)
                this.txtPassword.UseSystemPasswordChar = false;
            else
                this.txtPassword.UseSystemPasswordChar = true;
        }

        private void ValidasiLog()
        {
            string us = txtUsername.Text;
            string ps = txtPassword.Text;
            if(Convert.ToInt32(this.mLogin.ValidasiLogin(us, ps)) == 1)
            {
                DataTable dtAkun = this.mLogin.GetInfoAkun(us, ps);
                foreach(DataRow dtRow in dtAkun.Rows)
                {
                    this.Kode = dtRow["KODE_AKUN"].ToString();
                    this.NamaLengkap = dtRow["NAMA_LENGKAP"].ToString();
                    this.Foto = (byte[])dtRow["FOTO"];
                    this.mLogin.AktifkanAkun(this.Kode);
                }
                this.Login = true;
            }
            else
            {
                string txtMsg = "Username atau Password salah! \nPeriksa kembali Username dan Password Anda.";
                MessageBox.Show(txtMsg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                ValidasiLog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ValidasiLog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.CancelLogin = true;
        }
    }
}