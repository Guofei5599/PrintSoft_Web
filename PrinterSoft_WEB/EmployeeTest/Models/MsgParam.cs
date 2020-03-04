using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeTest.Models
{
    public class MsgParam
    {
        /// <summary>
        /// 短信应用SDK AppID
        /// </summary>
        public int appid { set; get; }
        /// <summary>
        /// 短信应用SDK AppKey
        /// </summary>
        public string appkey { set; get; }
        /// <summary>
        /// 需要发送短信的手机号码
        /// </summary>
        public string[] phoneNumbers { set; get; }
        /// <summary>
        /// 短信模板ID，需要在短信应用中申请
        /// </summary>
        public int templateId { set; get; }
        /// <summary>
        /// 签名
        /// </summary>
        public string smsSign { set; get; }
    }
}