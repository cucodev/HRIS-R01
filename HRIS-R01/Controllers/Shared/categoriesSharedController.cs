using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRIS_R01.Models;

namespace HRIS_R01.Controllers.Shared
{
    public class categoriesSharedController : Controller
    {
        //private ListCategory db = new ListCategory();
        //private category db = new category();
        private MasterHRISEntities db = new MasterHRISEntities();

        // GET by ID UID = eg "txLeave or txMedical"
        public int getCatID(string uid)
        {
            //category category = db.categories.Find(uid);

            var uidResults = db.categories
                        .Where(b => b.uid == uid)
                         .FirstOrDefault();

            //ViewBag.uidparent = new SelectList(db.categoryparents, "id", "uid", category.uidparent);
            return (uidResults.id);
        }


    }
}
