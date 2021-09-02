//using System;
//using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace App_Arisan.Models
{
    class Models_Uc_Pembayaran
    {
        Config.ConnectDb connectDb;
        SqlConnection sqlCon;
        SqlCommand sqlCmd;
        SqlDataReader sqlDr;
        SqlDataAdapter sqlDa;
        DataTable dt;
        private string query;

        public Models_Uc_Pembayaran()
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
            }
            finally
            {
                this.sqlCon.Close();
            }

            return this.dt;
        }

        public DataTable InfoKelompok(string kodeKelompok)
        {
            try
            {
                this.sqlCon.Open();
                this.query = "SELECT TB_AKUN_BENDAHARA.NAMA_LENGKAP + ' (' + TB_KELOMPOK_ARISAN.BENDAHARA + ')' AS[BENDAHARA], " +
                             "TB_KELOMPOK_ARISAN.NOMINAL_PERBAYAR, TB_KELOMPOK_ARISAN.JUMLAH_ANGGOTA " +
                             "FROM TB_KELOMPOK_ARISAN INNER JOIN TB_AKUN_BENDAHARA " +
                             "ON TB_KELOMPOK_ARISAN.BENDAHARA = TB_AKUN_BENDAHARA.KODE_AKUN " +
                             $"WHERE TB_KELOMPOK_ARISAN.KODE_KELOMPOK = '{kodeKelompok}'";
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

        public DataTable ListAnggota(string kodeKelompok)
        {
            try
            {
                this.sqlCon.Open();
                this.query = "SELECT TB_ANGGOTA_TERDAFTAR_KELOMPOK.ID_ANGGOTA_KELOMPOK AS[ID], " +
                             "TB_ANGGOTA.KODE_ANGGOTA AS[KODE], TB_ANGGOTA.NAMA_ANGGOTA AS[ANGGOTA], TB_ANGGOTA.NO_TELP AS[TELP] " +
                             "FROM TB_ANGGOTA_TERDAFTAR_KELOMPOK INNER JOIN TB_ANGGOTA " +
                             "ON TB_ANGGOTA_TERDAFTAR_KELOMPOK.KODE_ANGGOTA = TB_ANGGOTA.KODE_ANGGOTA " +
                             $"WHERE TB_ANGGOTA_TERDAFTAR_KELOMPOK.KODE_KELOMPOK = '{kodeKelompok}' ";
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

        public bool Pembayaran(int idAnggota, int pembayaranKe)
        {
            try
            {
                this.sqlCon.Open();
                this.query = "SELECT PEMBAYARAN_KE FROM TB_PEMBAYARAN " +
                             $"WHERE ID_ANGGOTA_KELOMPOK = {idAnggota} AND PEMBAYARAN_KE = {pembayaranKe}";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlDr = this.sqlCmd.ExecuteReader();
                if (this.sqlDr.Read())
                    return true;
            }
            finally
            {
                this.sqlDr.Close();
                this.sqlCon.Close();
            }

            return false;
        }

        private int JumlahRowPembayaran()
        {
            int jmlRow = 0;
            try
            {
                this.sqlCon.Open();
                this.query = "SELECT * FROM TB_PEMBAYARAN";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlDr = this.sqlCmd.ExecuteReader();
                while (this.sqlDr.Read())
                    jmlRow++;
            }
            finally
            {
                this.sqlDr.Close();
                this.sqlCon.Close();
            }

            return jmlRow;
        }

        public bool CekPembayaran(int idKel, int pyrKe)
        {
            try
            {
                this.sqlCon.Open();
                this.query = "SELECT * FROM TB_PEMBAYARAN " +
                             $"WHERE ID_ANGGOTA_KELOMPOK = '{idKel}' AND " +
                             $"PEMBAYARAN_KE = '{pyrKe}'";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlDr = this.sqlCmd.ExecuteReader();
                return this.sqlDr.Read();
            }
            finally
            {
                this.sqlDr.Close();
                this.sqlCon.Close();
            }
        }

        public int SimpanPembayaran(int idKel, string tgl, int urtPembayaran)
        {
            int idPembayaran = this.JumlahRowPembayaran() + 1;
            try
            {
                this.sqlCon.Open();
                this.query = "INSERT INTO TB_PEMBAYARAN VALUES" +
                             $"(@ID_PYR, @ID_KEL, @TGL, @PEM_KE)";
                this.sqlCmd = new SqlCommand(this.query, this.sqlCon);
                this.sqlCmd.Parameters.AddWithValue("@ID_PYR", idPembayaran);
                this.sqlCmd.Parameters.AddWithValue("@ID_KEL", idKel);
                this.sqlCmd.Parameters.AddWithValue("@TGL", tgl);
                this.sqlCmd.Parameters.AddWithValue("@PEM_KE", urtPembayaran);
                return this.sqlCmd.ExecuteNonQuery();
            }
            finally
            {
                this.sqlCon.Close();
            }
        }
    }
}
