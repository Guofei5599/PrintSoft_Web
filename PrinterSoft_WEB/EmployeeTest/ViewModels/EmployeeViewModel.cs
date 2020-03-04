using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeTest.ViewModels
{
    public class EmployeeViewModel
    {
        public string UserID { set; get; }
        public string Name { set; get; }
        public string Password { set; get; }
        public int Authentication { set; get; }
    }
}