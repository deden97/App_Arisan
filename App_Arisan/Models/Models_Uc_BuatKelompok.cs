//using System;
//using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace App_Arisan.Models
{
    class Models_Uc_BuatKelompok
    {
        Config.ConnectDb connectDb;
        SqlConnection sqlCon;
        SqlCommand sqlCmd;
        SqlDataReader sqlDr;
        SqlDataAdapter sqlDa;
        DataTable dt;
        private string query;

        public Models_Uc_BuatKelompok()
        {
            this.connectDb = new Config.ConnectDb();
            this.sqlCon = this.connectDb.GetConnection();
        }

        public string GetNamaBendahara(string kodeBendahara)
        {
            string output = "";
            try
            {
                this.sqlCon.Open();
                this.query = "SELECT NAMA_LENGKAP FROM TB_AKUN_BENDAHARA WHERE KODE_AKUN = @KODE_AKUN";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlCmd.Parameters.AddWithValue("@KODE_AKUN", kodeBendahara);
                this.sqlDr = this.sqlCmd.ExecuteReader();
                this.sqlDr.Read();
                output = this.sqlDr.GetString(0);
                this.sqlDr.Close();
            }
            finally
            {
                this.sqlCon.Close();
            }

            return output;
        }

        // return -> 'false' jika kode sama.
        public bool CekKodeKelompokBaru(string kodeKelBaru)
        {
            try
            {
                this.sqlCon.Open();
                this.query = "SELECT KODE_KELOMPOK FROM TB_KELOMPOK_ARISAN " +
                             $"WHERE KODE_KELOMPOK = '{kodeKelBaru}'";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlDr = this.sqlCmd.ExecuteReader();
                if (this.sqlDr.Read())
                    return false;
                this.sqlDr.Close();
            }
            finally
            {
                this.sqlCon.Close();
            }
            return true;
        }

        public DataTable GetListAnggotaTerdaftar(string kodeBendahara)
        {
            try
            {
                this.sqlCon.Open();
                this.query = "SELECT TB_ANGGOTA.KODE_ANGGOTA, " +
                             "TB_ANGGOTA.KODE_ANGGOTA + ' | ' + TB_ANGGOTA.NAMA_ANGGOTA + ' | ' + TB_ANGGOTA.NO_TELP AS[LIST_ANGGOTA] " +
                             "FROM TB_ANGGOTA_TERDAFTAR_KELOMPOK " +
                             "INNER JOIN TB_ANGGOTA " +
                             "ON TB_ANGGOTA_TERDAFTAR_KELOMPOK.KODE_ANGGOTA = TB_ANGGOTA.KODE_ANGGOTA " +
                             "INNER JOIN TB_KELOMPOK_ARISAN " +
                             "ON TB_ANGGOTA_TERDAFTAR_KELOMPOK.KODE_KELOMPOK = TB_KELOMPOK_ARISAN.KODE_KELOMPOK " +
                             $"WHERE TB_KELOMPOK_ARISAN.BENDAHARA = '{kodeBendahara}'";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlDa = new SqlDataAdapter(this.sqlCmd);
                this.dt = new DataTable();
                this.sqlDa.Fill(this.dt);
            }
            finally
            {
                this.sqlCon.Close();
            }

            return dt;
        }

        public DataTable GetListAnggotaTerdaftarBySearch(string namaAnggota)
        {
            try
            {
                this.sqlCon.Open();
                this.query = "SELECT KODE_ANGGOTA, " +
                             "KODE_ANGGOTA + ' | ' + NAMA_ANGGOTA + ' | ' + NO_TELP AS[LIST_ANGGOTA] " +
                             $"FROM TB_ANGGOTA WHERE NAMA_ANGGOTA LIKE '%{namaAnggota}%'";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlDa = new SqlDataAdapter(this.sqlCmd);
                this.dt = new DataTable();
                this.sqlDa.Fill(this.dt);
            }
            finally
            {
                this.sqlCon.Close();
            }

            return dt;
        }

        public int HitungJmlKodeAnggota(string kodeAnggota)
        {
            int output = 0;
            try
            {
                this.sqlCon.Open();
                this.query = $"SELECT KODE_ANGGOTA FROM TB_ANGGOTA WHERE KODE_ANGGOTA LIKE '%{kodeAnggota}%'";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlDr = this.sqlCmd.ExecuteReader();
                while (this.sqlDr.Read())
                    output++;
            }
            finally
            {
                this.sqlDr.Close();
                this.sqlCon.Close();
            }

            return output;
        }

        public DataTable GetInfoAnggotaTerdaftar(string kodeAnggota)
        {
            try
            {
                this.sqlCon.Open();
                this.query = "SELECT KODE_ANGGOTA, NAMA_ANGGOTA, " +
                             "NO_TELP, FOTO_ANGGOTA FROM TB_ANGGOTA " +
                             $"WHERE KODE_ANGGOTA = '{kodeAnggota}'";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
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

        public int CekKodeAnggota(string kodeAnggota)
        {
            int output = 0;
            try
            {
                this.sqlCon.Open();
                this.query = $"SELECT KODE_ANGGOTA FROM TB_ANGGOTA WHERE KODE_ANGGOTA = '{kodeAnggota}'";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlDr = this.sqlCmd.ExecuteReader();
                if (this.sqlDr.Read())
                    output++;
            }
            finally
            {
                this.sqlDr.Close();
                this.sqlCon.Close();
            }

            return output;
        }

        public int InputAnggota(string kodeAnggota, string namaAnggota, string tglTerdaftar, string noTelp, byte[] foto)
        {
            int output = 0;
            try
            {
                this.sqlCon.Open();
                this.query = "EXEC PROC_INPUT_ANGGOTA @KODE, @NAMA, @TGL, @NO_TELP, @FOTO, ''";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlCmd.Parameters.AddWithValue("@KODE", kodeAnggota);
                this.sqlCmd.Parameters.AddWithValue("@NAMA", namaAnggota);
                this.sqlCmd.Parameters.AddWithValue("@TGL", tglTerdaftar);
                this.sqlCmd.Parameters.AddWithValue("@NO_TELP", noTelp);
                this.sqlCmd.Parameters.AddWithValue("@FOTO", foto);
                output = this.sqlCmd.ExecuteNonQuery();
            }
            finally
            {
                this.sqlCon.Close();
            }

            return output;
        }

        public int UpdateAnggota(string kodeAnggota, string namaAnggota, string noTelp, byte[] foto)
        {
            int output = 0;
            try
            {
                this.sqlCon.Open();
                this.query = "UPDATE TB_ANGGOTA " +
                             "SET NAMA_ANGGOTA = @NAMA, " +
                             "NO_TELP = @NO_TELP, " +
                             "FOTO_ANGGOTA = @FOTO " +
                             "WHERE KODE_ANGGOTA = @KODE";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlCmd.Parameters.AddWithValue("@KODE", kodeAnggota);
                this.sqlCmd.Parameters.AddWithValue("@NAMA", namaAnggota);
                this.sqlCmd.Parameters.AddWithValue("@NO_TELP", noTelp);
                this.sqlCmd.Parameters.AddWithValue("@FOTO", foto);
                output = this.sqlCmd.ExecuteNonQuery();
            }
            finally
            {
                this.sqlCon.Close();
            }

            return output;
        }

        public int InputKelompok(string kodeKel, string namaKel, string tgl, string kodeBendahara, string nominal, int jmlAnggota)
        {
            int output = 0;
            try
            {
                this.sqlCon.Open();
                this.query = "EXEC PROC_INPUT_KELOMPOK @KODE_KEL, @NAMA_KEL, @TGL, @KODE_BENDAHARA, @NOMINAL, @JML_ANGGOTA";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlCmd.Parameters.AddWithValue("@KODE_KEL", kodeKel);
                this.sqlCmd.Parameters.AddWithValue("@NAMA_KEL", namaKel);
                this.sqlCmd.Parameters.AddWithValue("@TGL", tgl);
                this.sqlCmd.Parameters.AddWithValue("@KODE_BENDAHARA", kodeBendahara);
                this.sqlCmd.Parameters.AddWithValue("@NOMINAL", nominal);
                this.sqlCmd.Parameters.AddWithValue("@JML_ANGGOTA", jmlAnggota);
                output = this.sqlCmd.ExecuteNonQuery();
            }
            finally
            {
                this.sqlCon.Close();
            }

            return output;
        }

        public int InputAnggotaTerdaftarKelompok(string kodeKelompok, string kodeAnggota)
        {
            int output = 0;
            int jmlRow = 0;
            try
            {
                this.sqlCon.Open();

                this.query = "SELECT COUNT(*) FROM TB_ANGGOTA_TERDAFTAR_KELOMPOK";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlDr = this.sqlCmd.ExecuteReader();
                if (this.sqlDr.Read())
                    jmlRow = this.sqlDr.GetInt32(0);
                this.sqlDr.Close();

                this.query = "EXEC PROC_INPUT_ANGGOTA_TERDAFTAR_KELOMPOK @ID, @KODE_KEL, @KODE_ANGGOTA";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlCmd.Parameters.AddWithValue("@ID", jmlRow + 1);
                this.sqlCmd.Parameters.AddWithValue("@KODE_KEL", kodeKelompok);
                this.sqlCmd.Parameters.AddWithValue("@KODE_ANGGOTA", kodeAnggota);
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