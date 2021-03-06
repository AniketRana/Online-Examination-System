﻿using System;
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
    public partial class T_AddQuesDetails : System.Web.UI.Page
    {
        tblQuesBankDetails Obj = new tblQuesBankDetails();        
        DAL_tblQuesBankDetails dal = new DAL_tblQuesBankDetails();             
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
                        pnlform.Visible = false;
                        pnlgrid.Visible = true;
                        FillData();
                        FillSubjects();
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
            grvAddQues.DataSource = dt;
            grvAddQues.DataBind();
        }
        public void FillSubjects()
        {
            dt = dal.GetSubject();
            ddlSubject.DataSource = dt;
            ddlSubject.DataValueField = "QID";
            ddlSubject.DataTextField = "Subject";
            ddlSubject.DataBind();
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtQuestion.Text == "" || txtAns1.Text == "" || txtAns2.Text == "" || txtAns3.Text == "" || txtAns4.Text == "")
                {
                    lblmsg.Text = "Please Fill Up All Field . . .";
                    return;
                }
                lblmsg.Text = "";
                if (State == 0)
                {
                    
                    //Obj.QdID= Convert.ToInt32(hdQdid.Value);
                    Obj.QID= Convert.ToInt32(ddlSubject.SelectedValue.ToString());
                    Obj.Question = txtQuestion.Text;
                    Obj.Ans1= txtAns1.Text;
                    Obj.Ans2= txtAns2.Text;
                    Obj.Ans3= txtAns3.Text;
                    Obj.Ans4 = txtAns4.Text;
                    Obj.CorrectAns = ddlCorrectAns.SelectedValue.ToString();

                    int flag = dal.Insert(Obj);

                    if (flag == 1)
                    {
                        Clear();
                        pnlform.Visible = false;
                        pnlgrid.Visible = true;
                        FillData();
                    }
                    else { return; }
                }
                if (State == 1)
                {
                    Obj.QdID= Convert.ToInt32(hdQdid.Value);
                    Obj.QID = Convert.ToInt32(ddlSubject.SelectedValue.ToString());
                    Obj.Question = txtQuestion.Text;
                    Obj.Ans1 = txtAns1.Text;
                    Obj.Ans2 = txtAns2.Text;
                    Obj.Ans3 = txtAns3.Text;
                    Obj.Ans4 = txtAns4.Text;
                    Obj.CorrectAns = ddlCorrectAns.SelectedValue.ToString();

                    int flag = dal.Update(Obj);

                    if (flag == 1)
                    {
                        Clear();
                        pnlform.Visible = false;
                        pnlgrid.Visible = true;
                        FillData();
                    }
                    else { return; }
                }
            }
            catch (Exception ex)
            {
                lblException.Text = "Warning : " + ex.Message.ToString();
                //ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('" + "Warning : " + ex.Message.ToString() + "');", true);
                //throw;
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Clear();
            pnlform.Visible = false;
            pnlgrid.Visible = true;
        }

        protected void imgDel_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string confirmValue = Request.Form["confirm_value"];
                string L = confirmValue.Substring(confirmValue.Length - 1);

                if (L == "Y")
                {
                    ImageButton btn = (ImageButton)sender;
                    string CommandName = btn.CommandName;
                    Obj.QdID = Convert.ToInt16(CommandName);
                    int Flag = dal.Delete(Obj);
                    if (Flag == 1)
                    {
                        FillData();
                        confirmValue = "";
                        L = "";
                        //Request.Form["confirm_value"] = "";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                lblException.Text = "Warning : " + ex.Message.ToString();
                //ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('" + "Warning : " + ex.Message.ToString() + "');", true);
                //throw;
            }
        }

        protected void imgEdit_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ImageButton btn = (ImageButton)sender;
                string CommandArgument = btn.CommandArgument;
                Obj.QdID = Convert.ToInt16(CommandArgument);
                dt = dal.GetSingleRecord(Obj);
                pnlform.Visible = true;
                pnlgrid.Visible = false;

                hdQdid.Value = dt.Rows[0]["QdID"].ToString().Trim();

                //ddlSubject.Items.FindByText(dt.Rows[0]["Subject"].ToString().Trim());
                ddlSubject.ClearSelection();
                ddlSubject.Items.FindByText(dt.Rows[0]["Subject"].ToString().Trim()).Selected = true;

                txtQuestion.Text = dt.Rows[0]["Question"].ToString().Trim();
                txtAns1.Text = dt.Rows[0]["Ans1"].ToString().Trim();
                txtAns2.Text = dt.Rows[0]["Ans2"].ToString().Trim();
                txtAns3.Text = dt.Rows[0]["Ans3"].ToString().Trim();
                txtAns4.Text = dt.Rows[0]["Ans4"].ToString().Trim();
                //ddlCorrectAns.SelectedItem.Text = dt.Rows[0]["CorrectAns"].ToString().Trim();
                                
                ddlCorrectAns.ClearSelection();
                ddlCorrectAns.Items.FindByValue(dt.Rows[0]["CorrectAns"].ToString().Trim()).Selected = true;

                State = 1;
            }
            catch (Exception ex)
            {
                lblException.Text = "Warning : " + ex.Message.ToString();
                //ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('" + "Warning : " + ex.Message.ToString() + "');", true);
                //throw;
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            State = 0;
            pnlform.Visible = true;
            pnlgrid.Visible = false;
            Clear();
        }
        public void Clear()
        {
            hdQdid.Value = "";
            ddlSubject.SelectedIndex = 0;
            txtQuestion.Text = "";
            txtAns1.Text = "";
            txtAns2.Text = "";
            txtAns3.Text = "";
            txtAns4.Text = "";
            ddlCorrectAns.SelectedIndex = 0;
        }
    }
}