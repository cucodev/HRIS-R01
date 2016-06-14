using System;
using System.IO;
using System.Web;
using System.Web.Hosting;
//using System.Web.UI.WebControls;
using System.Drawing;
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
using HRIS_R01.Models.Employee;

namespace HRIS_R01.Controllers.api
{
    public class emp_imageController : ApiController
    {
        private EmployeeImageModel db = new EmployeeImageModel();

        


        // GET: api/emp_image
        public IQueryable<emp_image> Getemp_image()
        {
            return db.emp_image;
        }

        // GET: api/emp_image/5
        [ResponseType(typeof(emp_image))]
        public async Task<IHttpActionResult> Getemp_image(int id)
        {
            emp_image emp_image = await db.emp_image.FindAsync(id);
            if (emp_image == null)
            {
                return NotFound();
            }

            return Ok(emp_image);
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("postImage")]
        [System.Web.Http.Route("api/emp_image/postImage/{id}")]
        public Task<IEnumerable<string>> postImage(int id)
        {
            if (Request.Content.IsMimeMultipartContent())
            {
                string fullPath = HttpContext.Current.Server.MapPath("~/uploads");
                MultipartFormDataStreamProvider streamProvider = new MultipartFormDataStreamProvider(fullPath);
                var task = Request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith(t =>
                {
                    if (t.IsFaulted || t.IsCanceled)
                        throw new HttpResponseException(HttpStatusCode.InternalServerError);
                    var fileInfo = streamProvider.FileData.Select(i =>
                    {
                        var info = new FileInfo(i.LocalFileName);
                        Bitmap fileImage = Image.FromFile(i.LocalFileName) as Bitmap;
                        Bitmap img = new Bitmap(fileImage);
                        //ImageDbEntities db = new ImageDbEntities();
                        //Image img = new Image();
                        //img.ImageData = File.ReadAllBytes(info.FullName);
                        byte[] imag = File.ReadAllBytes(img.ToString());
                        //db.emp_image.
                        //db.emp_image.Add(imag);
                        //db.SaveChanges();
                        return "File uploaded successfully!";
                    });
                    return fileInfo;
                });
                return task;
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "Invalid Request!"));
            }
        }
        

        // PUT: api/emp_image/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putemp_image(int id, emp_image emp_image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emp_image.ID)
            {
                return BadRequest();
            }

            db.Entry(emp_image).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!emp_imageExists(id))
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

        // POST: api/emp_image
        [ResponseType(typeof(emp_image))]
        public async Task<IHttpActionResult> Postemp_image(emp_image emp_image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.emp_image.Add(emp_image);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (emp_imageExists(emp_image.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = emp_image.ID }, emp_image);
        }

        // DELETE: api/emp_image/5
        [ResponseType(typeof(emp_image))]
        public async Task<IHttpActionResult> Deleteemp_image(int id)
        {
            emp_image emp_image = await db.emp_image.FindAsync(id);
            if (emp_image == null)
            {
                return NotFound();
            }

            db.emp_image.Remove(emp_image);
            await db.SaveChangesAsync();

            return Ok(emp_image);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool emp_imageExists(int id)
        {
            return db.emp_image.Count(e => e.ID == id) > 0;
        }
    }
}