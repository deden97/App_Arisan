
namespace App_Arisan.ReportView
{
    partial class FrmRptDaftarPemenangArisan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.PROC_SHOW_LIST_PEMENANGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dS_DaftarPemenangArisan = new App_Arisan.DataSet.DS_DaftarPemenangArisan();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pROCSHOWLISTPEMENANGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pROC_SHOW_LIST_PEMENANGTableAdapter = new App_Arisan.DataSet.DS_DaftarPemenangArisanTableAdapters.PROC_SHOW_LIST_PEMENANGTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PROC_SHOW_LIST_PEMENANGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_DaftarPemenangArisan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pROCSHOWLISTPEMENANGBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PROC_SHOW_LIST_PEMENANGBindingSource
            // 
            this.PROC_SHOW_LIST_PEMENANGBindingSource.DataMember = "PROC_SHOW_LIST_PEMENANG";
            this.PROC_SHOW_LIST_PEMENANGBindingSource.DataSource = this.dS_DaftarPemenangArisan;
            // 
            // dS_DaftarPemenangArisan
            // 
            this.dS_DaftarPemenangArisan.DataSetName = "DS_DaftarPemenangArisan";
            this.dS_DaftarPemenangArisan.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ListPemenangArisan";
            reportDataSource1.Value = this.PROC_SHOW_LIST_PEMENANGBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "App_Arisan.ReportRDLC.rptDaftarPemenangArisan.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1075, 1043);
            this.reportViewer1.TabIndex = 0;
            // 
            // pROCSHOWLISTPEMENANGBindingSource
            // 
            this.pROCSHOWLISTPEMENANGBindingSource.DataMember = "PROC_SHOW_LIST_PEMENANG";
            this.pROCSHOWLISTPEMENANGBindingSource.DataSource = this.dS_DaftarPemenangArisan;
            // 
            // pROC_SHOW_LIST_PEMENANGTableAdapter
            // 
            this.pROC_SHOW_LIST_PEMENANGTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRptDaftarPemenangArisan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 1043);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmRptDaftarPemenangArisan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "App Arisan - Daftar Pemenang";
            this.Load += new System.EventHandler(this.FrmRptDaftarPemenangArisan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PROC_SHOW_LIST_PEMENANGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_DaftarPemenangArisan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pROCSHOWLISTPEMENANGBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PROC_SHOW_LIST_PEMENANGBindingSource;
        private DataSet.DS_DaftarPemenangArisan dS_DaftarPemenangArisan;
        private System.Windows.Forms.BindingSource pROCSHOWLISTPEMENANGBindingSource;
        private DataSet.DS_DaftarPemenangArisanTableAdapters.PROC_SHOW_LIST_PEMENANGTableAdapter pROC_SHOW_LIST_PEMENANGTableAdapter;
    }
}