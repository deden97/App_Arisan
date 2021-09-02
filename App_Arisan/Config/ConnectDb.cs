using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace App_Arisan.Config
{
    class ConnectDb
    {
        public SqlConnection GetConnection()
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = "Data Source = LAPTOP-D7CCRR4J; initial catalog = DB_APP_ARISAN; integrated security = true";
            return sqlCon;
        }
    }
}