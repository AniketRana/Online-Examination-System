using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ProjExamOnline.App_Code.DataAccessLayer 
{
    public class DAL_tblQuesBankMst
    {
        string parasql = string.Empty;
        string sql = string.Empty;
        SqlConnection cnnstr = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ToString());
        SqlCommand scmd = new SqlCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        public DataSet ds = new DataSet();
        public DataTable dt = new DataTable();
        
        public DataTable GetAllData() 
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }
            sql = "Select * from tblQuesBankMst";
            SqlDataAdapter adp = new SqlDataAdapter(sql, cnnstr);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cnnstr.Close();
            return dt;
        }
        public DataTable GetSingleRecord(tblQuesBankMst obj)  
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }
            sql = "Select * from tblQuesBankMst where QID = "+obj.QID+"";
            SqlDataAdapter adp = new SqlDataAdapter(sql, cnnstr);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cnnstr.Close();
            return dt;
        }
        public int Delete(tblQuesBankMst obj) 
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }
            sql = "delete from tblQuesBankMst where QID = " + obj.QID + "";
            scmd = new SqlCommand(sql, cnnstr);
            scmd.ExecuteNonQuery();            
            cnnstr.Close();
            return 1;
        }
        public int Insert(tblQuesBankMst obj) 
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }
            sql = "Insert Into tblQuesBankMst (Subject ,QuesBankName) values ('"+obj.Subject+ "','" + obj.QuesBankName+ "')";
            scmd = new SqlCommand(sql, cnnstr);
            scmd.ExecuteNonQuery();
            cnnstr.Close();
            return 1;
        }
        public int Update(tblQuesBankMst obj) 
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }
            sql = "Update tblQuesBankMst set Subject = '"+obj.Subject+ "', QuesBankName = '"+obj.QuesBankName+"' where QID = "+obj.QID+" ";
            scmd = new SqlCommand(sql, cnnstr);
            scmd.ExecuteNonQuery();
            cnnstr.Close();
            return 1;
        }
    }
}
