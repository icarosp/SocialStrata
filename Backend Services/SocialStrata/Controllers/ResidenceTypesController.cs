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
    public class ResidenceTypesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ResidenceTypes
        public IQueryable<ResidenceType> GetResidenceTypes()
        {
            return db.ResidenceTypes;
        }

        // GET: api/ResidenceTypes/5
        [ResponseType(typeof(ResidenceType))]
        public IHttpActionResult GetResidenceType(int id)
        {
            ResidenceType residenceType = db.ResidenceTypes.Find(id);
            if (residenceType == null)
            {
                return NotFound();
            }

            return Ok(residenceType);
        }

        // PUT: api/ResidenceTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutResidenceType(int id, ResidenceType residenceType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != residenceType.Id)
            {
                return BadRequest();
            }

            db.Entry(residenceType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResidenceTypeExists(id))
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

        // POST: api/ResidenceTypes
        [ResponseType(typeof(ResidenceType))]
        public IHttpActionResult PostResidenceType(ResidenceType residenceType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ResidenceTypes.Add(residenceType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = residenceType.Id }, residenceType);
        }

        // DELETE: api/ResidenceTypes/5
        [ResponseType(typeof(ResidenceType))]
        public IHttpActionResult DeleteResidenceType(int id)
        {
            ResidenceType residenceType = db.ResidenceTypes.Find(id);
            if (residenceType == null)
            {
                return NotFound();
            }

            db.ResidenceTypes.Remove(residenceType);
            db.SaveChanges();

            return Ok(residenceType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResidenceTypeExists(int id)
        {
            return db.ResidenceTypes.Count(e => e.Id == id) > 0;
        }
    }
}