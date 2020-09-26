using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ProjExamOnline.App_Code.DataAccessLayer
{
    public class DAL_tblAssignPaperResult
    {
        string parasql = string.Empty;
        string sql = string.Empty;
        SqlConnection cnnstr = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ToString());
        SqlCommand scmd = new SqlCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        public DataSet ds = new DataSet();
        public DataTable dt = new DataTable();

        public DataTable GetAllStudents()
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }
            sql = "Select * from tblUser where IsTeacher = 0";
            SqlDataAdapter adp = new SqlDataAdapter(sql, cnnstr);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cnnstr.Close();
            return dt;
        }

        public DataTable GetQuestionPaper()
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }
            sql = " select distinct(b.PaperType),b.QPID ";
            sql += " from tblQuestionPaperDetails a  left  join tblQuestionPaperMst b on a.QPID = b.QPID ";
            sql += " left  join tblQuesBankDetails c on a.QdID = c.QdID ";

            SqlDataAdapter adp = new SqlDataAdapter(sql, cnnstr);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cnnstr.Close();
            return dt;
        }
        public DataTable GetQuestionList(tblAssignPaperResult Obj)
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }

            sql = "select a.* , b.PaperType , c.* from tblQuestionPaperDetails a  left join tblQuestionPaperMst b";
            sql += " on a.QPID = b.QPID  left join tblQuesBankDetails c  on a.QdID = c.QdID  where a.QPID = " + Obj.QPID + "";

            SqlDataAdapter adp = new SqlDataAdapter(sql, cnnstr);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cnnstr.Close();
            return dt;
        }
        public DataTable GetStudentReport()
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }

            sql = "select a.* ,b.Name,b.Email,c.*  from tblAssignPaperResult a ";
            sql += " left join tblUser b on a.AssignToID = b.ID ";
            sql += " left join tblQuestionPaperMst c on a.QPID = c.QPID ";

            SqlDataAdapter adp = new SqlDataAdapter(sql, cnnstr);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cnnstr.Close();
            return dt;
        }
        public DataTable GetStudentReportforStud(tblAssignPaperResult obj)  
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }

            sql = "select a.* ,b.Name,b.Email,c.*  from tblAssignPaperResult a ";
            sql += " left join tblUser b on a.AssignToID = b.ID ";
            sql += " left join tblQuestionPaperMst c on a.QPID = c.QPID where a.AssignToID = "+obj.AssignToID+" ";

            SqlDataAdapter adp = new SqlDataAdapter(sql, cnnstr);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cnnstr.Close();
            return dt;
        }
        public DataTable GetExamPaper(tblAssignPaperResult Obj)
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }

            sql = "select a.* ,b.Name,b.Email,c.*  from tblAssignPaperResult a ";
            sql += " left join tblUser b on a.AssignToID = b.ID ";
            sql += " left join tblQuestionPaperMst c on a.QPID = c.QPID where a.AssignToID = " + Obj.AssignToID + " and a.IsCompleted = 0";

            SqlDataAdapter adp = new SqlDataAdapter(sql, cnnstr);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cnnstr.Close();
            return dt;
        }

        public DataTable GetTestPaper(tblAssignPaperResult Obj)
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }

            sql = "select a.* ,b.PaperType , c.*  from tblQuestionPaperDetails a  left join tblQuestionPaperMst b ";
            sql += " on a.QPID = b.QPID   left join tblQuesBankDetails c  on a.QdID = c.QdID ";
            sql += " where a.QPID = " + Obj.QPID + "";

            SqlDataAdapter adp = new SqlDataAdapter(sql, cnnstr);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cnnstr.Close();
            return dt;
        }
        public int UpdFlagMarks(tblAssignPaperResult obj)
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }
            sql = "Update tblAssignPaperResult set IsCompleted = 1 , Marks = '" + obj.Marks + "' where QPID = " + obj.QPID + " and AssignToID = " + obj.AssignToID + "";
            scmd = new SqlCommand(sql, cnnstr);
            scmd.ExecuteNonQuery();
            cnnstr.Close();
            return 1;
        }
        public int Insert(tblAssignPaperResult obj)
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }
            sql = "Insert Into tblAssignPaperResult (QPID,AssignToID,IsCompleted,Marks) values (" + obj.QPID + "," + obj.AssignToID + ",0,'')";
            scmd = new SqlCommand(sql, cnnstr);
            scmd.ExecuteNonQuery();
            cnnstr.Close();
            return 1;
        }
    }
}
