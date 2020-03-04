using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeTest.ViewModels
{
    public class BaseViewModel
    {
        public string UserName { set; get; }
        public FooterViewModel FooterData { set; get; }
    }
}