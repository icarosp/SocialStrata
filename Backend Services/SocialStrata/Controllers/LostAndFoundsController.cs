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
    public class LostAndFoundsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/LostAndFounds
        public IQueryable<LostAndFound> GetLostAndFound()
        {
            return db.LostAndFound;
        }

        // GET: api/LostAndFounds/5
        [ResponseType(typeof(LostAndFound))]
        public IHttpActionResult GetLostAndFound(int id)
        {
            LostAndFound lostAndFound = db.LostAndFound.Find(id);
            if (lostAndFound == null)
            {
                return NotFound();
            }

            return Ok(lostAndFound);
        }

        // PUT: api/LostAndFounds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLostAndFound(int id, LostAndFound lostAndFound)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lostAndFound.Id)
            {
                return BadRequest();
            }

            db.Entry(lostAndFound).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LostAndFoundExists(id))
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

        // POST: api/LostAndFounds
        [ResponseType(typeof(LostAndFound))]
        public IHttpActionResult PostLostAndFound(LostAndFound lostAndFound)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LostAndFound.Add(lostAndFound);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lostAndFound.Id }, lostAndFound);
        }

        // DELETE: api/LostAndFounds/5
        [ResponseType(typeof(LostAndFound))]
        public IHttpActionResult DeleteLostAndFound(int id)
        {
            LostAndFound lostAndFound = db.LostAndFound.Find(id);
            if (lostAndFound == null)
            {
                return NotFound();
            }

            db.LostAndFound.Remove(lostAndFound);
            db.SaveChanges();

            return Ok(lostAndFound);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LostAndFoundExists(int id)
        {
            return db.LostAndFound.Count(e => e.Id == id) > 0;
        }
    }
}