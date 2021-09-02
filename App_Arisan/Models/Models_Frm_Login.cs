using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace App_Arisan.Models
{
    class Models_Frm_Login
    {
        Config.ConnectDb conDb;
        SqlConnection sqlCon;
        SqlCommand sqlCmd;
        SqlDataReader sqlDr;
        SqlDataAdapter sqlDa;
        DataTable dt;
        private string query;

        public Models_Frm_Login()
        {
            this.conDb = new Config.ConnectDb();
            this.sqlCon = conDb.GetConnection();
        }
        
        // LOGIN
        public object ValidasiLogin(string us, string ps)
        {
            int output = 0;
            try
            {
                this.sqlCon.Open();
                this.query = "SELECT KODE_AKUN FROM TB_AKUN_BENDAHARA WHERE USERNAME = @us AND PASSWORD_AKUN = @ps";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlCmd.Parameters.AddWithValue("@us", us);
                this.sqlCmd.Parameters.AddWithValue("@ps", ps);
                this.sqlDr = this.sqlCmd.ExecuteReader();
                while (this.sqlDr.Read())
                    output++;
            }
            catch(Exception err)
            {
                return err;
            }
            finally
            {
                this.sqlCon.Close();
            }

            return output;
        }

        // AKTIFKAN STATUS AKUN
        public void AktifkanAkun(string kodeAkun)
        {
            try
            {
                this.sqlCon.Open();
                this.query = "UPDATE TB_AKUN_BENDAHARA" +
                             " SET STATUS_AKUN = 'TRUE'" +
                             " WHERE KODE_AKUN = @KODE_AKUN";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlCmd.Parameters.AddWithValue("@KODE_AKUN", kodeAkun);
                this.sqlCmd.ExecuteNonQuery();
            }
            finally
            {
                this.sqlCon.Close();
            }
        }

        // GET INFO AKUN/BENDAHARA
        public DataTable GetInfoAkun(string us, string ps)
        {
            try
            {
                this.sqlCon.Open();
                this.query = "SELECT KODE_AKUN, NAMA_LENGKAP, FOTO" +
                             " FROM TB_AKUN_BENDAHARA" +
                             " WHERE USERNAME = @us AND PASSWORD_AKUN = @ps";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlCmd.Parameters.AddWithValue("@us", us);
                this.sqlCmd.Parameters.AddWithValue("@ps", ps);
                this.sqlDa = new SqlDataAdapter(this.sqlCmd);
                this.dt = new DataTable();
                this.sqlDa.Fill(this.dt);
            }
            catch(Exception err)
            {
                err.ToString();
            }
            finally
            {
                this.sqlCon.Close();
            }

            return this.dt;
        }
    }
}
