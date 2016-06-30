using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRIS_R01.Models.Session;
using HRIS_R01.Controllers.Shared;

namespace HRIS_R01.Controllers.Content
{
    public class vMedicalClaimController : ApplicationController<LogOnModel>
    {
        // GET: vMedicalClaim
        public ActionResult Index()
        {
            ParentListSession();
            UserSession();
            return View();
        }

        public ActionResult HRMedicalClaim()
        {
            ParentListSession();
            UserSession();
            return View();
        }
    }
}