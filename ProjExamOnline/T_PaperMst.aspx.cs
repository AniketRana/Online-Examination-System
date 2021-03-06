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
    public partial class T_PaperMst : System.Web.UI.Page
    {

        tblQuestionPaperMst Obj = new tblQuestionPaperMst();
        DAL_tblQuestionPaperMst dal = new DAL_tblQuestionPaperMst();
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


        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPaperType.Text == "")
                {
                    lblmsg.Text = "Please Fill Up All Field . . .";
                    return;
                }
                lblmsg.Text = "";
                if (State == 0)
                {
                    //Obj.QID = Convert.ToInt32(txtQid.Text);
                    Obj.PaperType = txtPaperType.Text;

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
                    Obj.QPID = Convert.ToInt32(txtQpid.Text);
                    Obj.PaperType = txtPaperType.Text;

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
        public void Clear()
        {
            txtQpid.Text = "";
            txtPaperType.Text = "";
        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            State = 0;
            pnlform.Visible = true;
            pnlgrid.Visible = false;
            Clear();
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
                    Obj.QPID = Convert.ToInt16(CommandName);
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
                Obj.QPID = Convert.ToInt16(CommandArgument);
                dt = dal.GetSingleRecord(Obj);
                pnlform.Visible = true;
                pnlgrid.Visible = false;

                txtQpid.Text = dt.Rows[0]["QPID"].ToString().Trim();
                txtPaperType.Text = dt.Rows[0]["PaperType"].ToString().Trim();

                State = 1;
            }
            catch (Exception ex)
            {
                lblException.Text = "Warning : " + ex.Message.ToString();
                //ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('" + "Warning : " + ex.Message.ToString() + "');", true);
                //throw;
            }
        }
    }
}