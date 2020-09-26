using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using ProjExamOnline.App_Code.DataAccessLayer;

namespace ProjExamOnline
{
    public partial class T_Report : System.Web.UI.Page
    {

        tblAssignPaperResult Obj = new tblAssignPaperResult();
        DAL_tblAssignPaperResult dal = new DAL_tblAssignPaperResult();
        DataTable dt = new DataTable();
        public static Int16 State = 0;
        string UserName;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Name"].ToString() == "" || Session["Name"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    UserName = Session["Name"].ToString();
                    if (!IsPostBack)
                    {
                        pnlgrid.Visible = true;
                        FillData();                        
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Login.aspx");
            }
        }
        public void FillData()
        {
            dt = dal.GetStudentReport();
            grvReport.DataSource = dt;
            grvReport.DataBind();
        }
    }
}