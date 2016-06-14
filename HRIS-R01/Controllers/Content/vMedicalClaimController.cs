using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS_R01.Controllers.Content
{
    public class vMedicalClaimController : Controller
    {
        // GET: vMedicalClaim
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HRMedicalClaim()
        {
            return View();
        }
    }
}