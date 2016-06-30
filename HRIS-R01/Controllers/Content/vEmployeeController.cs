using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRIS_R01.Models.Session;
using HRIS_R01.Controllers.Shared;
using HRIS_R01.ViewModel;

namespace HRIS_R01.Controllers.Content
{
    public class vEmployeeController : ApplicationController<LogOnModel>
    //public class vEmployeeController : Controller
    {
       
        // GET: vEmployee
        
        public ActionResult Index()
        {
            UserSession();
            ParentListSession();
            return View();
        }

        public ActionResult HREmployeeManagement()
        {
            //Session User Added
            UserSession();
            ParentListSession();
            return View();
        }

    }
}