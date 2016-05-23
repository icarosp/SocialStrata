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
    public class MaintainanceRequestsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/MaintainanceRequests
        public IQueryable<MaintainanceRequest> GetMaintainanceRequest()
        {
            return db.MaintainanceRequest;
        }

        // GET: api/MaintainanceRequests/5
        [ResponseType(typeof(MaintainanceRequest))]
        public IHttpActionResult GetMaintainanceRequest(int id)
        {
            MaintainanceRequest maintainanceRequest = db.MaintainanceRequest.Find(id);
            if (maintainanceRequest == null)
            {
                return NotFound();
            }

            return Ok(maintainanceRequest);
        }

        // PUT: api/MaintainanceRequests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaintainanceRequest(int id, MaintainanceRequest maintainanceRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != maintainanceRequest.Id)
            {
                return BadRequest();
            }

            db.Entry(maintainanceRequest).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaintainanceRequestExists(id))
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

        // POST: api/MaintainanceRequests
        [ResponseType(typeof(MaintainanceRequest))]
        public IHttpActionResult PostMaintainanceRequest(MaintainanceRequest maintainanceRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MaintainanceRequest.Add(maintainanceRequest);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = maintainanceRequest.Id }, maintainanceRequest);
        }

        // DELETE: api/MaintainanceRequests/5
        [ResponseType(typeof(MaintainanceRequest))]
        public IHttpActionResult DeleteMaintainanceRequest(int id)
        {
            MaintainanceRequest maintainanceRequest = db.MaintainanceRequest.Find(id);
            if (maintainanceRequest == null)
            {
                return NotFound();
            }

            db.MaintainanceRequest.Remove(maintainanceRequest);
            db.SaveChanges();

            return Ok(maintainanceRequest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaintainanceRequestExists(int id)
        {
            return db.MaintainanceRequest.Count(e => e.Id == id) > 0;
        }
    }
}