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
    public partial class Login : System.Web.UI.Page
    {
        tblUser Obj = new tblUser();
        DAL_tblUser dal = new DAL_tblUser();
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtusername.Text == "" && txtpassword.Text == "")
                {
                    return;
                }
                else
                {
                    Obj.Email = txtusername.Text;  
                    Obj.Pwd= txtpassword.Text;
                    dt = dal.Login(Obj);
                    if (dt.Rows.Count == 0)
                    {
                        lblmsg.Text = "Invalid Email or Password...";
                        return;
                    }
                    else
                    {
                        Session["Email"] = dt.Rows[0]["Email"].ToString();
                        Session["IsTeacher"] = dt.Rows[0]["IsTeacher"].ToString();
                        Session["Name"] = dt.Rows[0]["Name"].ToString();

                        if (dt.Rows[0]["IsTeacher"].ToString().ToLower() == "false")
                        {
                            //this.MasterPageFile = "~/Student.Master";
                            Response.Redirect("S_Dashboard.aspx");
                        }
                        else
                        {
                            //this.MasterPageFile = "~/Teacher.Master";
                            Response.Redirect("T_Dashboard.aspx"); 
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.ToString();
            }
        }
    }
}