using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRIS_R01.Models.Session;
using HRIS_R01.Models.Employee;
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

        private EmployeeEntities dbEmp = new EmployeeEntities();
        private UserEntities dbUser = new UserEntities();

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

        public IList<credentialViewModel> getViewModel(LogOnModel model)
        {
            /*
            var master = (from c in dbEmp.emp_master
                       where c.ID  == model.IDV
                       select(x => new credentialViewModel()
                       {
                           c.ID,
                           c.IDParent,
                           c.IDParentLevel,
                           c.NIP,
                           c.UID_ABSENCE,
                           c.Name,
                           c.NickName,
                           c.empPosition,
                           c.empJobLevel,
                           c.empDivision,
                           c.empDepartement,
                           c.empOfficeLocation
                       }).ToArray();

            var credUser = from x in credentialViewModel()

                           select new
                           {

                           }

            var credUser = from b in dbUser.emp_user
                       join c in master on b.IDV equals c.ID
                       select new
                       {
                           cID = c.ID,
                           cIDParent = c.IDParent,
                           cIDParentLevel = c.IDParentLevel,
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
                       };

            */
            var  credUser = dbEmp.emp_master
                .Where(c => c.ID == model.IDV)
                .Select(c => new
                        {
                            cID = c.ID,
                            cIDParent = c.IDParent,
                            cIDParentLevel = c.IDParentLevel,
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
                        })
                 .Select(x => new credentialViewModel()
                 {
                     cID = x.cID,
                     cIDParent = x.cIDParent.HasValue ? x.cIDParent.Value : -1,
                     cIDParentLevel = x.cIDParentLevel.HasValue ? x.cIDParentLevel.Value : -1,
                     cNIP = x.cNIP,
                     cUID_ABSENCE = x.cUID_ABSENCE,
                     cName = x.cName,
                     cNickName = x.cNickName,
                     cEmpPosition = x.cEmpPosition,
                     cEmpJobLevel = x.cEmpJobLevel,
                     cEmpDivision = x.cEmpDivision,
                     cEmpDepartement = x.cEmpDepartement,
                     cEmpOfficeLocation = x.cEmpOfficeLocation,
                     cUser = x.cUser,
                     cStart = x.cStart
                 });

            ViewData["UserCred"] = credUser;
            return credUser.ToList();
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
            }
        }

    }
}