using EmployeeTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Http;
using System.Web.Mvc;

namespace EmployeeTest.Controllers
{
    public class MainController : Controller
    {
        [Authorize]
        // GET: Main
        public ActionResult Index()
        {
            GroupMsgListViewModel groupMsgListViewModel = new GroupMsgListViewModel();
            GroupMsgBusinessLayer groupMsgBusinessLayer = new GroupMsgBusinessLayer();
            var tmpData = groupMsgBusinessLayer.GetGroupMsgs();
            groupMsgListViewModel.GroupMsgs = new List<GroupMsgViewModel>();
            foreach (var v in tmpData)
            {
                var tmp = new GroupMsgViewModel {
                    Area = v.Area,
                    Pickup = v.PickUp,
                    UserID = v.UserID,
                    time = v.SetTime,
                    Price = v.Price,
                    Note = v.Note,
                    Phone = v.Phone,
                    QQ = v.QQ
                };
                switch (v.MsgFinishState)
                {
                    case "phone":
                        tmp.UserIDColor = "dimgrey";
                        break;
                    case "message":
                        tmp.UserIDColor = "darkgray";
                        break;
                    default:
                        tmp.UserIDColor = "black";
                        break;
                }
                switch (v.PickUp)
                {
                    case "自取":
                        tmp.PickupColor = "blue";
                        break;
                    case "取件":
                        tmp.PickupColor = "green";
                        break;
                    case "无人":
                        tmp.PickupColor = "red";
                        break;
                    case "延时":
                        tmp.PickupColor = "gray";
                        break;
                    default:
                        tmp.PickupColor = "black";
                        break;
                }
                tmp.AreaColor = "dodgerblue";
                tmp.MsgStateImg = v.MsgState;
                //if (v.MsgState == "未读")
                //{
                //    tmp.MsgStateImg = @"~/image/phone.png";
                //}
                //else
                //{
                //    tmp.MsgStateImg = @"~/image/u2404.png";
                //}
                groupMsgListViewModel.GroupMsgs.Add(tmp);
            }
            ViewBag.GroupMsgListViewModel = groupMsgListViewModel;
            return View("Index",groupMsgListViewModel);
        }

        [Authorize]
        // GET: Main
        public ActionResult PostMessage()
        {
            return new EmptyResult();
        }
    }
}