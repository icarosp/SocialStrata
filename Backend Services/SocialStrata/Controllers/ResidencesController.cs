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
    public class ResidencesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Residences
        public IQueryable<Residence> GetResidences()
        {
            return db.Residences;
        }

        // GET: api/Residences/5
        [ResponseType(typeof(Residence))]
        public IHttpActionResult GetResidence(int id)
        {
            Residence residence = db.Residences.Find(id);
            if (residence == null)
            {
                return NotFound();
            }

            return Ok(residence);
        }

        // PUT: api/Residences/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutResidence(int id, Residence residence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != residence.ResidenceId)
            {
                return BadRequest();
            }

            db.Entry(residence).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResidenceExists(id))
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

        // POST: api/Residences
        [ResponseType(typeof(Residence))]
        public IHttpActionResult PostResidence(Residence residence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Residences.Add(residence);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = residence.ResidenceId }, residence);
        }

        // DELETE: api/Residences/5
        [ResponseType(typeof(Residence))]
        public IHttpActionResult DeleteResidence(int id)
        {
            Residence residence = db.Residences.Find(id);
            if (residence == null)
            {
                return NotFound();
            }

            db.Residences.Remove(residence);
            db.SaveChanges();

            return Ok(residence);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResidenceExists(int id)
        {
            return db.Residences.Count(e => e.ResidenceId == id) > 0;
        }
    }
}