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
using HRIS_R01.Controllers.Shared;

namespace HRIS_R01.Controllers.apiForm
{
    public class medicalsController : ApiController
    {
        private MasterHRISEntities db = new MasterHRISEntities();

        // GET: api/medicals
        public IQueryable<medical> Getmedicals()
        {
            return db.medicals;
        }

        // GET: api/medicals/5
        [ResponseType(typeof(medical))]
        public async Task<IHttpActionResult> Getmedical(int id)
        {
            medical medical = await db.medicals.FindAsync(id);
            if (medical == null)
            {
                return NotFound();
            }

            return Ok(medical);
        }

        // PUT: api/medicals/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putmedical(int id, medical medical)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medical.id)
            {
                return BadRequest();
            }

            db.Entry(medical).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!medicalExists(id))
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

        // POST: api/medicals
        [ResponseType(typeof(medical))]
        public async Task<IHttpActionResult> Postmedical(medical medical)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                DateTime dt = new DateTime();

                approvalCommonController approve = new approvalCommonController();
                categoriesSharedController categoryType = new categoriesSharedController();


                approval app = new approval();
                //app.id = null;
                app.approvalIdv = medical.idvApproval;// medical.idvApproval.Equals = medical.idvApprovalHasValue ? leave.idvApproval.Value : 0;
                app.approvalType = categoryType.getCatID("txMedical");
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
                medical.medicalID = app.id;

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            //db.Entry(medical).State = System.Data.Entity.EntityState.Modified;


            db.medicals.Add(medical);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = medical.id }, medical);
        }

        // DELETE: api/medicals/5
        [ResponseType(typeof(medical))]
        public async Task<IHttpActionResult> Deletemedical(int id)
        {
            medical medical = await db.medicals.FindAsync(id);
            if (medical == null)
            {
                return NotFound();
            }

            db.medicals.Remove(medical);
            await db.SaveChangesAsync();

            return Ok(medical);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool medicalExists(int id)
        {
            return db.medicals.Count(e => e.id == id) > 0;
        }
    }
}