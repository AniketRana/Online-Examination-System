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
    public partial class S_Test : System.Web.UI.Page
    {
        tblAssignPaperResult Obj = new tblAssignPaperResult();
        DAL_tblAssignPaperResult dal = new DAL_tblAssignPaperResult();
        DataTable dt = new DataTable();
        public static Int16 State = 0;
        public static Int32 ID = 0;
        public static string AssignToID = "";
        public static string QPID = ""; 
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
                else if (Session["AssignToID"].ToString() == "" || Session["AssignToID"] == null || Session["QPID"].ToString() == "" || Session["QPID"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    UserName = Session["Name"].ToString();
                    ID = Convert.ToInt32(Session["ID"].ToString());
                    AssignToID = Session["AssignToID"].ToString();
                    QPID = Session["QPID"].ToString();

                    if (!IsPostBack)
                    {
                        pnlgrid.Visible = true;
                        FillTestPaper(); 
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Login.aspx");
            }
        }
        public void FillTestPaper()
        {
            if (QPID != "")
            {
                Obj.QPID = Convert.ToInt32(QPID);
                dt = dal.GetTestPaper(Obj);
                if (dt.Rows.Count == 0)
                {
                    lblerr.Text = "As of now did not have any paper assign to you...";
                    return;
                }
                else
                {
                    RepterTestPaper.DataSource = dt;
                    RepterTestPaper.DataBind();
                }
            }
        }

        protected void btnsubmitPaper_Click(object sender, EventArgs e)
        {
            try
            {
                int userResult=0;
                int Count;
                Count = RepterTestPaper.Items.Count;
                foreach (RepeaterItem item in RepterTestPaper.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {

                        HiddenField QdID = item.FindControl("hfQdID") as HiddenField;
                        HiddenField CorrectAns = item.FindControl("HfCorrectAns") as HiddenField;
                        Label Ques = item.FindControl("lblQuestion") as Label;
                        DropDownList ddlUserAns = item.FindControl("ddluserAns") as DropDownList;
                        string Ans = ddlUserAns.SelectedItem.Text.Trim();

                        if (CorrectAns.Value == Ans)
                        {
                            userResult += 1;
                        }
                        else
                        {
                            userResult += 0;
                        }
                    }
                }
                Obj.AssignToID = Convert.ToInt32(AssignToID);
                Obj.QPID = Convert.ToInt32(QPID);
                Obj.Marks = " " + userResult + " marks out of " + Count + "";
                int flag = dal.UpdFlagMarks(Obj);
                lblmsg.Text = "Your Paper Submitted Successfully and you got "+userResult+" marks out of "+Count+" ...";
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Paper not completed yet...";
            }
        }
    }
}