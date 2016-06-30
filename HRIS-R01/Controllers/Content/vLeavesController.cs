using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRIS_R01.Models.Session;
using HRIS_R01.Controllers.Shared;

namespace HRIS_R01.Controllers.Content
{
    public class vLeavesController : ApplicationController<LogOnModel>
    {
        // GET: vLeaves
        public ActionResult Index()
        {
            ParentListSession();
            UserSession();
            return View();
        }

        public void getApproval()
        {
            //
        }

        public void sentApproval()
        {
            //
        }

        public void getApprovalStatus()
        {
            //
        }

    }
}