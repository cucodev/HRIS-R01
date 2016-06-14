using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRIS_R01.Models.Session;
using HRIS_R01.Controllers.Shared;

namespace HRIS_R01.Controllers.Content
{
    public class vTimesheetsController : ApplicationController<LogOnModel>
    {
        // GET: vTimesheets
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HRTimesheets()
        {
            return View();
        }
    }
}