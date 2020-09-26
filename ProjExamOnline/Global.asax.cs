using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace ProjExamOnline
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
          
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            //Exception ex = Server.GetLastError();
            //string error = ex.Message.ToString();

            //HttpCookie Cookie = new HttpCookie("ex");
            //Cookie.Value = error;
            //Cookie.Expires = DateTime.Now.AddHours(1);
            //Response.Cookies.Add(Cookie);
            Response.Redirect("ClientError.aspx");

            //// Code that runs when an unhandled error occurs
        }
    }
}