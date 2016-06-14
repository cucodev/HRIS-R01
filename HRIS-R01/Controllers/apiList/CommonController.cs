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
using HRIS_R01.Models;

namespace HRIS_R01.Controllers.apiList
{
    public class CommonController : ApiController
    {
        private ListLocation dbLoc = new ListLocation();
        private ListCategory dbCat = new ListCategory();
        private OrganizationModel dbOrg = new OrganizationModel();

        // GET: api/locationsCat
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("Loc")]
        [System.Web.Http.Route("api/Common/Loc/{id}")]
        public async Task<IHttpActionResult> Loc(int id)
        {
            //location location = await db.locations.FindAsync(id);
            //var loc = new locations();
            //return Ok(loc.locations)

            string query = "SELECT * FROM [HRIS].[dbo].[location] where uidparent = @p0";
            DbSqlQuery<location> data = dbLoc.locations.SqlQuery(query, id);
            //location loc = await db.locations.SqlQuery(query, id).SingleOrDefaultAsync();
            //IEnumerable<location> data = db.locations.SqlQuery<location>(query);

            return Ok(data.ToList());
        }



        // GET: api/locationsCat
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("Catparents")]
        [System.Web.Http.Route("api/Common/Catparents/{id}")]
        public async Task<IHttpActionResult> Catparents(int id)
        {
            //location location = await db.locations.FindAsync(id);
            //var loc = new locations();
            //return Ok(loc.locations)

            string query = "SELECT * FROM [HRIS].[dbo].[category] where uidparent = @p0";
            DbSqlQuery<category> data = dbCat.categories.SqlQuery(query, id);
            //location loc = await db.locations.SqlQuery(query, id).SingleOrDefaultAsync();
            //IEnumerable<location> data = db.locations.SqlQuery<location>(query);

            return Ok(data.ToList());
        }

        // GET: api/locationsCat
        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("Cat")]
        [System.Web.Http.Route("api/Common/Cat/{id}")]
        public async Task<IHttpActionResult> Cat(int id)
        {
            //location location = await db.locations.FindAsync(id);
            //var loc = new locations();
            //return Ok(loc.locations)

            string query = "SELECT * FROM [HRIS].[dbo].[category] where id = @p0";
            DbSqlQuery<category> data = dbCat.categories.SqlQuery(query, id);
            //location loc = await db.locations.SqlQuery(query, id).SingleOrDefaultAsync();
            //IEnumerable<location> data = db.locations.SqlQuery<location>(query);

            return Ok(data.ToList());
        }


        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("Org")]
        [System.Web.Http.Route("api/Common/Org")]
        public async Task<IHttpActionResult> Org()
        {
            //location location = await db.locations.FindAsync(id);
            //var loc = new locations();
            //return Ok(loc.locations)

            string query = @"SELECT dbo.organization.ID AS ID,
                                    dbo.emp_master.Name AS Superior, 
                                    emp_master_1.Name AS Employee, 
                                    dbo.category.uidname AS sPosition, 
                                    category_1.uidname AS sJobLevel, 
                                    category_2.uidname AS ePosition, 
                                    category_3.uidname AS eJobLevel
                            FROM  dbo.emp_master INNER JOIN
                              dbo.organization ON dbo.emp_master.ID = dbo.organization.ParentIDV INNER JOIN
                              dbo.emp_master AS emp_master_1 ON dbo.organization.IDV = emp_master_1.ID INNER JOIN
                              dbo.category ON dbo.emp_master.empPosition = dbo.category.id INNER JOIN
                              dbo.category AS category_1 ON dbo.emp_master.empJobLevel = category_1.id INNER JOIN
                              dbo.category AS category_2 ON emp_master_1.empPosition = category_2.id INNER JOIN
                              dbo.category AS category_3 ON emp_master_1.empJobLevel = category_3.id";
            DbSqlQuery<organization> data = dbOrg.organizations.SqlQuery(query);
            //location loc = await db.locations.SqlQuery(query, id).SingleOrDefaultAsync();
            //IEnumerable<location> data = db.locations.SqlQuery<location>(query);

            return Ok(data.ToList());
        }
        
    }
}
