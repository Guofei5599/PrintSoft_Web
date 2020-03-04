using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeTest.ViewModels
{
    public class EmployeeListViewModel:BaseViewModel
    {
        public List<EmployeeViewModel> Employees { set; get; }
    }
}