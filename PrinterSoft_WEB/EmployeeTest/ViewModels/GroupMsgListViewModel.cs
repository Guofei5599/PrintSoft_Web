using EmployeeTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeTest.ViewModels
{
    public class GroupMsgListViewModel : BaseViewModel
    {
        public List<GroupMsgViewModel> GroupMsgs { set; get; }
        public string MsgState { set; get; }
        public string DeceiveId { set;get;}
    }
}