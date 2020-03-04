using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeTest.Models
{
    public class FileMsg
    {
        [Key]
        public string UserID { set; get; }
        public bool isInit { set; get; }
        public string FileName { set; get; }
        public string Count { set; get; }
        public string state { set; get; }
        public string LoadTime { set; get; }
        public string FinishTime { set; get; }
        public string DeleteTime { set; get; }
        public string VerForm { set; get; }
        public string PrintColor { set; get; }
        public string PaperType { set; get; }
        public string Printer { set; get; }
        public string PageCount { set; get; }
        public string Price { set; get; }
        public string InitPrice { set; get; }
        public string FullName { set; get; }
        public bool isNew { set; get; }
        public bool isNormalFile { set; get; }
        public bool isRemove { set; get; }
        public string Note { set; get; }
    }
}