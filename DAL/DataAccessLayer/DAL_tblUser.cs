using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ProjExamOnline.App_Code.DataAccessLayer
{
    public class DAL_tblUser
    {
        string parasql = string.Empty;
        string sql = string.Empty;
        SqlConnection cnnstr = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ToString());
        SqlCommand scmd = new SqlCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        public DataSet ds = new DataSet();
        public DataTable dt = new DataTable();

        public DataTable GetData()
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }
            sql = "Select * from Tabel";
            SqlDataAdapter adp = new SqlDataAdapter(sql, cnnstr);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cnnstr.Close();
            return dt; 
        }
        public DataTable Login(tblUser obj)
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }
            sql = "Select * from tblUser where Email = '"+obj.Email+"' and Pwd = '"+obj.Pwd+"'";
            SqlDataAdapter adp = new SqlDataAdapter(sql, cnnstr);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cnnstr.Close();
            return dt;
        }
    }
}