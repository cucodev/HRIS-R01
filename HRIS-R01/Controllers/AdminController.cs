using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRIS_R01.Models;

namespace HRIS_R01.Controllers
{
    public class AdminController : Controller
    {
        
        // GET: Admin
        public ActionResult Console()
        {
            category cat = new category();

            return View(cat);
        }
    }
}