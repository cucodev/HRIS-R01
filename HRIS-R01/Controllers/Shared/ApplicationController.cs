using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRIS_R01.Models.Session;
using HRIS_R01.Models.Employee;
using System.Web.Routing;

namespace HRIS_R01.Controllers.Shared
{
    public class ApplicationController<TSource> : Controller
    {
        private const string LogOnSession = "LogOnSession";
        private const string ErrorController = "Error";
        private const string LogOnController = "Default";
        private const string LogOnAction = "Index";

        private EmployeeEntities dbEmp = new EmployeeEntities();

        protected ApplicationController()
        {

        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            /*important to check both, because logOnController should be access able with out any session*/
            if (!IsNonSessionController(requestContext) && !HasSession())
            {
                Rederect(requestContext, Url.Action(LogOnAction, LogOnController));
            }
        }

        private bool IsNonSessionController(RequestContext requestContext)
        {
            var currentController = requestContext.RouteData.Values["controller"].ToString().ToLower();
            var nonSessionedController = new List<string>() { ErrorController.ToLower(), LogOnController.ToLower() };
            return nonSessionedController.Contains(currentController);
        }

        private void Rederect(RequestContext requestContext, string action)
        {
            requestContext.HttpContext.Response.Clear();
            requestContext.HttpContext.Response.Redirect(action);
            requestContext.HttpContext.Response.End();
        }

       

        protected bool HasSession()
        {
            return Session[LogOnSession] != null;
        }

        protected TSource GetLogOnSessionModel()
        {
            return (TSource)this.Session[LogOnSession];
        }

        protected List<emp_master> GetUserCred()
        {
            //List<emp_master> list = new Session["UserCred"];
            var myList = (List<emp_master>)Session["UserCred"];

            //Store Current Logged Emp into Session
            ViewBag.UserCred = myList;
            return myList;
        }

        protected void SetLogOnSessionModel(TSource model, int id)
        {
            emp_master us = dbEmp.emp_master.Find(id);// dbEmp.emp_master.FindAsync(id);
            Session["UserCred"] = us;
            ViewData["UserCred"] = us;
            Session[LogOnSession] = model;
        }

        protected void AbandonSession()
        {
            if (HasSession())
            {
                Session.Abandon();
            }
        }

    }
}