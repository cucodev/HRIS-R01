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

namespace HRIS_R01.Controllers.List
{
    public class categoryParentsController : ApiController
    {
        //private ListCategory db = new ListCategory();
        //private categoryparent db = new categoryparent();
        private MasterHRISEntities db = new MasterHRISEntities();

        // GET: api/categoryParents
        public IQueryable<categoryparent> Getcategoryparents()
        {
            return db.categoryparents;
        }

        // GET: api/categoryParents/5
        [ResponseType(typeof(categoryparent))]
        public async Task<IHttpActionResult> Getcategoryparent(int id)
        {
            categoryparent categoryparent = await db.categoryparents.FindAsync(id);
            if (categoryparent == null)
            {
                return NotFound();
            }

            return Ok(categoryparent);
        }

        // PUT: api/categoryParents/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putcategoryparent(int id, categoryparent categoryparent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoryparent.id)
            {
                return BadRequest();
            }

            db.Entry(categoryparent).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!categoryparentExists(id))
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

        // POST: api/categoryParents
        [ResponseType(typeof(categoryparent))]
        public async Task<IHttpActionResult> Postcategoryparent(categoryparent categoryparent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.categoryparents.Add(categoryparent);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = categoryparent.id }, categoryparent);
        }

        // DELETE: api/categoryParents/5
        [ResponseType(typeof(categoryparent))]
        public async Task<IHttpActionResult> Deletecategoryparent(int id)
        {
            categoryparent categoryparent = await db.categoryparents.FindAsync(id);
            if (categoryparent == null)
            {
                return NotFound();
            }

            db.categoryparents.Remove(categoryparent);
            await db.SaveChangesAsync();

            return Ok(categoryparent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool categoryparentExists(int id)
        {
            return db.categoryparents.Count(e => e.id == id) > 0;
        }
    }
}