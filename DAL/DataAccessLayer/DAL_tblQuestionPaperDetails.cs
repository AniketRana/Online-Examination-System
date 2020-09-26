using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ProjExamOnline.App_Code.DataAccessLayer 
{
    public class DAL_tblQuestionPaperDetails
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
            //sql = "Select * from tblQuesBankDetails";
            sql = "select a.* ,b.* from tblQuesBankDetails a left join tblQuesBankMst b on a.QID = b.QID";
            SqlDataAdapter adp = new SqlDataAdapter(sql, cnnstr);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cnnstr.Close();
            return dt;
        }
        public DataTable GetPaperType() 
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }
            sql = "Select * from tblQuestionPaperMst ";            
            SqlDataAdapter adp = new SqlDataAdapter(sql, cnnstr);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cnnstr.Close();
            return dt;
        }
        public int Insert(tblQuestionPaperDetails obj)
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }
            sql = "Insert Into tblQuestionPaperDetails (QPID,QdID) values ("+obj.QPID+","+obj.QpdID+")";
            scmd = new SqlCommand(sql, cnnstr);
            scmd.ExecuteNonQuery();
            cnnstr.Close();
            return 1;
        }
        
    }
}
