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
    public class ChatsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Chats
        public IQueryable<Chat> GetChat()
        {
            return db.Chat;
        }

        // GET: api/Chats/5
        [ResponseType(typeof(Chat))]
        public IHttpActionResult GetChat(int id)
        {
            Chat chat = db.Chat.Find(id);
            if (chat == null)
            {
                return NotFound();
            }

            return Ok(chat);
        }

        // PUT: api/Chats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChat(int id, Chat chat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (id != chat.Id)
            {
                return BadRequest();
            }

            db.Entry(chat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatExists(id))
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

        // POST: api/Chats
        [ResponseType(typeof(Chat))]
        public IHttpActionResult PostChat(Chat chat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Chat.Add(chat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = chat.Id }, chat);
        }

        // DELETE: api/Chats/5
        [ResponseType(typeof(Chat))]
        public IHttpActionResult DeleteChat(int id)
        {
            Chat chat = db.Chat.Find(id);
            if (chat == null)
            {
                return NotFound();
            }

            db.Chat.Remove(chat);
            db.SaveChanges();

            return Ok(chat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChatExists(int id)
        {
            return db.Chat.Count(e => e.Id == id) > 0;
        }
    }
}