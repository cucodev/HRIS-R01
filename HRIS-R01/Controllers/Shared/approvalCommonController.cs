using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRIS_R01.Models.Form;

namespace HRIS_R01.Controllers.Shared
{
    public class approvalCommonController : Controller
    {
        private ApprovalEntities db = new ApprovalEntities();

        // GET: approvalCommon
        public ActionResult Index()
        {
            return View(db.approvals.ToList());
        }

        // GET: approvalCommon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            approval approval = db.approvals.Find(id);
            if (approval == null)
            {
                return HttpNotFound();
            }
            return View(approval);
        }

        // GET: approvalCommon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: approvalCommon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,approvalStatus,approvalIdv,approvalQ,approvalMail,approvalDate,rowStatus,rowDate")] approval approval)
        {
            if (ModelState.IsValid)
            {
                db.approvals.Add(approval);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(approval);
        }

        


        // GET: approvalCommon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            approval approval = db.approvals.Find(id);
            if (approval == null)
            {
                return HttpNotFound();
            }
            return View(approval);
        }

        // POST: approvalCommon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,approvalStatus,approvalIdv,approvalQ,approvalMail,approvalDate,rowStatus,rowDate")] approval approval)
        {
            if (ModelState.IsValid)
            {
                db.Entry(approval).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(approval);
        }

        // GET: approvalCommon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            approval approval = db.approvals.Find(id);
            if (approval == null)
            {
                return HttpNotFound();
            }
            return View(approval);
        }

        // POST: approvalCommon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            approval approval = db.approvals.Find(id);
            db.approvals.Remove(approval);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
