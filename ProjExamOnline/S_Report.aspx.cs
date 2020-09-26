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
    public partial class S_Report : System.Web.UI.Page
    {
        tblAssignPaperResult Obj = new tblAssignPaperResult();
        DAL_tblAssignPaperResult dal = new DAL_tblAssignPaperResult();
        DataTable dt = new DataTable();
        public static Int16 State = 0;
        string UserName;
        public static string AssignToID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Name"].ToString() == "" || Session["Name"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else if (Session["ID"].ToString() == "" || Session["ID"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    UserName = Session["Name"].ToString();
                    AssignToID = Session["ID"].ToString();
                    if (!IsPostBack)
                    {
                        pnlgrid.Visible = true;
                        FillStudentReport(); 
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Login.aspx");
            }
        }
        public void FillStudentReport() 
        {
            Obj.AssignToID = Convert.ToInt32(AssignToID);
            dt = dal.GetStudentReportforStud(Obj);
            if (dt.Rows.Count == 0)
            {
                lblerr.Text = "No data found";
            }
            else
            {
                grvReport.DataSource = dt;
                grvReport.DataBind();
            }
            
        }
    }
}