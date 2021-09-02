//using System;
//using System.Collections.Generic;
using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace App_Arisan.Models
{
    class Models_Frm_DaftarAkun
    {
        Config.ConnectDb connectDb;
        SqlConnection sqlCon;
        SqlCommand sqlCmd;
        SqlDataReader sqlDr;
        private string query;

        public Models_Frm_DaftarAkun()
        {
            this.connectDb = new Config.ConnectDb();
            this.sqlCon = this.connectDb.GetConnection();
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

        public int GetJumlahKodeAkun()
        {
            int jml = 0;
            try
            {
                this.sqlCon.Open();
                this.query = "SELECT KODE_AKUN FROM TB_AKUN_BENDAHARA";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlDr = this.sqlCmd.ExecuteReader();
                while (this.sqlDr.Read())
                    jml++;
                this.sqlDr.Close();
            }
            finally
            {
                this.sqlCon.Close();
            }

            return jml;
        }

        public int DaftarAkun(string kodeAkun, string tglDaftar, string namaLengkap, byte[] foto, string username, string password)
        {
            int output = 0;
            try
            {
                this.sqlCon.Open();
                this.query = "EXEC PROC_DAFTAR_AKUN @KODE_AKUN, @TGL_DAFTAR," +
                             " @NAMA_LENGKAP, @FOTO, @USERNAME, @PASSWORD";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlCmd.Parameters.AddWithValue("@KODE_AKUN", kodeAkun);
                this.sqlCmd.Parameters.AddWithValue("@TGL_DAFTAR", tglDaftar);
                this.sqlCmd.Parameters.AddWithValue("@NAMA_LENGKAP", namaLengkap);
                this.sqlCmd.Parameters.AddWithValue("@FOTO", foto);
                this.sqlCmd.Parameters.AddWithValue("@USERNAME", username);
                this.sqlCmd.Parameters.AddWithValue("@PASSWORD", password);
                output = this.sqlCmd.ExecuteNonQuery();
            }
            finally
            {
                this.sqlCon.Close();
            }

            return output;
        }

        //public byte[] GetImgAkunDefault()
        //{
        //    byte[] img = null;
        //    try
        //    {
        //        this.sqlCon.Open();
        //        this.query = "SELECT IMG FROM TB_IMG WHERE NAMA = @NAMA";
        //        this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
        //        this.sqlCmd.Parameters.AddWithValue("@NAMA", "USER");
        //        this.sqlDr = this.sqlCmd.ExecuteReader();
        //        this.sqlDr.Read();
        //        img = (byte[])this.sqlDr.GetValue(0);
        //    }
        //    finally
        //    {
        //        this.sqlCon.Close();
        //    }

        //    return img;
        //}
    }
}
