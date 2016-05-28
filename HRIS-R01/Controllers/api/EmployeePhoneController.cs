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
    public class EmployeePhoneController : ApiController
    {
        private Employee db = new Employee();

        // GET: api/EmployeePhone
        public IQueryable<emp_phone> Getemp_phone()
        {
            return db.emp_phone;
        }

        // GET: api/EmployeePhone/5
        [ResponseType(typeof(emp_phone))]
        public async Task<IHttpActionResult> Getemp_phone(int id)
        {
            emp_phone emp_phone = await db.emp_phone.FindAsync(id);
            if (emp_phone == null)
            {
                return NotFound();
            }

            return Ok(emp_phone);
        }

        // PUT: api/EmployeePhone/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putemp_phone(int id, emp_phone emp_phone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emp_phone.ID)
            {
                return BadRequest();
            }

            db.Entry(emp_phone).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!emp_phoneExists(id))
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

        // POST: api/EmployeePhone
        [ResponseType(typeof(emp_phone))]
        public async Task<IHttpActionResult> Postemp_phone(emp_phone emp_phone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.emp_phone.Add(emp_phone);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = emp_phone.ID }, emp_phone);
        }

        // DELETE: api/EmployeePhone/5
        [ResponseType(typeof(emp_phone))]
        public async Task<IHttpActionResult> Deleteemp_phone(int id)
        {
            emp_phone emp_phone = await db.emp_phone.FindAsync(id);
            if (emp_phone == null)
            {
                return NotFound();
            }

            db.emp_phone.Remove(emp_phone);
            await db.SaveChangesAsync();

            return Ok(emp_phone);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool emp_phoneExists(int id)
        {
            return db.emp_phone.Count(e => e.ID == id) > 0;
        }
    }
}