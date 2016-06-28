using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRIS_R01.Models.Session;
//using HRIS_R01.Models.Employee;
using HRIS_R01.Models;
using HRIS_R01.ViewModel;
using System.Web.Routing;
 

namespace HRIS_R01.Controllers.Shared
{
    public class ApplicationController<TSource> : Controller
    {
        private const string LogOnSession = "LogOnSession";
        private const string ErrorController = "Error";
        private const string LogOnController = "Default";
        private const string LogOnAction = "Index";
        private const string UserCred = "UserCred";
        private const string ParentList = "ParentList";

        private MasterHRISEntities db = new MasterHRISEntities();

        //private EmployeeEntities dbEmp = new EmployeeEntities();
        //private UserEntities dbUser = new UserEntities();

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

        public void SetUserSession(LogOnModel model)
        {
            if (model.RememberMe)
            {
                var ASPCookie = Request.Cookies["ASP.NET_SessionId"];
                ASPCookie.Expires = DateTime.Now.AddDays(1);
                Response.SetCookie(ASPCookie);
            }

           

            var credUser = (from c in db.emp_master
                           where c.ID == model.IDV
                           select new credentialViewModel()
                           {
                               cID = c.ID,
                               cIDParent = c.IDParent.HasValue ? c.IDParent.Value : -1,
                               cIDParentLevel = c.IDParentLevel.HasValue ? c.IDParentLevel.Value : -1,
                               cNIP = c.NIP,
                               cUID_ABSENCE = c.UID_ABSENCE,
                               cName = c.Name,
                               cNickName = c.NickName,
                               cEmpPosition = c.empPosition,
                               cEmpJobLevel = c.empJobLevel,
                               cEmpDivision = c.empDivision,
                               cEmpDepartement = c.empDepartement,
                               cEmpOfficeLocation = c.empOfficeLocation,
                               cUser = model.UserName,
                               cStart = DateTime.Now
                           }).ToList<credentialViewModel>();
            //ViewData
            ViewData[UserCred] = credUser;

            Session[UserCred] = credUser;
            Session[ParentList] = SetParentListSession();

            UserSession();
            ParentListSession();
            //return credUser;
        }

        public List<masterListViewModel> SetParentListSession()
        {
            //var CategoryParents = db.categoryparents.FirstOrDefault();
            var CategoryParents = (from c in db.categoryparents
                            select new masterListViewModel()
                            {
                                cID = c.id,
                                cUID = c.uid.Trim(),
                                cUIDType = c.uidtype.TrimEnd(),
                                cUIDParent = c.uidparent.TrimEnd(),
                                cUIDName = c.uidname.TrimEnd()
                            }).ToList<masterListViewModel>();
            
            return CategoryParents;
        }

        public void ParentListSession()
        {
            System.Diagnostics.Debug.WriteLine("SET PARENT CATEGORY SESSION ======================================================================");
            ViewData[ParentList] = Session[ParentList];
                //System.Diagnostics.Debug.WriteLine("Parent " +  dt.cID + ':' + dt.cUIDName);
            System.Diagnostics.Debug.WriteLine("END PARENT CATEGORY SESSION ======================================================================");
        }

        public void UserSession()
        {
            System.Diagnostics.Debug.WriteLine("SET USER SESSION ======================================================================");

            var vm = (List<credentialViewModel>)Session[UserCred];
            foreach (var dt in vm)
            {
                ViewBag.cUser = dt.cUser;
                ViewBag.cIDV = dt.cID;
                ViewBag.cIDVParent = dt.cIDParent;
                ViewBag.cIDVParentLevel = dt.cIDParentLevel;
                ViewBag.cName = dt.cName;
                ViewBag.cNickName = dt.cNickName;
                ViewBag.cNIP = dt.cNIP;
                ViewBag.cEmpPosition = dt.cEmpPosition;
                ViewBag.cEmpJobLevel = dt.cEmpJobLevel;
                ViewBag.cEmpDivision = dt.cEmpDivision;
                ViewBag.cEmpDepartement = dt.cEmpDepartement;
                ViewBag.cEmpOfficeLocation = dt.cEmpOfficeLocation;


                System.Diagnostics.Debug.Write(" Value : ");
                System.Diagnostics.Debug.WriteLine(dt.cUser + ":" + dt.cID + ":" + dt.cIDParent + ":" + dt.cIDParentLevel);
            }
            System.Diagnostics.Debug.WriteLine("END USER SESSION ======================================================================");

        }

        protected void SetLogOnSessionModel(TSource model)
        {
           
            Session[LogOnSession] = model;
        }

        protected void AbandonSession()
        {
            if (HasSession())
            {
                Session.Abandon();
                
                //Session["UserCred"]
            }
        }

    }
}