//using System;
//using System.Collections.Generic;
using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace App_Arisan.Models
{
    class Models_Frm_AppArisan
    {
        Config.ConnectDb connectDb;
        SqlConnection sqlCon;
        SqlCommand sqlCmd;
        private string query;

        public Models_Frm_AppArisan()
        {
            this.connectDb = new Config.ConnectDb();
            this.sqlCon = connectDb.GetConnection();
        }

        public void LogoutAkun(string kodeAkun)
        {
            try
            {
                this.sqlCon.Open();
                this.query = "UPDATE TB_AKUN_BENDAHARA" +
                             " SET STATUS_AKUN = 'FALSE'" +
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
    }
}
