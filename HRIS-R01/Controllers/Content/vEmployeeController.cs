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
        //LogOnModel current = new LogOnModel();
        credentialViewModel CredviewModel = new credentialViewModel();

        // GET: vEmployee
        public ActionResult Index()
        {
            var viewmodel = CredviewModel;

            foreach (var dt in ViewData["UserCred"] as  List<credentialViewModel>)
            {
                ViewBag.cUser = dt.cUser;
                ViewBag.cIDV = dt.cID;
                ViewBag.cIDParent = dt.cIDParent;
                ViewBag.cIDParentLevel = dt.cIDParentLevel;
            }
            

            
            return View(ViewData["UserCred"]);
        }

        public ActionResult HREmployeeManagement()
        {
            //ViewBag.cUsername = current.UserName;
            return View();
        }

    }
}