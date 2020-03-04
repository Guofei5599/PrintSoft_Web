using EmployeeTest.Data_Access_Layer;
using EmployeeTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeTest.ViewModels
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            return salesDal.Employees.ToList();
        }
        public List<Employee> GetEmployee(string UserID)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            return salesDal.Employees.Where(t=>t.UserID == UserID).ToList();
        }
        public Employee SaveEmployee(Employee e)
        {
            try
            {
                SalesERPDAL salesERPDAL = new SalesERPDAL();
                salesERPDAL.Employees.Add(e);
                salesERPDAL.SaveChanges();
                return e;
            }
            catch (Exception ex)
            {
                Employee tmp = new Employee();
                tmp.UserID = null;
                tmp.Name = ex.Message;
                return tmp;
            }
        }
        public bool SetAdmin(Employee e)
        {
            try
            {
                if (e.Authentication == 1)
                    return true;
                using (SalesERPDAL salesERPDAL = new SalesERPDAL())
                {
                    foreach (var v in salesERPDAL.Employees)
                    {
                        if (e.UserID == v.UserID)
                            v.Authentication = 1;
                        else
                            v.Authentication = 0;
                    }
                    salesERPDAL.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(string[] userIDs)
        {
            try
            {
                using (SalesERPDAL salesERPDAL = new SalesERPDAL())
                {
                    foreach (var v in userIDs)
                    {
                        var valList = from u in salesERPDAL.Employees where u.UserID == v && u.Authentication != 1 select u;
                        var val = valList.FirstOrDefault();
                        if (val != null)
                        {
                            salesERPDAL.Employees.Remove(val);
                        }
                    }
                    salesERPDAL.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        [HttpPost]
        public UserStatus GetUserValidity(UserDetails u)
        {
            var result = GetEmployee(u.UserName);
            if (result == null || result.Count == 0)
            {
                return UserStatus.NonAuthenticatedUser;
            }
            else
            {
                if (u.Password == result[0].Password)
                {
                    if(result[0].Authentication == 1)
                        return UserStatus.AuthenticatedAdmin;
                    else
                        return UserStatus.AuthentucatedUser;
                }
                else
                {
                    return UserStatus.NonAuthenticatedUser;
                }
            }
        }
    }
}