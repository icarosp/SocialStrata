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
    public class ResidenceServicesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ResidenceServices
        public IQueryable<ResidenceService> GetResidenceServices()
        {
            return db.ResidenceServices;
        }

        // GET: api/ResidenceServices/5
        [ResponseType(typeof(ResidenceService))]
        public IHttpActionResult GetResidenceService(int id)
        {
            ResidenceService residenceService = db.ResidenceServices.Find(id);
            if (residenceService == null)
            {
                return NotFound();
            }

            return Ok(residenceService);
        }

        // PUT: api/ResidenceServices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutResidenceService(int id, ResidenceService residenceService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != residenceService.Id)
            {
                return BadRequest();
            }

            db.Entry(residenceService).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResidenceServiceExists(id))
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

        // POST: api/ResidenceServices
        [ResponseType(typeof(ResidenceService))]
        public IHttpActionResult PostResidenceService(ResidenceService residenceService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ResidenceServices.Add(residenceService);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = residenceService.Id }, residenceService);
        }

        // DELETE: api/ResidenceServices/5
        [ResponseType(typeof(ResidenceService))]
        public IHttpActionResult DeleteResidenceService(int id)
        {
            ResidenceService residenceService = db.ResidenceServices.Find(id);
            if (residenceService == null)
            {
                return NotFound();
            }

            db.ResidenceServices.Remove(residenceService);
            db.SaveChanges();

            return Ok(residenceService);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResidenceServiceExists(int id)
        {
            return db.ResidenceServices.Count(e => e.Id == id) > 0;
        }
    }
}