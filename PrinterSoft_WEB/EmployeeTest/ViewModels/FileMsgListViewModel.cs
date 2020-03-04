using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeTest.ViewModels
{
    public class FileMsgListViewModel
    {
        public List<FileMsgViewModel> FileMsgs { set; get; }
        public string Phone { set; get; }
        public string QQ { set; get; }
        public string UserID { set; get; }
        public string Price { set; get; }
        public string Note { set; get; }
    }
}