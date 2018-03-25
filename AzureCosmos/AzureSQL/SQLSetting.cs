using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace AzureCosmos.AzureSQL
{
    public class SQLSetting
    {
        string connectionString = "Server=tcp:sqlfun.database.windows.net,1433;Initial Catalog=sqlFun;Persist Security Info=False;User ID={username};Password={password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        SqlConnection con;

        public SQLSetting()
        {
            con = new SqlConnection(connectionString);
        }
        public SqlConnection GetConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed || con.State == System.Data.ConnectionState.Broken)
                con.Open();

            return con;
        }

        public void CloseConnection()
        {
            con.Close();
        }

    }
}
