using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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

        public ActionResult temp1()
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
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (this.Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return this.Redirect(returnUrl);
                    }

                    return this.RedirectToAction("Index", "vEmployee");
                }    
            }
            this.ModelState.AddModelError(string.Empty, "The user name or password provided is incorrect.");
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