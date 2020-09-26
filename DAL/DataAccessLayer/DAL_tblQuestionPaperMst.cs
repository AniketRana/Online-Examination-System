using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ProjExamOnline.App_Code.DataAccessLayer 
{
    public class DAL_tblQuestionPaperMst 
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
            sql = "Select * from tblQuestionPaperMst";
            SqlDataAdapter adp = new SqlDataAdapter(sql, cnnstr);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cnnstr.Close();
            return dt;
        }
        public DataTable GetSingleRecord(tblQuestionPaperMst obj)  
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }
            sql = "Select * from tblQuestionPaperMst where QPID = " + obj.QPID+"";
            SqlDataAdapter adp = new SqlDataAdapter(sql, cnnstr);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cnnstr.Close();
            return dt;
        }
        public int Delete(tblQuestionPaperMst obj) 
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }
            sql = "delete from tblQuestionPaperMst where QPID = " + obj.QPID + "";
            scmd = new SqlCommand(sql, cnnstr);
            scmd.ExecuteNonQuery();            
            cnnstr.Close();
            return 1;
        }
        public int Insert(tblQuestionPaperMst obj) 
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }
            sql = "Insert Into tblQuestionPaperMst (PaperType) values ('" + obj.PaperType+ "')";
            scmd = new SqlCommand(sql, cnnstr);
            scmd.ExecuteNonQuery();
            cnnstr.Close();
            return 1;
        }
        public int Update(tblQuestionPaperMst obj) 
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }
            sql = "Update tblQuestionPaperMst set PaperType = '" + obj.PaperType + "' where QPID = "+obj.QPID+" ";
            scmd = new SqlCommand(sql, cnnstr);
            scmd.ExecuteNonQuery();
            cnnstr.Close();
            return 1;
        }
    }
}
