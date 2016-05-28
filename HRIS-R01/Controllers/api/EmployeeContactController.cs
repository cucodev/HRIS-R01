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
    public class EmployeeContactController : ApiController
    {
        private Employee db = new Employee();

        // GET: api/EmployeeContact
        public IQueryable<emp_contact> Getemp_contact()
        {
            return db.emp_contact;
        }

        // GET: api/EmployeeContact/5
        [ResponseType(typeof(emp_contact))]
        public async Task<IHttpActionResult> Getemp_contact(int id)
        {
            emp_contact emp_contact = await db.emp_contact.FindAsync(id);
            if (emp_contact == null)
            {
                return NotFound();
            }

            return Ok(emp_contact);
        }

        // PUT: api/EmployeeContact/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putemp_contact(int id, emp_contact emp_contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emp_contact.ID)
            {
                return BadRequest();
            }

            db.Entry(emp_contact).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!emp_contactExists(id))
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

        // POST: api/EmployeeContact
        [ResponseType(typeof(emp_contact))]
        public async Task<IHttpActionResult> Postemp_contact(emp_contact emp_contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.emp_contact.Add(emp_contact);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = emp_contact.ID }, emp_contact);
        }

        // DELETE: api/EmployeeContact/5
        [ResponseType(typeof(emp_contact))]
        public async Task<IHttpActionResult> Deleteemp_contact(int id)
        {
            emp_contact emp_contact = await db.emp_contact.FindAsync(id);
            if (emp_contact == null)
            {
                return NotFound();
            }

            db.emp_contact.Remove(emp_contact);
            await db.SaveChangesAsync();

            return Ok(emp_contact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool emp_contactExists(int id)
        {
            return db.emp_contact.Count(e => e.ID == id) > 0;
        }
    }
}