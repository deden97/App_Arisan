using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace App_Arisan.ReportView
{
    public partial class FrmRptDaftarPemenangArisan : Form
    {
        private enum prm { Bendahara, KodeKel, NamaKel, StsKel, Tgl, JmlPemenang, TotPemenang }
        private string[] arrParam = new string[Convert.ToInt32(prm.TotPemenang + 1)];

        public FrmRptDaftarPemenangArisan(List<string> param)
        {
            InitializeComponent();
            for (int i = 0; i < arrParam.Length; i++)
                arrParam[i] = param[i];
        }

        private void FrmRptDaftarPemenangArisan_Load(object sender, EventArgs e)
        {
            this.pROC_SHOW_LIST_PEMENANGTableAdapter.Fill(this.dS_DaftarPemenangArisan.PROC_SHOW_LIST_PEMENANG, this.arrParam[(int)prm.KodeKel]);
            ReportParameter[] param = new ReportParameter[]
            {
                new ReportParameter("bendahara", this.arrParam[(int)prm.Bendahara]),
                new ReportParameter("nmKel", this.arrParam[(int)prm.NamaKel] + $" ({this.arrParam[(int)prm.KodeKel]})"),
                new ReportParameter("tglUpdate", this.arrParam[(int)prm.Tgl]),
                new ReportParameter("stsKel", this.arrParam[(int)prm.StsKel]),
                new ReportParameter("jmlPemenang", this.arrParam[(int)prm.JmlPemenang]),
                new ReportParameter("totPemenang", this.arrParam[(int)prm.TotPemenang])
            };
            this.reportViewer1.LocalReport.SetParameters(param);
            this.reportViewer1.RefreshReport();
        }
    }
}
