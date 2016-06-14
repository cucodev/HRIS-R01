using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRIS_R01.Models.Session;
using HRIS_R01.Controllers.Shared;

namespace HRIS_R01.Controllers.Content
{
    public class vEmployeeController : ApplicationController<LogOnModel>
    //public class vEmployeeController : Controller
    {
        LogOnModel current = new LogOnModel();

        // GET: vEmployee
        public ActionResult Index()
        {
            ViewData["sUsername"] = current.UserName;
            return View();
        }

        public ActionResult HREmployeeManagement()
        {
            return View();
        }

    }
}