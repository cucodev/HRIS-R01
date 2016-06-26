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

namespace HRIS_R01.Controllers.apiForm
{
    public class organizationsController : ApiController
    {
        //private OrganizationModel db = new OrganizationModel();
        private MasterHRISEntities db = new MasterHRISEntities();
        // GET: api/organizations
        public IQueryable<organization> Getorganizations()
        {
            return db.organizations;
        }

        // GET: api/organizations/5
        [ResponseType(typeof(organization))]
        public async Task<IHttpActionResult> Getorganization(int id)
        {
            organization organization = await db.organizations.FindAsync(id);
            if (organization == null)
            {
                return NotFound();
            }

            return Ok(organization);
        }

        // PUT: api/organizations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putorganization(int id, organization organization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != organization.ID)
            {
                return BadRequest();
            }

            db.Entry(organization).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!organizationExists(id))
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

        // POST: api/organizations
        [ResponseType(typeof(organization))]
        public async Task<IHttpActionResult> Postorganization(organization organization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.organizations.Add(organization);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = organization.ID }, organization);
        }

        // DELETE: api/organizations/5
        [ResponseType(typeof(organization))]
        public async Task<IHttpActionResult> Deleteorganization(int id)
        {
            organization organization = await db.organizations.FindAsync(id);
            if (organization == null)
            {
                return NotFound();
            }

            db.organizations.Remove(organization);
            await db.SaveChangesAsync();

            return Ok(organization);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool organizationExists(int id)
        {
            return db.organizations.Count(e => e.ID == id) > 0;
        }
    }
}