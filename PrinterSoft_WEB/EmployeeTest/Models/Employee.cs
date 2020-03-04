using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EmployeeTest.Models;

namespace EmployeeTest.Models
{
    public class Employee
    {
        [Key]
        [Required(ErrorMessage = "Enter UserID")]
        public string UserID { set; get; }
        public string Name { set; get; }
        //[StringLength(5, ErrorMessage = "Last Name length should not be greater than 5")]
        public string Password { set; get; }
        public int Authentication { set; get; }
    }
}