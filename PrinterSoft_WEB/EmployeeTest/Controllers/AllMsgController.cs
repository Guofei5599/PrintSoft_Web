using EmployeeTest.Models;
using EmployeeTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeTest.Controllers
{
    public class AllMsgController : Controller
    {
        // GET: AllMsg
        [Authorize]
        public ActionResult Index(GroupMsgViewModel msg)
        {
            FileMsgListViewModel fileMsgListViewModel = new FileMsgListViewModel();
            GroupMsgBusinessLayer groupMsgBusinessLayer = new GroupMsgBusinessLayer();
            var tmp = groupMsgBusinessLayer.GetFileMsgs(msg.UserID);
            if (tmp == null)
                return new EmptyResult();
            fileMsgListViewModel.FileMsgs = new List<FileMsgViewModel>();
            foreach (var v in tmp)
            {
                FileMsgViewModel fileMsgViewModel = new FileMsgViewModel()
                {
                    Color = v.PrintColor,
                    Count = v.Count,
                    Pages = v.PageCount,
                    FileName = v.FileName,
                    Note = v.Note,
                    Price = v.Price,
                    VerForm = v.VerForm
                };
                fileMsgListViewModel.FileMsgs.Add(fileMsgViewModel);
            }
            fileMsgListViewModel.UserID = msg.UserID;
            fileMsgListViewModel.Price = msg.Price;
            fileMsgListViewModel.Note = msg.Note;
            fileMsgListViewModel.Phone = msg.Phone;
            fileMsgListViewModel.QQ = msg.QQ;
            ViewBag.FileMsgListViewModel = fileMsgListViewModel;
            return View();
        }
    }
}