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
    public partial class T_CreatePaper : System.Web.UI.Page
    {

        tblQuestionPaperDetails Obj = new tblQuestionPaperDetails();
        DAL_tblQuestionPaperDetails dal = new DAL_tblQuestionPaperDetails();
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
                        FillPaperType();
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
            dt = dal.GetAllData();
            grvQuesPaperMst.DataSource = dt;
            grvQuesPaperMst.DataBind();
        }
        public void FillPaperType()
        {
            dt = dal.GetPaperType();
            ddlPaperType.DataSource = dt;
            ddlPaperType.DataValueField = "QPID";
            ddlPaperType.DataTextField = "PaperType";
            ddlPaperType.DataBind();
        }

        protected void btnCreatePaper_Click(object sender, EventArgs e)
        {
            try
            {
                int cnt = 0;
                foreach (GridViewRow gvrow in grvQuesPaperMst.Rows)
                {
                    var checkbox = gvrow.FindControl("chkSelect") as CheckBox;
                    if (checkbox.Checked)
                    {
                        cnt += 1;
                    }
                }
                if (cnt == 0)
                {
                    lblmsg.Text = "Select Questions from the list...you do not allow to select empty ...";
                    return;
                }

                Obj.QPID = Convert.ToInt32(ddlPaperType.SelectedValue.ToString());

                foreach (GridViewRow gvrow in grvQuesPaperMst.Rows)
                {
                    var checkbox = gvrow.FindControl("chkSelect") as CheckBox;
                    if (checkbox.Checked)
                    {
                        var lblQdID = gvrow.FindControl("lblQdID") as Label;
                        Obj.QpdID = Convert.ToInt32(lblQdID.Text);
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
                lblmsg.Text = "Question Paper Created Successfully ...";
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Question paper not created...";
            }

        }
    }
}