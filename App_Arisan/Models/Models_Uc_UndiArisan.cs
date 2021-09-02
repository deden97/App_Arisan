//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace App_Arisan.Models
{
    class Models_Uc_UndiArisan
    {
        Config.ConnectDb connectDb;
        SqlConnection sqlCon;
        SqlCommand sqlCmd;
        SqlDataReader sqlDr;
        SqlDataAdapter sqlDa;
        DataTable dt;
        private string query;

        public Models_Uc_UndiArisan()
        {
            this.connectDb = new Config.ConnectDb();
            this.sqlCon = this.connectDb.GetConnection();
        }

        public object ListKelompokUntukCmb(string kodeBendahara)
        {
            try
            {
                this.sqlCon.Open();
                this.query = "SELECT KODE_KELOMPOK, NAMA_KELOMPOK " +
                             "FROM TB_KELOMPOK_ARISAN " +
                             $"WHERE BENDAHARA = '{kodeBendahara}' AND STATUS_KELOMPOK = 'TRUE'" +
                             "ORDER BY CONVERT(DATE, TGL_DIBUAT, 105) DESC ";
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

        public DataTable GetInfoKelompok(string kodeKelompok)
        {
            try
            {
                this.sqlCon.Open();
                this.query = "SELECT TB_AKUN_BENDAHARA.NAMA_LENGKAP + ' (' + TB_AKUN_BENDAHARA.KODE_AKUN + ')' AS[BENDAHARA], " +
                             "TB_KELOMPOK_ARISAN.NOMINAL_PERBAYAR * TB_KELOMPOK_ARISAN.JUMLAH_ANGGOTA AS[TOTAL_NOMINAL], TB_KELOMPOK_ARISAN.JUMLAH_ANGGOTA " +
                             "FROM TB_KELOMPOK_ARISAN INNER JOIN TB_AKUN_BENDAHARA " +
                             "ON TB_KELOMPOK_ARISAN.BENDAHARA = TB_AKUN_BENDAHARA.KODE_AKUN " +
                             $"WHERE TB_KELOMPOK_ARISAN.KODE_KELOMPOK = '{kodeKelompok}'";
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

        public int UrutanUndian(string kodeKelompok)
        {
            int output = 0;
            try
            {
                this.sqlCon.Open();
                this.query = $"SELECT * FROM TB_UNDI_ARISAN WHERE KODE_KELOMPOK = '{kodeKelompok}'";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlDr = this.sqlCmd.ExecuteReader();
                while (this.sqlDr.Read())
                    output++;

                return output;
            }
            finally
            {
                this.sqlDr.Close();
                this.sqlCon.Close();
            }
        }

        public int CekPembayaran(string kodeKelompok, int pembayaranKe)
        {
            int output = 0;
            try
            {
                this.sqlCon.Open();
                this.query = "EXEC PROC_CEK_PEMBAYARAN @KODE_KEL, @PEMBAYARAN_KE";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlCmd.Parameters.AddWithValue("@KODE_KEL", kodeKelompok);
                this.sqlCmd.Parameters.AddWithValue("@PEMBAYARAN_KE", pembayaranKe);
                this.sqlDr = this.sqlCmd.ExecuteReader();
                while (this.sqlDr.Read())
                    output++;

                return output;
            }
            finally
            {
                this.sqlDr.Close();
                this.sqlCon.Close();
            }
        }

        public DataTable GetListAnggotaYgSudahMenang(string kodeKelompok)
        {
            try
            {
                this.sqlCon.Open();
                this.query = "SELECT TB_ANGGOTA.NAMA_ANGGOTA + ' (' + TB_ANGGOTA.KODE_ANGGOTA + ')' AS[ANGGOTA] " +
                             "FROM TB_UNDI_ARISAN INNER JOIN TB_ANGGOTA " +
                             "ON TB_UNDI_ARISAN.PEMENANG = TB_ANGGOTA.KODE_ANGGOTA " +
                             $"WHERE TB_UNDI_ARISAN.KODE_KELOMPOK = '{kodeKelompok}'";
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

        public DataTable GetListAnggota(string kodeKelompok)
        {
            try
            {
                this.sqlCon.Open();
                this.query = "SELECT TB_ANGGOTA.NAMA_ANGGOTA + ' (' + TB_ANGGOTA.KODE_ANGGOTA + ')' AS[ANGGOTA] " +
                             "FROM TB_ANGGOTA_TERDAFTAR_KELOMPOK INNER JOIN TB_ANGGOTA " +
                             "ON TB_ANGGOTA_TERDAFTAR_KELOMPOK.KODE_ANGGOTA = TB_ANGGOTA.KODE_ANGGOTA " +
                             $"WHERE TB_ANGGOTA_TERDAFTAR_KELOMPOK.KODE_KELOMPOK = '{kodeKelompok}'";
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

        public DataTable GetInfoPemenang(string kodeAnggota)
        {
            try
            {
                this.sqlCon.Open();
                this.query = "SELECT NO_TELP, FOTO_ANGGOTA FROM TB_ANGGOTA " +
                             $"WHERE KODE_ANGGOTA = '{kodeAnggota}'";
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

        private int JumlahBarisUndian()
        {
            try
            {
                this.sqlCon.Open();
                this.query = "SELECT ID FROM TB_UNDI_ARISAN ORDER BY ID DESC";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlDr = this.sqlCmd.ExecuteReader();
                this.sqlDr.Read();
                return this.sqlDr.GetInt32(0);
            }
            finally
            {
                this.sqlCon.Close();
            }
        }

        public int SimpanUndian(string tgl, string kode_kel, string pemenang, int undianKe)
        {
            int id = this.JumlahBarisUndian() + 1;
            int output = 0;
            try
            {
                this.sqlCon.Open();
                this.query = "INSERT INTO TB_UNDI_ARISAN VALUES(@ID, @TGL, @KODE_KEL, @PEMENANG, @UNDIAN_KE)";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlCmd.Parameters.AddWithValue("@ID", id);
                this.sqlCmd.Parameters.AddWithValue("@TGL", tgl);
                this.sqlCmd.Parameters.AddWithValue("@KODE_KEL", kode_kel);
                this.sqlCmd.Parameters.AddWithValue("@PEMENANG", pemenang);
                this.sqlCmd.Parameters.AddWithValue("@UNDIAN_KE", undianKe);
                this.sqlDr = this.sqlCmd.ExecuteReader();
                while (this.sqlDr.Read())
                    output++;

                return output;
            }
            finally
            {
                this.sqlCon.Close();
            }
        }

        public int HapusPemenang(string kodeKel, string kodeAgtPemenang)
        {
            try
            {
                this.sqlCon.Open();
                this.query = $"DELETE TB_UNDI_ARISAN WHERE KODE_KELOMPOK = '{kodeKel}' AND PEMENANG = '{kodeAgtPemenang}'";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                return this.sqlCmd.ExecuteNonQuery();
            }
            finally
            {
                this.sqlCon.Close();
            }
        }

        public int UpdataStatusKelompok(string kodeKelompok)
        {
            try
            {
                this.sqlCon.Open();
                this.query = $"UPDATE TB_KELOMPOK_ARISAN SET STATUS_KELOMPOK = 'FALSE' WHERE KODE_KELOMPOK = '{kodeKelompok}'";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                return this.sqlCmd.ExecuteNonQuery();
            }
            finally
            {
                this.sqlCon.Close();
            }
        }
    }
}
