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
using HRIS_R01.Models.Location;

namespace HRIS_R01.Controllers.List
{
    public class locationController : ApiController
    {
        private ListLocation db = new ListLocation();

        


        // GET: api/locations
        public IQueryable<location> Getlocations()
        {
            return db.locations;
        }

        // GET: api/locations/5
        [ResponseType(typeof(location))]
        public async Task<IHttpActionResult> Getlocation(long id)
        {
            location location = await db.locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        // PUT: api/locations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putlocation(long id, location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != location.id)
            {
                return BadRequest();
            }

            db.Entry(location).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!locationExists(id))
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

        // POST: api/locations
        [ResponseType(typeof(location))]
        public async Task<IHttpActionResult> Postlocation(location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.locations.Add(location);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (locationExists(location.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = location.id }, location);
        }

        // DELETE: api/locations/5
        [ResponseType(typeof(location))]
        public async Task<IHttpActionResult> Deletelocation(long id)
        {
            location location = await db.locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            db.locations.Remove(location);
            await db.SaveChangesAsync();

            return Ok(location);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool locationExists(long id)
        {
            return db.locations.Count(e => e.id == id) > 0;
        }
    }
}