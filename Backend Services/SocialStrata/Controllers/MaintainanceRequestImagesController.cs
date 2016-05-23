using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SocialStrata.Models;

namespace SocialStrata.Controllers
{
    public class MaintainanceRequestImagesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/MaintainanceRequestImages
        public IQueryable<MaintainanceRequestImage> GetMaintainanceRequestImages()
        {
            return db.MaintainanceRequestImages;
        }

        // GET: api/MaintainanceRequestImages/5
        [ResponseType(typeof(MaintainanceRequestImage))]
        public IHttpActionResult GetMaintainanceRequestImage(int id)
        {
            MaintainanceRequestImage maintainanceRequestImage = db.MaintainanceRequestImages.Find(id);
            if (maintainanceRequestImage == null)
            {
                return NotFound();
            }

            return Ok(maintainanceRequestImage);
        }

        // PUT: api/MaintainanceRequestImages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaintainanceRequestImage(int id, MaintainanceRequestImage maintainanceRequestImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != maintainanceRequestImage.Id)
            {
                return BadRequest();
            }

            db.Entry(maintainanceRequestImage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaintainanceRequestImageExists(id))
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

        // POST: api/MaintainanceRequestImages
        [ResponseType(typeof(MaintainanceRequestImage))]
        public IHttpActionResult PostMaintainanceRequestImage(MaintainanceRequestImage maintainanceRequestImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MaintainanceRequestImages.Add(maintainanceRequestImage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = maintainanceRequestImage.Id }, maintainanceRequestImage);
        }

        // DELETE: api/MaintainanceRequestImages/5
        [ResponseType(typeof(MaintainanceRequestImage))]
        public IHttpActionResult DeleteMaintainanceRequestImage(int id)
        {
            MaintainanceRequestImage maintainanceRequestImage = db.MaintainanceRequestImages.Find(id);
            if (maintainanceRequestImage == null)
            {
                return NotFound();
            }

            db.MaintainanceRequestImages.Remove(maintainanceRequestImage);
            db.SaveChanges();

            return Ok(maintainanceRequestImage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaintainanceRequestImageExists(int id)
        {
            return db.MaintainanceRequestImages.Count(e => e.Id == id) > 0;
        }
    }
}