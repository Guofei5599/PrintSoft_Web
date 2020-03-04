using EmployeeTest.Data_Access_Layer;
using EmployeeTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeTest.ViewModels
{
    public class GroupMsgBusinessLayer
    {
        public List<GroupMsg> GetGroupMsgs()
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            return salesDal.GroupMsgs.ToList();
        }
        public List<FileMsg> GetFileMsgs(string UserID)
        {
            try
            {
                SalesERPDAL salesDal = new SalesERPDAL();
                return salesDal.FileMsgs.Where(t => t.UserID == UserID).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public string InsertGroupMsgs(InsertDataViewModel data)
        {
            try
            {
                using (SalesERPDAL salesDal = new SalesERPDAL())
                {
                    GroupMsg result = salesDal.GroupMsgs.Add(data.groupMsg);
                    FileMsg fResult = salesDal.FileMsgs.Add(data.fileMsg);
                    salesDal.SaveChanges();
                    return "Success";
                }
            }
            catch (Exception ex)
            {
                return "Fail:" + ex.Message;
            }
        }
    }
}