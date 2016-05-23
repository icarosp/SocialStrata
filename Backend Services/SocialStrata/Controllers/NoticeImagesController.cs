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
    public class NoticeImagesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/NoticeImages
        public IQueryable<NoticeImage> GetNoticeImages()
        {
            return db.NoticeImages;
        }

        // GET: api/NoticeImages/5
        [ResponseType(typeof(NoticeImage))]
        public IHttpActionResult GetNoticeImage(int id)
        {
            NoticeImage noticeImage = db.NoticeImages.Find(id);
            if (noticeImage == null)
            {
                return NotFound();
            }

            return Ok(noticeImage);
        }

        // PUT: api/NoticeImages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNoticeImage(int id, NoticeImage noticeImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != noticeImage.NoticeImageId)
            {
                return BadRequest();
            }

            db.Entry(noticeImage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticeImageExists(id))
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

        // POST: api/NoticeImages
        [ResponseType(typeof(NoticeImage))]
        public IHttpActionResult PostNoticeImage(NoticeImage noticeImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NoticeImages.Add(noticeImage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = noticeImage.NoticeImageId }, noticeImage);
        }

        // DELETE: api/NoticeImages/5
        [ResponseType(typeof(NoticeImage))]
        public IHttpActionResult DeleteNoticeImage(int id)
        {
            NoticeImage noticeImage = db.NoticeImages.Find(id);
            if (noticeImage == null)
            {
                return NotFound();
            }

            db.NoticeImages.Remove(noticeImage);
            db.SaveChanges();

            return Ok(noticeImage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NoticeImageExists(int id)
        {
            return db.NoticeImages.Count(e => e.NoticeImageId == id) > 0;
        }
    }
}