using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeTest.ViewModels;
using EmployeeTest.Models;
using System.Web.Security;
using EmployeeTest.Filters;

namespace EmployeeTest.Controllers
{
    [HeaderFooterFilter]
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            return View("Login", new UserDetails());
        }
        [HttpPost]
        public ActionResult DoLogin(UserDetails us)
        {
            //string s = "<script>window.open('../top.htm');</script>";
            //return Content(s);
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer Emb = new EmployeeBusinessLayer();
                UserStatus statues = Emb.GetUserValidity(us);
                bool isAdmin = false;
                if (statues == UserStatus.AuthenticatedAdmin)
                {
                    isAdmin = true;
                }
                else if (statues == UserStatus.AuthentucatedUser)
                {
                    isAdmin = false;
                }
                else
                {
                    ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                    return View("Login",us);
                }
                FormsAuthentication.SetAuthCookie(us.UserName, false);
                Session["isAdmin"] = isAdmin;
                //return RedirectToAction("Index", "Employee");
                return RedirectToAction("Index", "Main");
            }
            else
            {
                return View("Login",us);
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login",new UserDetails());
        }
    }
}