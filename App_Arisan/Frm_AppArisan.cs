using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
using System.Windows.Forms;
using App_Arisan.User_Control;

namespace App_Arisan
{
    public partial class Frm_AppArisan : Form
    {
        Frm_Login frmLogin;
        Frm_EditData frmEditDt;
        Frm_DaftarAkun daftarAkun;
        Uc_Pembayaran menuPembayaran = Uc_Pembayaran.Instance;
        Uc_BuatKelompok menuBuatKel = Uc_BuatKelompok.Instance;
        Uc_UndiArisan menuUndiArisan = Uc_UndiArisan.Instance;
        Uc_DaftarPemenang menuDaftarPemenang = Uc_DaftarPemenang.Instance;
        Models.Models_Frm_AppArisan mArisan = new Models.Models_Frm_AppArisan();
        private string kodeAkun;
        private bool titik2 = false;
        private int waktu;
        private enum BtnMenu { btnUndiArisan, btnPembayaran, btnBuatKelompok, btnDaftarPemenang, UnclickAll }
        private BtnMenu kdsMenu;
        private enum Log { Login, Logout }
        private Log kdsLog;
        private string txtMsg;

        private int yLoc, xLoc, pnlUtamaWitdh;
        public Frm_AppArisan()
        {
            InitializeComponent();
            this.kdsLog = Log.Logout;
        }

        /* FORM ******************************************************************************************/
        private void Frm_AppArisan_Load(object sender, EventArgs e)
        {
            this.tJam.Start();
            this.tTitik2.Start();
            this.kdsLog = Log.Logout;
            this.StatusLog(this.kdsLog);
            this.btnLogin_Click(sender, e);

            yLoc = this.pnlUtama.Location.Y;
            xLoc = this.pnlUtama.Location.X;
            this.pnlUtamaWitdh = this.pnlUtama.Width;
        }

        private void Frm_AppArisan_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.kdsLog = Log.Logout;
            this.StatusLog(this.kdsLog);
            this.RemoveMenu();
        }
        /****************************************************************************************** FORM */

        /* LOGIN/LOGOUT **********************************************************************************/
        private void StatusLog(Log kdsLog)
        {
            if(kdsLog == Log.Login)
            {
                this.kodeAkun = this.frmLogin.Kode;
                this.lblKodeAkun.Text = this.kodeAkun;
                this.lblNamaLengkap.Text = this.frmLogin.NamaLengkap;
                using (System.IO.MemoryStream mStream = new System.IO.MemoryStream(this.frmLogin.Foto))
                {
                    this.pbFotoAkun.Image = Image.FromStream(mStream);
                }
                this.btnLogin.Text = "Logout";
                this.pnlMenu.Enabled = true;
                this.btnDaftarAkun.Visible = true;
                this.btnEditData.Visible = true;
                this.pnlBtnMenu.Visible = true;
            }
            else
            {
                this.lblKodeAkun.Text = "";
                this.lblNamaLengkap.Text = "";
                if (this.pbFotoAkun.Image != null)
                {
                    this.pbFotoAkun.Image.Dispose();
                    this.pbFotoAkun.Image = null;
                }  
                this.btnLogin.Text = "Login";
                this.pnlMenu.Enabled = false;
                if (!String.IsNullOrEmpty(this.kodeAkun))
                {
                    if (this.kodeAkun.Length >= 11)
                        this.mArisan.LogoutAkun(this.kodeAkun);
                }
                this.btnDaftarAkun.Visible = false;
                this.btnEditData.Visible = false;
                this.pnlBtnMenu.Visible = false;
            }

            this.kdsMenu = BtnMenu.UnclickAll;
            this.PosisiButtonMenu(this.kdsMenu);
        }

