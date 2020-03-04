using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using ZXing;

namespace EmployeeTest.Controllers
{
    public class QRcodeController : Controller
    {
        // GET: QRcode
        [Authorize]
        [HttpPost]
        public ActionResult QRcodeDecode(string text)
        {
            try
            {
                if (text.Length != 13)
                {
                    return Content(" Barcode Length is Error");
                }
                else
                {
                    string UserID = text.Substring(0,6);

                }
                return Content(text);
            }
            catch(Exception ex)
            {
                return Content("no");
            }
        }
        [Authorize]
        public ActionResult Result(string BarCode)
        {
            return RedirectToAction("Index", "Main");
        }
    }
}