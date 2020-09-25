using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Collections;
using System.Configuration;
//using DAL;



namespace ProjExamOnline.App_Code.DataAccessLayer
{
    public class DAL_tblUser
    {
        private DataSet ds;

        string parasql = string.Empty;
        string sql = string.Empty;
        SqlConnection cnnstr = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ToString());

        public DataTable GetData()
        {
            if (cnnstr.State == ConnectionState.Closed)
            {
                cnnstr.Open();
            }
            sql = "Select * from Tabel";
            SqlDataAdapter adp = new SqlDataAdapter(sql, cnnstr);
            DataTable dt = new DataTable();
            adp.Fill(ds);
            cnnstr.Close();
            return dt; 
        }
    }
}