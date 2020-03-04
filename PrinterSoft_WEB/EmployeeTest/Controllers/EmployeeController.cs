using EmployeeTest.Filters;
using EmployeeTest.Models;
using EmployeeTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeTest.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Test
        [Authorize]
        public ActionResult Index()
        {
            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();
            employeeListViewModel.UserName = User.Identity.Name;
            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
            foreach (var v in employees)
            {
                EmployeeViewModel vmEmp = new EmployeeViewModel();
                vmEmp.UserID = v.UserID;
                vmEmp.Password = v.Password;
                vmEmp.Name = v.Name;
                vmEmp.Authentication = v.Authentication;
                employeeViewModels.Add(vmEmp);
            }
            employeeListViewModel.Employees = employeeViewModels;

            return View("Index", employeeListViewModel);
        }
        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult AddNew()
        {
            CreateEmployeeViewModel employeeListViewModel = new CreateEmployeeViewModel();
            //employeeListViewModel.FooterData = new FooterViewModel();
            //employeeListViewModel.FooterData.CompanyName = "StepByStepSchools";
            //employeeListViewModel.FooterData.Year = DateTime.Now.Year.ToString();
            return View("CreateEmployee", employeeListViewModel);
        }

        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult SaveEmployee(CreateEmployeeViewModel e,string Btnsubmit)
        {
            if (Btnsubmit == "添  加")
            {
                if (ModelState.IsValid)
                {
                    if (e.Password != e.rePassword)
                    {
                        ModelState.AddModelError("AddErr","两次输入密码不一致");
                        return View("CreateEmployee", new CreateEmployeeViewModel());
                    }
                    EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                    Employee emp = new Employee();
                    emp.Authentication = 0;
                    emp.Password = e.Password;
                    emp.UserID = e.UserID;
                    emp.Name = e.UserID;
                    Employee tmp = new Employee();
                    if ((tmp = empBal.SaveEmployee(emp)).UserID != null)
                        return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError("AddErr", tmp.Name);
                        return View("CreateEmployee", new CreateEmployeeViewModel());
                    }
                }
                else
                {
                    CreateEmployeeViewModel ceVm = new CreateEmployeeViewModel();
                    return View("CreateEmployee", ceVm);
                }
            }
            else if(Btnsubmit == "Cancel")
            {
                return RedirectToAction("Index");
            }
            return new EmptyResult();
        }
        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult SetAdmin(EmployeeViewModel tmp)
        {
            if (tmp.Authentication == 1)
                return new EmptyResult();
            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            Employee emp = new Employee()
            {
                Authentication = tmp.Authentication,
                Name = tmp.Name,
                Password = tmp.Password,
                UserID = tmp.UserID
            };
            empBal.SetAdmin(emp);
            return RedirectToAction("Index");
        }
        //[AdminFilter]
        //[HeaderFooterFilter]
        [HttpPost]
        public ActionResult DeleteEmployee(string[] array)
        {
            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            if (empBal.Delete(array))
            {
                return Content("success");
            }
            else
            {
                return Content("no");
            }
        }
        public ActionResult GetAddNewLinkAct()
        {
            if (Convert.ToBoolean(Session["isAdmin"]))
            {
                return View("AddNewLink");
            }
            else
            {
                return new EmptyResult();
            }
        }
    }
}