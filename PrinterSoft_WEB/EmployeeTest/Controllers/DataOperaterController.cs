using EmployeeTest.Models;
using EmployeeTest.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeTest.Controllers
{
    public class DataOperaterController : ApiController
    {
        [HttpGet]
        public IHttpActionResult DoAction()
        {
            return Json<string>("123");
        }
        [HttpGet]
        public IHttpActionResult GetGroupMsgs()
        {
            GroupMsgBusinessLayer tmpGroupMsgBusinessLayer = new GroupMsgBusinessLayer();
            var tmp = tmpGroupMsgBusinessLayer.GetGroupMsgs();
            return Json<List<GroupMsg>>(tmp);
        }
        [HttpGet]
        public IHttpActionResult GetFileMsgs(string UserID)
        {
            GroupMsgBusinessLayer tmpGroupMsgBusinessLayer = new GroupMsgBusinessLayer();
            var tmp = tmpGroupMsgBusinessLayer.GetFileMsgs(UserID);
            return Json<List<FileMsg>>(tmp);
        }
        [HttpPost]
        public IHttpActionResult InsertGroupMsgs(InsertDataViewModel tmpData)
        {
            GroupMsgBusinessLayer tmpGroupMsgBusinessLayer = new GroupMsgBusinessLayer();
            string result = tmpGroupMsgBusinessLayer.InsertGroupMsgs(tmpData);
            return Json<string>(result);
        }
    }
}
