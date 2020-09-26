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
    public partial class S_ExamPaper : System.Web.UI.Page
    {

        tblAssignPaperResult Obj = new tblAssignPaperResult();
        DAL_tblAssignPaperResult dal = new DAL_tblAssignPaperResult();
        DataTable dt = new DataTable();
        public static Int16 State = 0;
        public static Int32 ID = 0; 
        string UserName;

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
                    ID = Convert.ToInt32(Session["ID"].ToString());
                    if (!IsPostBack)
                    {
                        pnlgrid.Visible = true;
                        FillExamPaper();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Login.aspx");
            }
        }
        public void FillExamPaper() 
        {
            Obj.AssignToID = ID;
            dt = dal.GetExamPaper(Obj); 
            if (dt.Rows.Count == 0)
            {
                lblerr.Text = "As of now did not have any paper assign to you...";
                return;
            }
            else
            {
                RepterPaper.DataSource = dt;
                RepterPaper.DataBind();
            }
        }

        protected void btnsubmit_Command(object sender, CommandEventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                string QPID = btn.CommandName;
                string AssignToID = btn.CommandArgument;
                Session["QPID"] = QPID;
                Session["AssignToID"] = AssignToID;
                Response.Redirect("S_Test.aspx");
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}