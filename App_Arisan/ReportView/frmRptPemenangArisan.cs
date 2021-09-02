using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Arisan.ReportView
{
    public partial class frmRptPemenangArisan : Form
    {
        List<string> dtRpt/* = new List<string>()*/;

        public frmRptPemenangArisan(List<string> dtRpt)
        {
            InitializeComponent();
            this.dtRpt = dtRpt;
        }

        private void frmRptPemenangArisan_Load(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportParameter[] param = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("pTglUndian", this.dtRpt[0]),
                new Microsoft.Reporting.WinForms.ReportParameter("pKelArisan", this.dtRpt[1]),
                new Microsoft.Reporting.WinForms.ReportParameter("pBendahara", this.dtRpt[2]),
                new Microsoft.Reporting.WinForms.ReportParameter("pTotalUang", this.dtRpt[3]),
                new Microsoft.Reporting.WinForms.ReportParameter("pUndianKe", this.dtRpt[4]),
                new Microsoft.Reporting.WinForms.ReportParameter("pPemenang", this.dtRpt[5]),
                new Microsoft.Reporting.WinForms.ReportParameter("pNoTelp", this.dtRpt[6])
            };
            this.reportViewer1.LocalReport.SetParameters(param);
            this.reportViewer1.RefreshReport();
        }
    }
}
