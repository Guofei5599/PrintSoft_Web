using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeTest.Controllers
{
    public class BarcodeController : Controller
    {
        // GET: Barcode
        [Authorize]
        public ActionResult Index(string DeceiveId)
        {
            
            return View();
        }
        [Authorize]
        public ActionResult BarCode()
        {
            return View();
        }
    }
}