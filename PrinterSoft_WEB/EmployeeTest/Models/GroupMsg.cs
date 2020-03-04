using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeTest.Models
{
    public class GroupMsg
    {
        [Key]
        public string UserID { set; get; }
        public string state { set; get; }
        public bool isRemove = false;
        public bool isManual { set; get; }
        public bool isClearFile { set; get; }
        public bool isChange { set; get; }
        public string LoadTime { set; get; }
        public string FinishTime { set; get; }
        public string DeleteTime { set; get; }
        public string SetTime { set; get; }
        public string CreateTime { set; get; }
        public bool isInit { set; get; }
        public string FileDirectory { set; get; }
        public bool isPrint { set; get; }
        public bool isShow { set; get; }
        public bool isAbort { set; get; }
        public bool isCanceling { set; get; }
        public string FileName { set; get; }
        public string GroupName { set; get; }
        public string Count { set; get; }
        public string VerForm { set; get; }
        public string PrintColor { set; get; }
        public string PaperType { set; get; }
        public string Printer { set; get; }
        public string PageCount { set; get; }
        public string InitPageCount { set; get; }
        public string Price { set; get; }
        public string InitPrice { set; get; }
        public string Time { set; get; }
        public string Area { set; get; }
        public string Phone { set; get; }
        public string QQ { set; get; }
        public string Note { set; get; }
        public string FullName { set; get; }
        public string PayType { set; get; }
        /// <summary>
        /// 取件
        /// </summary>
        public string PickUp { set; get; }
        public string MsgState { set; get; }
        public string MsgFinishState { set; get; }
    }
}