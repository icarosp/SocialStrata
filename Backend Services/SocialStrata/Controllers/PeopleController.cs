using SocialStrata.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SocialStrata.Controllers
{
    public class PeopleController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Chats
        public IQueryable<Person> GetChat()
        {
            return db.People;
        }
        // GET: api/People/5
        [ResponseType(typeof(Chat))]
        public IHttpActionResult GetPerson(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                
                Person person = ctx.People.Find(id);
                if (person == null)
                {
                    return NotFound();
                }

                return Ok(person);
            }

        }

        // PUT: api/People/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerson(string userid, Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (userid != person.UserId)
            {
                return BadRequest();
            }

            db.Entry(person).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(userid))
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

        // POST: api/People
        [ResponseType(typeof(Person))]
        public IHttpActionResult PostPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.People.Add(person);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = person.UserId }, person);
        }



        // DELETE: api/People/5
        [ResponseType(typeof(Person))]
        public IHttpActionResult DeletePerson(string Userid)
        {
            Person person = db.People.Find(Userid);
            if (person == null)
            {
                return NotFound();
            }

            db.People.Remove(person);
            db.SaveChanges();

            return Ok(person);
        }

       

        public IHttpActionResult GetProfile(string email)
        {

            using (var ctx = new ApplicationDbContext())
            {
                Person person = (from p in db.People where p.EmailAddess == email select p).FirstOrDefault();
                if (person == null)
                {
                    return NotFound();
                }

                return Ok(person);
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonExists(string userId)
        {
            return db.People.Count(e => e.UserId == userId) > 0;
        }
    }
}