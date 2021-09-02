//using System;
//using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace App_Arisan.Models
{
    class Models_Frm_EditData
    {
        Config.ConnectDb connectDb;
        SqlConnection sqlCon;
        SqlCommand sqlCmd;
        SqlDataReader sqlDr;
        SqlDataAdapter sqlDa;
        DataTable dt;
        private string query;

        public Models_Frm_EditData()
        {
            this.connectDb = new Config.ConnectDb();
            this.sqlCon = connectDb.GetConnection();
        }

        public int CekKodeAkun(string kodeAkun)
        {
            int output = 0;
            try
            {
                this.sqlCon.Open();
                this.query = "SELECT KODE_AKUN FROM TB_AKUN_BENDAHARA WHERE KODE_AKUN = @KODE";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlCmd.Parameters.AddWithValue("@KODE", kodeAkun);
                this.sqlDr = this.sqlCmd.ExecuteReader();
                while (this.sqlDr.Read())
                    output++;
                this.sqlDr.Close();
            }
            finally
            {
                this.sqlCon.Close();
            }

            return output;
        }

        public bool CekStatusAkun(string kodeAkun)
        {
            try
            {
                this.sqlCon.Open();
                this.query = "SELECT STATUS_AKUN FROM TB_AKUN_BENDAHARA " +
                             $"WHERE KODE_AKUN = '{kodeAkun}'";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlDr = this.sqlCmd.ExecuteReader();
                this.sqlDr.Read();
                if (this.sqlDr.GetString(0) == "FALSE")
                    return false;

                return true;
            }
            finally
            {
                this.sqlCon.Close();
                this.sqlDr.Close();
            }
        }

        public int CekPassword(string kodeAkun, string password)
        {
            int output = 0;
            try
            {
                this.sqlCon.Open();
                this.query = "SELECT KODE_AKUN FROM TB_AKUN_BENDAHARA " +
                             "WHERE KODE_AKUN = @KODE AND PASSWORD_AKUN = @PASSWORD_AKUN";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlCmd.Parameters.AddWithValue("@KODE", kodeAkun);
                this.sqlCmd.Parameters.AddWithValue("@PASSWORD_AKUN", password);
                this.sqlDr = this.sqlCmd.ExecuteReader();
                while (this.sqlDr.Read())
                    output++;
                this.sqlDr.Close();
            }
            finally
            {
                this.sqlCon.Close();
            }

            return output;
        }

        public DataTable GetInfoLengkapAkun(string kodeAkun)
        {
            try
            {
                this.sqlCon.Open();
                this.query = "SELECT NAMA_LENGKAP, FOTO FROM TB_AKUN_BENDAHARA WHERE KODE_AKUN = @KODE";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlCmd.Parameters.AddWithValue("@KODE", kodeAkun);
                this.sqlDa = new SqlDataAdapter(this.sqlCmd);
                this.dt = new DataTable();
                this.sqlDa.Fill(this.dt);
            }
            finally
            {
                this.sqlCon.Close();
            }

            return this.dt;
        }

        public int UpdateInformasi(string kodeAkun, string namaLengkap, byte[]img)
        {
            int output = 0;
            try
            {
                this.sqlCon.Open();
                this.query = "UPDATE TB_AKUN_BENDAHARA " +
                             "SET NAMA_LENGKAP = @NAMA_LENGKAP, " +
                             "FOTO = @FOTO " +
                             "WHERE KODE_AKUN = @KODE_AKUN";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlCmd.Parameters.AddWithValue("@NAMA_LENGKAP", namaLengkap);
                this.sqlCmd.Parameters.AddWithValue("@FOTO", img);
                this.sqlCmd.Parameters.AddWithValue("@KODE_AKUN", kodeAkun);
                output = this.sqlCmd.ExecuteNonQuery();
            }
            finally
            {
                this.sqlCon.Close();
            }

            return output;
        }

        public int UpdateUsername(string kodeAkun, string username)
        {
            int output = 0;
            try
            {
                this.sqlCon.Open();
                this.query = "UPDATE TB_AKUN_BENDAHARA " +
                             "SET USERNAME = @USERNAME " +
                             "WHERE KODE_AKUN = @KODE_AKUN";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlCmd.Parameters.AddWithValue("@USERNAME", username);
                this.sqlCmd.Parameters.AddWithValue("@KODE_AKUN", kodeAkun);
                output = this.sqlCmd.ExecuteNonQuery();
            }
            finally
            {
                this.sqlCon.Close();
            }

            return output;
        }

        public int UpdatePassword(string kodeAkun, string password)
        {
            int output = 0;
            try
            {
                this.sqlCon.Open();
                this.query = "UPDATE TB_AKUN_BENDAHARA " +
                             "SET PASSWORD_AKUN = @PASSWORD_BARU " +
                             "WHERE KODE_AKUN = @KODE_AKUN";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlCmd.Parameters.AddWithValue("@PASSWORD_BARU", password);
                this.sqlCmd.Parameters.AddWithValue("@KODE_AKUN", kodeAkun);
                output = this.sqlCmd.ExecuteNonQuery();
            }
            finally
            {
                this.sqlCon.Close();
            }

            return output;
        }
    }
}
