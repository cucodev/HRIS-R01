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
    public class EmployeeEduController : ApiController
    {
        private Employee db = new Employee();

        // GET: api/EmployeeEdu
        public IQueryable<emp_edu> Getemp_edu()
        {
            return db.emp_edu;
        }

        // GET: api/EmployeeEdu/5
        [ResponseType(typeof(emp_edu))]
        public async Task<IHttpActionResult> Getemp_edu(int id)
        {
            emp_edu emp_edu = await db.emp_edu.FindAsync(id);
            if (emp_edu == null)
            {
                return NotFound();
            }

            return Ok(emp_edu);
        }

        // PUT: api/EmployeeEdu/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putemp_edu(int id, emp_edu emp_edu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emp_edu.ID)
            {
                return BadRequest();
            }

            db.Entry(emp_edu).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!emp_eduExists(id))
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

        // POST: api/EmployeeEdu
        [ResponseType(typeof(emp_edu))]
        public async Task<IHttpActionResult> Postemp_edu(emp_edu emp_edu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.emp_edu.Add(emp_edu);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = emp_edu.ID }, emp_edu);
        }

        // DELETE: api/EmployeeEdu/5
        [ResponseType(typeof(emp_edu))]
        public async Task<IHttpActionResult> Deleteemp_edu(int id)
        {
            emp_edu emp_edu = await db.emp_edu.FindAsync(id);
            if (emp_edu == null)
            {
                return NotFound();
            }

            db.emp_edu.Remove(emp_edu);
            await db.SaveChangesAsync();

            return Ok(emp_edu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool emp_eduExists(int id)
        {
            return db.emp_edu.Count(e => e.ID == id) > 0;
        }
    }
}