using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjExamOnline.App_Code.ObjectLayer
{
    public class tblAssignPaperResult
    {
        public int APID { get; set;}
        public int QPID { get; set;} 
        public int AssignToID{ get; set;}   
        public bool IsCompleted{ get; set;}    
        public string Marks{ get; set;}     
    }
}