using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjExamOnline.App_Code.ObjectLayer
{
    public class tblUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email{ get; set; }
        public string Pwd{ get; set; }
        public bool IsTeacher{ get; set; } 
    }
}