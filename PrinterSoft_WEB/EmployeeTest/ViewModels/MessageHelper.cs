using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using qcloudsms_csharp;
using qcloudsms_csharp.json;
using qcloudsms_csharp.httpclient;
using EmployeeTest.Models;

namespace EmployeeTest.ViewModels
{
    public class MessageHelper
    {
        //string pwd = System.Configuration.ConfigurationManager.AppSettings["Pwd"];
        public SmsSingleSenderResult SmsSingleSenderFunc(MsgParam msgParam)
        {
            try
            {
                SmsSingleSender ssender = new SmsSingleSender(msgParam.appid, msgParam.appkey);
                var result = ssender.sendWithParam("86", msgParam.phoneNumbers[0],
                    msgParam.templateId, new[] { "5678" }, msgParam.smsSign, "", "");  // 签名参数不能为空串
                return result;
            }
            catch (JSONException e)
            {
                return new SmsSingleSenderResult()
                {
                    result = 0,
                    errMsg = e.Message
                };
            }
            catch (HTTPException e)
            {
                return new SmsSingleSenderResult()
                {
                    result = 0,
                    errMsg = e.Message
                };
            }
            catch (Exception e)
            {
                return new SmsSingleSenderResult()
                {
                    result = 0,
                    errMsg = e.Message
                };
            }
        }
        public SmsMultiSenderResult SmsMultiSenderFunc(MsgParam msgParam)
        {
            try
            {
                SmsMultiSender ssender = new SmsMultiSender(msgParam.appid, msgParam.appkey);
                var result = ssender.sendWithParam("86", msgParam.phoneNumbers,
                    msgParam.templateId, new[] { "5678" }, msgParam.smsSign, "", "");  // 签名参数不能为空串
                return result;
            }
            catch (JSONException e)
            {
                return new SmsMultiSenderResult()
                {
                    result = 0,
                    errMsg = e.Message
                };
            }
            catch (HTTPException e)
            {
                return new SmsMultiSenderResult()
                {
                    result = 0,
                    errMsg = e.Message
                };
            }
            catch (Exception e)
            {
                return new SmsMultiSenderResult()
                {
                    result = 0,
                    errMsg = e.Message
                };
            }
        }
    }
}