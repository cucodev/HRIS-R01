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
    public class EmployeeAddressController : ApiController
    {
        private Employee db = new Employee();

        // GET: api/EmployeeAddress
        public IQueryable<emp_address> Getemp_address()
        {
            return db.emp_address;
        }

        // GET: api/EmployeeAddress/5
        [ResponseType(typeof(emp_address))]
        public async Task<IHttpActionResult> Getemp_address(int id)
        {
            emp_address emp_address = await db.emp_address.FindAsync(id);
            if (emp_address == null)
            {
                return NotFound();
            }

            return Ok(emp_address);
        }

        // PUT: api/EmployeeAddress/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putemp_address(int id, emp_address emp_address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emp_address.ID)
            {
                return BadRequest();
            }

            db.Entry(emp_address).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!emp_addressExists(id))
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

        // POST: api/EmployeeAddress
        [ResponseType(typeof(emp_address))]
        public async Task<IHttpActionResult> Postemp_address(emp_address emp_address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.emp_address.Add(emp_address);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = emp_address.ID }, emp_address);
        }

        // DELETE: api/EmployeeAddress/5
        [ResponseType(typeof(emp_address))]
        public async Task<IHttpActionResult> Deleteemp_address(int id)
        {
            emp_address emp_address = await db.emp_address.FindAsync(id);
            if (emp_address == null)
            {
                return NotFound();
            }

            db.emp_address.Remove(emp_address);
            await db.SaveChangesAsync();

            return Ok(emp_address);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool emp_addressExists(int id)
        {
            return db.emp_address.Count(e => e.ID == id) > 0;
        }
    }
}