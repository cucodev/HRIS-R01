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
    public class timesheetsController : ApiController
    {
        //private TimesheetModel db = new TimesheetModel();
        private MasterHRISEntities db = new MasterHRISEntities();
        // GET: api/timesheets
        public IQueryable<timesheet> Gettimesheets()
        {
            return db.timesheets;
        }

        // GET: api/timesheets/5
        [ResponseType(typeof(timesheet))]
        public async Task<IHttpActionResult> Gettimesheet(int id)
        {
            timesheet timesheet = await db.timesheets.FindAsync(id);
            if (timesheet == null)
            {
                return NotFound();
            }

            return Ok(timesheet);
        }

        // PUT: api/timesheets/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttimesheet(int id, timesheet timesheet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != timesheet.ID)
            {
                return BadRequest();
            }

            db.Entry(timesheet).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!timesheetExists(id))
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

        // POST: api/timesheets
        [ResponseType(typeof(timesheet))]
        public async Task<IHttpActionResult> Posttimesheet(timesheet timesheet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.timesheets.Add(timesheet);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (timesheetExists(timesheet.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = timesheet.ID }, timesheet);
        }

        // DELETE: api/timesheets/5
        [ResponseType(typeof(timesheet))]
        public async Task<IHttpActionResult> Deletetimesheet(int id)
        {
            timesheet timesheet = await db.timesheets.FindAsync(id);
            if (timesheet == null)
            {
                return NotFound();
            }

            db.timesheets.Remove(timesheet);
            await db.SaveChangesAsync();

            return Ok(timesheet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool timesheetExists(int id)
        {
            return db.timesheets.Count(e => e.ID == id) > 0;
        }
    }
}