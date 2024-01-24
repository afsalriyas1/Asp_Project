using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Electronics
{
   

    public class connectionClass
    {
        SqlConnection con;
        SqlCommand cmd;

        public connectionClass()
        {
            con = new SqlConnection(@"server=LAPTOP-9HU5LPB4\SQLEXPRESS;database=WP;integrated security=true");

        }
        public int fn_nonquery(string sqlquery)//insert,update,delete
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;

        }
        public string fn_scalar(string sqlquery)//aggregate functions
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            string i = cmd.ExecuteScalar().ToString();
            con.Close();
            return i;
        }
        public SqlDataReader fn_datareader(string sqlquery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;


        }
        public DataSet fn_dataadapter(string sqlquery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            return ds;
        }
    }
}