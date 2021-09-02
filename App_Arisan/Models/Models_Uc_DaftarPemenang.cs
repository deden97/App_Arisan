//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace App_Arisan.Models
{
    class Models_Uc_DaftarPemenang
    {
        Config.ConnectDb connectDb;
        SqlConnection sqlCon;
        SqlCommand sqlCmd;
        SqlDataAdapter sqlDa;
        SqlDataReader sqlDr;
        DataTable dt;
        private string query;

        public Models_Uc_DaftarPemenang()
        {
            this.connectDb = new Config.ConnectDb();
            this.sqlCon = this.connectDb.GetConnection();
        }

        public DataTable ListKelFromListView(string kodeBendahara, string searchName = "")
        {
            try
            {
                this.sqlCon.Open();
                this.query = "SELECT KODE_KELOMPOK, NAMA_KELOMPOK, JUMLAH_ANGGOTA, STATUS_KELOMPOK " +
                             "FROM TB_KELOMPOK_ARISAN " +
                             $"WHERE BENDAHARA = '{kodeBendahara}' AND NAMA_KELOMPOK LIKE '%{searchName}%'";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.dt = new DataTable();
                this.sqlDa = new SqlDataAdapter(this.sqlCmd);
                this.sqlDa.Fill(dt);
                return this.dt;
            }
            finally
            {
                this.sqlCon.Close();
            }
        }

        public DataTable GetListPemenang(string kodeKel)
        {
            try
            {
                this.sqlCon.Open();
                this.query = $"EXEC PROC_SHOW_LIST_PEMENANG '{kodeKel}'";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlDa = new SqlDataAdapter(this.sqlCmd);
                this.dt = new DataTable();
                this.sqlDa.Fill(this.dt);
                return this.dt;
            }
            finally
            {
                this.sqlCon.Close();
            }
        }

        public string GetNamaBendahara(string kodeBendahara)
        {
            try
            {
                this.sqlCon.Open();
                this.query = "SELECT NAMA_LENGKAP FROM TB_AKUN_BENDAHARA " +
                             $"WHERE KODE_AKUN = '{kodeBendahara}'";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlDr = this.sqlCmd.ExecuteReader();
                this.sqlDr.Read();
                return this.sqlDr.GetString(0) + $" ({kodeBendahara})";
            }
            finally
            {
                this.sqlCon.Close();
                this.sqlDr.Close();
            }
        }
    }
}
