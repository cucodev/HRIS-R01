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
//using HRIS_R01.Models.Form;
using HRIS_R01.Models;

namespace HRIS_R01.Controllers.apiForm
{
    public class notifnewsController : ApiController
    {
        //private newsModel db = new newsModel();
        private MasterHRISEntities db = new MasterHRISEntities();
        // GET: api/notifnews
        public IQueryable<notifnew> Getnotifnews()
        {
            return db.notifnews;
        }

        // GET: api/notifnews/5
        [ResponseType(typeof(notifnew))]
        public async Task<IHttpActionResult> Getnotifnew(int id)
        {
            notifnew notifnew = await db.notifnews.FindAsync(id);
            if (notifnew == null)
            {
                return NotFound();
            }

            return Ok(notifnew);
        }

        // PUT: api/notifnews/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putnotifnew(int id, notifnew notifnew)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notifnew.id)
            {
                return BadRequest();
            }

            db.Entry(notifnew).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!notifnewExists(id))
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

        // POST: api/notifnews
        [ResponseType(typeof(notifnew))]
        public async Task<IHttpActionResult> Postnotifnew(notifnew notifnew)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.notifnews.Add(notifnew);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = notifnew.id }, notifnew);
        }

        // DELETE: api/notifnews/5
        [ResponseType(typeof(notifnew))]
        public async Task<IHttpActionResult> Deletenotifnew(int id)
        {
            notifnew notifnew = await db.notifnews.FindAsync(id);
            if (notifnew == null)
            {
                return NotFound();
            }

            db.notifnews.Remove(notifnew);
            await db.SaveChangesAsync();

            return Ok(notifnew);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool notifnewExists(int id)
        {
            return db.notifnews.Count(e => e.id == id) > 0;
        }
    }
}