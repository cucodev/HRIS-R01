using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRIS_R01.Models.Form;

namespace HRIS_R01.Controllers.Shared
{
    public class approvalSharedController : Controller
    {
        private ApprovalEntities db = new ApprovalEntities();

        // GET: approvalShared
        public async Task<ActionResult> Index()
        {
            return View(await db.approvals.ToListAsync());
        }

        // GET: approvalShared/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            approval approval = await db.approvals.FindAsync(id);
            if (approval == null)
            {
                return HttpNotFound();
            }
            return View(approval);
        }

        // GET: approvalShared/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: approvalShared/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,approvalStatus,approvalIdv,approvalQ,approvalMail,approvalDate,rowStatus,rowDate")] approval approval)
        {
            if (ModelState.IsValid)
            {
                db.approvals.Add(approval);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(approval);
        }

        // GET: approvalShared/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            approval approval = await db.approvals.FindAsync(id);
            if (approval == null)
            {
                return HttpNotFound();
            }
            return View(approval);
        }

        // POST: approvalShared/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,approvalStatus,approvalIdv,approvalQ,approvalMail,approvalDate,rowStatus,rowDate")] approval approval)
        {
            if (ModelState.IsValid)
            {
                db.Entry(approval).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(approval);
        }

        // GET: approvalShared/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            approval approval = await db.approvals.FindAsync(id);
            if (approval == null)
            {
                return HttpNotFound();
            }
            return View(approval);
        }

        // POST: approvalShared/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            approval approval = await db.approvals.FindAsync(id);
            db.approvals.Remove(approval);
            await db.SaveChangesAsync();
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
