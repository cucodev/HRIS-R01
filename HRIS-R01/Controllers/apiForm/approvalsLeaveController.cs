using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HRIS_R01.Models;
//using HRIS_R01.Models.Form;

namespace HRIS_R01.Controllers.apiForm
{
    public class approvalsLeaveController : ApiController
    {
        //private ApprovalEntities db = new ApprovalEntities();
        private MasterHRISEntities db = new MasterHRISEntities();
        // GET: api/approvalsLeave
        public IQueryable<approval> Getapprovals()
        {

            return db.approvals;
        }

        // GET: api/approvalsLeave/5
        [ResponseType(typeof(approval))]
        public async Task<IHttpActionResult> Getapproval(int id)
        {
            approval approval = await db.approvals.FindAsync(id);
            if (approval == null)
            {
                return NotFound();
            }

            return Ok(approval);
        }

        // PUT: api/approvalsLeave/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putapproval(int id, approval approval)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != approval.id)
            {
                return BadRequest();
            }

            db.Entry(approval).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!approvalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/approvalsLeave
        [ResponseType(typeof(approval))]
        public async Task<IHttpActionResult> Postapproval(approval approval)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.approvals.Add(approval);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = approval.id }, approval);
        }

        // DELETE: api/approvalsLeave/5
        [ResponseType(typeof(approval))]
        public async Task<IHttpActionResult> Deleteapproval(int id)
        {
            approval approval = await db.approvals.FindAsync(id);
            if (approval == null)
            {
                return NotFound();
            }

            db.approvals.Remove(approval);
            await db.SaveChangesAsync();

            return Ok(approval);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool approvalExists(int id)
        {
            return db.approvals.Count(e => e.id == id) > 0;
        }
    }
}