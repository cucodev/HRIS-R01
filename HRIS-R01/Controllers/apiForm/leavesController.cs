using System;
using System.Globalization;
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
//using HRIS_R01.Models.Form;
using HRIS_R01.Models;
using HRIS_R01.Controllers.Shared;

namespace HRIS_R01.Controllers.apiForm
{
    public class leavesController : ApiController
    {
        //private LeaveEntities db = new LeaveEntities();
        //private ApprovalEntities dbApp = new ApprovalEntities();
        private MasterHRISEntities db = new MasterHRISEntities();


        approvalCommonController approve = new approvalCommonController();
        categoriesSharedController categoryType = new categoriesSharedController();

        DateTime localDate = DateTime.Now;
        
        // GET: api/leaves
        public IQueryable<leave> Getleaves()
        {
            //System.Diagnostics.Debug.WriteLine("Getleaves triggered");
            return db.leaves;
        }

        // GET: api/leaves/5
        [ResponseType(typeof(leave))]
        public async Task<IHttpActionResult> Getleave(int id)
        {
            leave leave = await db.leaves.FindAsync(id);
            if (leave == null)
            {
                return NotFound();
            }

            return Ok(leave);
        }

        // GET: api/leavesByApprovalID/5
        [ResponseType(typeof(leave))]
        [Route("api/GetLeaveByApproval/{id}")]
        [ActionName("GetLeaveByApproval")]
        public async Task<IHttpActionResult> GetLeaveByApproval(int id)
        {
            System.Diagnostics.Debug.WriteLine(db.Database.Log);
            leave leave = await db.leaves
                            .Where(b => b.approvalID == id)
                            .FirstOrDefaultAsync();
            //leave leave = await db.leaves.FindAsync(id);
            if (leave == null)
            {
                return NotFound();
            }

            return Ok(leave);
        }


        // PUT: api/leaves/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putleave(int id, [FromBody]leave leave)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != leave.id)
            {
                return BadRequest();
            }


            leave.rowDate = localDate;
            //var beUpdate = db.leaves.Where(s => s.id == leave.id).FirstOrDefault<leave>();
            //beUpdate.rowDate = localDate;
            //db.Entry(beUpdate).CurrentValues.SetValues
            System.Diagnostics.Debug.WriteLine("local date : " + leave.rowDate + " : ID = " + leave.id);
            db.Entry(leave).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!leaveExists(id))
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

        // POST: api/leaves
        [ResponseType(typeof(leave))]
        public async Task<IHttpActionResult> Postleave(leave leave)
        {
            //Datetime for rowDate column
            DateTime parsedDate;
            DateTime.TryParseExact(localDate.ToString(), "yyyy/M/d HH:s:ss", null, DateTimeStyles.None, out parsedDate);


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Get Email of Approval ID

            try
            {
                DateTime dt = new DateTime();
                

                approval app = new approval();
                //app.id = null;
                app.approvalIdv = leave.idvApproval.HasValue ? leave.idvApproval.Value : 0;
                app.approvalType = categoryType.getCatID("txLeave");
                app.approvalStatus = categoryType.getCatID("txSubmit").ToString();
                app.approvalMail = "";
                app.approvalQ = 0;
                app.approvalDate = null;
                app.rowStatus = "Active";
                app.rowDate = String.Format("{0:d/M/yyyy HH:mm:ss}", dt);
                //app.rowDate = localDate.ToString();

                //Save New Approval to DB
                db.approvals.Add(app);
                db.SaveChanges();

                //Assign last inserted Approval ID to Leave
                leave.approvalID = app.id;

            }
                catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            //Assign datetime to rowDate
            //leave.rowDate = parsedDate;

            db.Entry(leave).State = System.Data.Entity.EntityState.Modified;

            System.Diagnostics.Debug.WriteLine("Today is " + localDate.ToString("yyyy/M/d HH:s:ss"));
            System.Diagnostics.Debug.WriteLine("local date : " + leave.rowDate + " : ID = " + leave.id);

            db.leaves.Add(leave);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = leave.id }, leave);
        }

        // DELETE: api/leaves/5
        [ResponseType(typeof(leave))]
        public async Task<IHttpActionResult> Deleteleave(int id)
        {
            leave leave = await db.leaves.FindAsync(id);
            if (leave == null)
            {
                return NotFound();
            }

            db.leaves.Remove(leave);
            await db.SaveChangesAsync();

            return Ok(leave);
        }


        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool leaveExists(int id)
        {
            return db.leaves.Count(e => e.id == id) > 0;
        }
    }
}