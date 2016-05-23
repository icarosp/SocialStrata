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
    public class ResidencePaymentsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ResidencePayments
        public IQueryable<ResidencePayments> GetResidencePayments()
        {
            return db.ResidencePayments;
        }

        // GET: api/ResidencePayments/5
        [ResponseType(typeof(ResidencePayments))]
        public IHttpActionResult GetResidencePayments(int id)
        {
            ResidencePayments residencePayments = db.ResidencePayments.Find(id);
            if (residencePayments == null)
            {
                return NotFound();
            }

            return Ok(residencePayments);
        }

        // PUT: api/ResidencePayments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutResidencePayments(int id, ResidencePayments residencePayments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != residencePayments.Id)
            {
                return BadRequest();
            }

            db.Entry(residencePayments).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResidencePaymentsExists(id))
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

        // POST: api/ResidencePayments
        [ResponseType(typeof(ResidencePayments))]
        public IHttpActionResult PostResidencePayments(ResidencePayments residencePayments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ResidencePayments.Add(residencePayments);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = residencePayments.Id }, residencePayments);
        }

        // DELETE: api/ResidencePayments/5
        [ResponseType(typeof(ResidencePayments))]
        public IHttpActionResult DeleteResidencePayments(int id)
        {
            ResidencePayments residencePayments = db.ResidencePayments.Find(id);
            if (residencePayments == null)
            {
                return NotFound();
            }

            db.ResidencePayments.Remove(residencePayments);
            db.SaveChanges();

            return Ok(residencePayments);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResidencePaymentsExists(int id)
        {
            return db.ResidencePayments.Count(e => e.Id == id) > 0;
        }
    }
}