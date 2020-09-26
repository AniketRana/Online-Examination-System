using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ProjExamOnline.App_Code.DataAccessLayer
{
    public class DAL_tblQuesBankDetails
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
        public DataTable GetSingleRecord(tblQuesBankDetails obj)
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }
            //sql = "Select * from tblQuesBankDetails where QdID = " + obj.QdID + "";
            sql = "select a.* ,b.* from tblQuesBankDetails a left join tblQuesBankMst b on a.QID = b.QID where a.QdID = "+ obj.QdID + "";
            SqlDataAdapter adp = new SqlDataAdapter(sql, cnnstr);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cnnstr.Close();
            return dt;
        }
        public int Delete(tblQuesBankDetails obj)
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }
            sql = "delete from tblQuesBankDetails where QdID = " + obj.QdID + "";
            scmd = new SqlCommand(sql, cnnstr);
            scmd.ExecuteNonQuery();
            cnnstr.Close();
            return 1;
        }
        public int Insert(tblQuesBankDetails obj)
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }
            sql = "Insert Into tblQuesBankDetails (QID,Question,Ans1,Ans2,Ans3,Ans4,CorrectAns) values (@QID,@Question,@Ans1,@Ans2,@Ans3,@Ans4,@CorrectAns)";

            scmd = new SqlCommand(sql, cnnstr);
            scmd.Parameters.AddWithValue("@QID", obj.QID);
            scmd.Parameters.AddWithValue("@Question", obj.Question);
            scmd.Parameters.AddWithValue("@Ans1", obj.Ans1);
            scmd.Parameters.AddWithValue("@Ans2", obj.Ans2);
            scmd.Parameters.AddWithValue("@Ans3", obj.Ans3);
            scmd.Parameters.AddWithValue("@Ans4", obj.Ans4);
            scmd.Parameters.AddWithValue("@CorrectAns", obj.CorrectAns);
            scmd.ExecuteNonQuery();
            cnnstr.Close();
            return 1;
        }
        public int Update(tblQuesBankDetails obj)
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }
            //sql = "Update tblQuesBankMst set Subject = '" + obj.Subject + "', QuesBankName = '" + obj.QuesBankName + "' where QID = " + obj.QID + " ";
            sql = "update tblQuesBankDetails  set QID = @QID , Question = @Question,Ans1 = @Ans1,Ans2 = @Ans2,Ans3= @Ans3,Ans4= @Ans4,CorrectAns= @CorrectAns where QdID = @QdID ";

            scmd = new SqlCommand(sql, cnnstr);
            scmd.Parameters.AddWithValue("@QID", obj.QID);
            scmd.Parameters.AddWithValue("@Question", obj.Question);
            scmd.Parameters.AddWithValue("@Ans1", obj.Ans1);
            scmd.Parameters.AddWithValue("@Ans2", obj.Ans2);
            scmd.Parameters.AddWithValue("@Ans3", obj.Ans3);
            scmd.Parameters.AddWithValue("@Ans4", obj.Ans4);
            scmd.Parameters.AddWithValue("@CorrectAns", obj.CorrectAns);
            scmd.Parameters.AddWithValue("@QdID", obj.QdID);
            scmd.ExecuteNonQuery();
            cnnstr.Close();
            return 1;
        }
        public DataTable GetSubject() 
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
    }
}
