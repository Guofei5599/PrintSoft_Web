using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeTest.ViewModels
{
    public class CreateEmployeeViewModel:BaseViewModel
    {
        [Required(ErrorMessage = "Enter UserID")]
        public string UserID { set; get; }
        [Required(ErrorMessage = "Enter Password")]
        public string Password { set; get; }
        [Required(ErrorMessage = "Enter Password")]
        public string rePassword { set; get; }
        public int Authentication { set; get; }
    }
}