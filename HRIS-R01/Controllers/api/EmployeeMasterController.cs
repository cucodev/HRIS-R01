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
    public class EmployeeMasterController : ApiController
    {
        private Employee db = new Employee();

        // GET: api/EmployeeMasterr
        public IQueryable<emp_master> Getemp_master()
        {
            return db.emp_master;
        }

        // GET: api/EmployeeMasterr/5
        [ResponseType(typeof(emp_master))]
        public async Task<IHttpActionResult> Getemp_master(int id)
        {
            emp_master emp_master = await db.emp_master.FindAsync(id);
            if (emp_master == null)
            {
                return NotFound();
            }

            return Ok(emp_master);
        }

        // PUT: api/EmployeeMasterr/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putemp_master(int id, emp_master emp_master)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emp_master.ID)
            {
                return BadRequest();
            }

            db.Entry(emp_master).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!emp_masterExists(id))
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

        // POST: api/EmployeeMasterr
        [ResponseType(typeof(emp_master))]
        public async Task<IHttpActionResult> Postemp_master(emp_master emp_master)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.emp_master.Add(emp_master);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = emp_master.ID }, emp_master);
        }

        // DELETE: api/EmployeeMasterr/5
        [ResponseType(typeof(emp_master))]
        public async Task<IHttpActionResult> Deleteemp_master(int id)
        {
            emp_master emp_master = await db.emp_master.FindAsync(id);
            if (emp_master == null)
            {
                return NotFound();
            }

            db.emp_master.Remove(emp_master);
            await db.SaveChangesAsync();

            return Ok(emp_master);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool emp_masterExists(int id)
        {
            return db.emp_master.Count(e => e.ID == id) > 0;
        }
    }
}