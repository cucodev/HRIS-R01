using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRIS_R01.Models.Common;
using HRIS_R01.Models.Session;
using HRIS_R01.Controllers.Shared;

namespace HRIS_R01.Controllers
{
    public class DefaultController : ApplicationController<LogOnModel>
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                /*Set model to session*/
                SetLogOnSessionModel(model);
                /*Shows the session*/
                LogOnModel sessionModel = GetLogOnSessionModel();
                return RedirectToAction("Index", "vEmployee");
            }
            return View(model);
        }

        public ActionResult LogOff()
        {
            /*distroy current session and go to login page*/
            AbandonSession();
            return RedirectToAction("Index", "LogOn");
        }
    }
}