        private void RemoveMenu()
        {
            Control[] ctrl = { this.menuPembayaran, this.menuBuatKel, this.menuUndiArisan, this.menuDaftarPemenang };
            for (int idx = 0; idx < ctrl.Length; idx++)
            {
                if (this.pnlShowMenu.Controls.Contains(ctrl[idx]))
                    this.pnlShowMenu.Controls.Remove(ctrl[idx]);
                //GC.Collect();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (kdsLog == Log.Logout)
            {
                if (!Application.OpenForms.OfType<Frm_Login>().Any())
                {
                    this.tLogin.Start();
                    this.frmLogin = new Frm_Login();
                    this.frmLogin.Show();
                }
                else
                    this.frmLogin.Show();
            }
            else
            {
                this.txtMsg = "Anda yakin akan logout?";
                DialogResult dialogLogout = MessageBox.Show(this.txtMsg, "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dialogLogout == DialogResult.Yes)
                {
                    this.kdsLog = Log.Logout;
                    this.StatusLog(this.kdsLog);
                    this.RemoveMenu();
                }
            }
        }

        private void tLogin_Tick(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<Frm_Login>().Any())
            {
                if (this.frmLogin.Login)
                {
                    this.kdsLog = Log.Login;
                    this.StatusLog(this.kdsLog);
                    this.frmLogin.Close();
                    this.tLogin.Stop();
                }

                if (this.frmLogin.CancelLogin)
                {
                    this.frmLogin.Close();
                    this.tLogin.Stop();
                }
            }
            else
            {
                this.frmLogin.Close();
                this.tLogin.Stop();
            }
        }
        /********************************************************************************** LOGIN/LOGOUT */

        private void btnDaftarAkun_Click(object sender, EventArgs e)
        {
            if (!Application.OpenForms.OfType<Frm_DaftarAkun>().Any())
            {
                this.daftarAkun = new Frm_DaftarAkun(this.kodeAkun);
                this.daftarAkun.Show();
            }
            else
                this.daftarAkun.Activate();
        }

        private void btnEditData_Click(object sender, EventArgs e)
        {
            if (!Application.OpenForms.OfType<Frm_EditData>().Any())
            {
                this.frmEditDt = new Frm_EditData(this.kodeAkun);
                this.frmEditDt.Show();
            }
            else
                this.frmEditDt.Activate();
        }

        /* WAKTU *****************************************************************************************/
        private void tJam_Tick(object sender, EventArgs e)
        {
            this.lblJam.Text = DateTime.Now.ToString("hh");
            this.waktu = Convert.ToInt32(DateTime.Now.ToString("HH"));
            if (this.waktu >= 0 && this.waktu < 12)
                this.lblMenit.Text = DateTime.Now.ToString("mm") + " AM";
            else
                this.lblMenit.Text = DateTime.Now.ToString("mm") + " PM";
        }

        private void tTitik2_Tick(object sender, EventArgs e)
        {
            this.titik2 = !this.titik2;
            this.lblTitik2.Visible = this.titik2;
        }
        /***************************************************************************************** WAKTU */

        /*BUTTON MENU ************************************************************************************/

        private void ClickButtonMenu(Button btn)
        {
            btn.BackColor = Color.Transparent;
            this.pnlBtnMenu.Left = btn.Left;
            this.pnlBtnMenu.Width = btn.Width;
        }

        private void UnclickButtonMenu(Button btn)
        {
            btn.BackColor = Color.Peru;
        }

        private void PosisiButtonMenu(BtnMenu kds)
        {
            // click
            switch (kds)
            {
                case BtnMenu.btnUndiArisan:
                    this.ClickButtonMenu(this.btnUndiArisan);
                    break;
                case BtnMenu.btnPembayaran:
                    this.ClickButtonMenu(this.btnPembayaran);
                    break;
                case BtnMenu.btnBuatKelompok:
                    this.ClickButtonMenu(this.btnBuatKelompok);
                    break;
                case BtnMenu.btnDaftarPemenang:
                    this.ClickButtonMenu(this.btnDaftarPemenang);
                    break;
            }

            // unclick
            for(int idx = 0; idx <= 3; idx++)
            {
                if(idx != Convert.ToInt32(kds))
                {
                    switch (idx)
                    {
                        case (int)BtnMenu.btnUndiArisan:
                            this.UnclickButtonMenu(this.btnUndiArisan);
                            break;
                        case (int)BtnMenu.btnPembayaran:
                            this.UnclickButtonMenu(this.btnPembayaran);
                            break;
                        case (int)BtnMenu.btnBuatKelompok:
                            this.UnclickButtonMenu(this.btnBuatKelompok);
                            break;
                        case (int)BtnMenu.btnDaftarPemenang:
                            this.UnclickButtonMenu(this.btnDaftarPemenang);
                            break;
                    }
                }
            }
        }

        private bool ShowMenuUserControl(Control nControl)
        {
            if (!this.pnlShowMenu.Controls.Contains(nControl))
            {
                this.pnlShowMenu.Controls.Add(nControl);
                nControl.Dock = DockStyle.Fill;
                nControl.BringToFront();
                return true;
            }
            else
                nControl.BringToFront();

            return false;
        }

        private void btnUndiArisan_Click(object sender, EventArgs e)
        {
            this.kdsMenu = BtnMenu.btnUndiArisan;
            this.PosisiButtonMenu(this.kdsMenu);

            if (this.ShowMenuUserControl(this.menuUndiArisan))
                this.menuUndiArisan.SetKodeBendahara = this.kodeAkun;
            else
                this.menuUndiArisan.ResfreshForm();
        }

        private void btnPembayaran_Click(object sender, EventArgs e)
        {
            this.kdsMenu = BtnMenu.btnPembayaran;
            this.PosisiButtonMenu(this.kdsMenu);

            if (this.ShowMenuUserControl(this.menuPembayaran))
                this.menuPembayaran.SetKodeBendahara = this.kodeAkun;
            else
                this.menuPembayaran.ResfreshForm();
        }

        private void btnBuatKelompok_Click(object sender, EventArgs e)
        {
            this.kdsMenu = BtnMenu.btnBuatKelompok;
            this.PosisiButtonMenu(this.kdsMenu);

            if (this.ShowMenuUserControl(this.menuBuatKel))
                this.menuBuatKel.SetKodeBendahara = this.kodeAkun;
        }

        private void btnDaftarPemenang_Click(object sender, EventArgs e)
        {
            this.kdsMenu = BtnMenu.btnDaftarPemenang;
            this.PosisiButtonMenu(this.kdsMenu);

            if (this.ShowMenuUserControl(this.menuDaftarPemenang))
                this.menuDaftarPemenang.SetKodeBendahara = this.kodeAkun;
            else
                this.menuDaftarPemenang.RefreshForm();
        }

        private void AnchorPnlUtama(bool full = true)
        {
            this.pnlUtama.Location = new Point(this.xLoc, yLoc);
            this.pnlUtama.Anchor = AnchorStyles.Left;
            this.pnlUtama.Anchor = AnchorStyles.Top;
            this.pnlUtama.Anchor = AnchorStyles.Bottom;
            if (full)
                this.pnlUtama.Anchor = AnchorStyles.Right;
        }

        //private void ResizeForm()
        //{
        //    this.AnchorPnlUtama();
        //    if (this.Width < this.pnlUtamaWitdh)
        //    {
        //        this.AnchorPnlUtama(false);
        //        this.hScrollBar1.Visible = true;
        //        this.hScrollBar1.Maximum = (this.pnlUtamaWitdh - this.Width) + 115;
        //        this.hScrollBar1.Minimum = this.xLoc;
        //        this.hScrollBar1.LargeChange = 100;
        //    }
        //    else if(this.Width >= this.pnlUtamaWitdh)
        //    {
        //        this.AnchorPnlUtama();
        //        //this.hScrollBar1.Visible = false;
        //    }
        //}
        /************************************************************************************ BUTTON MENU */
    }
}