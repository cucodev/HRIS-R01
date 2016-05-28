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
    public class EmployeeBirthController : ApiController
    {
        private Employee db = new Employee();

        // GET: api/EmployeeBirth
        public IQueryable<emp_birth> Getemp_birth()
        {
            return db.emp_birth;
        }

        // GET: api/EmployeeBirth/5
        [ResponseType(typeof(emp_birth))]
        public async Task<IHttpActionResult> Getemp_birth(int id)
        {
            emp_birth emp_birth = await db.emp_birth.FindAsync(id);
            if (emp_birth == null)
            {
                return NotFound();
            }

            return Ok(emp_birth);
        }

        // PUT: api/EmployeeBirth/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putemp_birth(int id, emp_birth emp_birth)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emp_birth.ID)
            {
                return BadRequest();
            }

            db.Entry(emp_birth).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!emp_birthExists(id))
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

        // POST: api/EmployeeBirth
        [ResponseType(typeof(emp_birth))]
        public async Task<IHttpActionResult> Postemp_birth(emp_birth emp_birth)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.emp_birth.Add(emp_birth);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = emp_birth.ID }, emp_birth);
        }

        // DELETE: api/EmployeeBirth/5
        [ResponseType(typeof(emp_birth))]
        public async Task<IHttpActionResult> Deleteemp_birth(int id)
        {
            emp_birth emp_birth = await db.emp_birth.FindAsync(id);
            if (emp_birth == null)
            {
                return NotFound();
            }

            db.emp_birth.Remove(emp_birth);
            await db.SaveChangesAsync();

            return Ok(emp_birth);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool emp_birthExists(int id)
        {
            return db.emp_birth.Count(e => e.ID == id) > 0;
        }
    }
}