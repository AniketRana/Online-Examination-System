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
    public partial class T_AssignPaper : System.Web.UI.Page
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
                        pnlform.Visible = true;
                        //pnlgrid.Visible = true;
                        FillData();
                        FillQuestionPapers();
                        FillQuesList();
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
            dt = dal.GetAllStudents();
            grvStudents.DataSource = dt;
            grvStudents.DataBind();
        }
        public void FillQuesList() 
        {
            Obj.QPID = Convert.ToInt32(ddlQuestionPaper.SelectedValue.ToString());
            dt = dal.GetQuestionList(Obj); 
            grvQuesList.DataSource = dt;
            grvQuesList.DataBind();
        }
        public void FillQuestionPapers()
        {
            dt = dal.GetQuestionPaper();
            ddlQuestionPaper.DataSource = dt;
            ddlQuestionPaper.DataValueField = "QPID";
            ddlQuestionPaper.DataTextField = "PaperType";
            ddlQuestionPaper.DataBind();
        }
        
        protected void btnAssignPaperToStudent_Click(object sender, EventArgs e)
        {
            try
            {
                int cnt = 0;
                foreach (GridViewRow gvrow in grvStudents.Rows)
                {
                    var checkbox = gvrow.FindControl("chkSelect") as CheckBox;
                    if (checkbox.Checked)
                    {
                        cnt += 1;
                    }
                }
                if (cnt == 0)
                {
                    lblmsg.Text = "Select Students from the list...you do not allow to select empty while assigning the paper ...";
                    return;
                }

                Obj.QPID = Convert.ToInt32(ddlQuestionPaper.SelectedValue.ToString());

                foreach (GridViewRow gvrow in grvStudents.Rows)
                {
                    var checkbox = gvrow.FindControl("chkSelect") as CheckBox;
                    if (checkbox.Checked)
                    {
                        var lblID = gvrow.FindControl("lblID") as Label;
                        Obj.AssignToID= Convert.ToInt32(lblID.Text);
                        int flag = dal.Insert(Obj);
                        //if (flag == 1)
                        //{
                        //}
                    }
                    else
                    {
                        //return;
                    }
                }
                lblmsg.Text = "Paper Assigned Successfully ...";
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Paper not assigned yet...";
            }
        }

        protected void ddlQuestionPaper_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillQuesList();
        }
    }
}