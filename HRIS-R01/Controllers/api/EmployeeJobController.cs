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

namespace HRIS_R01.Controllers.api
{
    public class EmployeeJobController : ApiController
    {
        private Employee db = new Employee();

        // GET: api/EmployeeJob
        public IQueryable<emp_job> Getemp_job()
        {
            return db.emp_job;
        }

        // GET: api/EmployeeJob/5
        [ResponseType(typeof(emp_job))]
        public async Task<IHttpActionResult> Getemp_job(int id)
        {
            emp_job emp_job = await db.emp_job.FindAsync(id);
            if (emp_job == null)
            {
                return NotFound();
            }

            return Ok(emp_job);
        }

        // PUT: api/EmployeeJob/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putemp_job(int id, emp_job emp_job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emp_job.ID)
            {
                return BadRequest();
            }

            db.Entry(emp_job).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!emp_jobExists(id))
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

        // POST: api/EmployeeJob
        [ResponseType(typeof(emp_job))]
        public async Task<IHttpActionResult> Postemp_job(emp_job emp_job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.emp_job.Add(emp_job);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = emp_job.ID }, emp_job);
        }

        // DELETE: api/EmployeeJob/5
        [ResponseType(typeof(emp_job))]
        public async Task<IHttpActionResult> Deleteemp_job(int id)
        {
            emp_job emp_job = await db.emp_job.FindAsync(id);
            if (emp_job == null)
            {
                return NotFound();
            }

            db.emp_job.Remove(emp_job);
            await db.SaveChangesAsync();

            return Ok(emp_job);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool emp_jobExists(int id)
        {
            return db.emp_job.Count(e => e.ID == id) > 0;
        }
    }
}