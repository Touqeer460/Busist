using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Busist
{
    public class DBConnect
    {
        SqlConnection conn;
        string myConnectionString;

        public DBConnect()
        {
            myConnectionString = "Server=tcp:busist1.database.windows.net,1433;Data Source=busist1.database.windows.net;Initial Catalog=st;Persist Security Info=False;User ID=touqeer460;Password=34jl|}FASF92934s;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = myConnectionString;
                //conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                //Console.WriteLine(ex.Message);
            }
        }

        public DataTable returnCheck()
        {
            SqlDataAdapter adap = new SqlDataAdapter("select * from xtn_navigate", conn);
            DataTable dt = new DataTable();
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            adap.Fill(dt); 
            if (conn.State == ConnectionState.Open)
                conn.Close();
            return dt;
            
        }

        public DataTable returnStop()
        {
            SqlDataAdapter adap = new SqlDataAdapter("select * from xtn_stop", conn);
            DataTable dt = new DataTable();
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            adap.Fill(dt);
            if (conn.State == ConnectionState.Open)
                conn.Close();
            return dt;
        }
    }
}