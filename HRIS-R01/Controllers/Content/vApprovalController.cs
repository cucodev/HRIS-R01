using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS_R01.Controllers.Content
{
    public class vApprovalController : Controller
    {
        // GET: vApproval
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HRApproval()
        {
            return View();
        }

        public ActionResult Superior()
        {
            return View();
        }
    }
}