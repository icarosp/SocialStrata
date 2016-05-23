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
    public class PersonCreditCardsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/PersonCreditCards
        public IQueryable<PersonCreditCard> GetPersonCreditCards()
        {
            return db.PersonCreditCards;
        }

        // GET: api/PersonCreditCards/5
        [ResponseType(typeof(PersonCreditCard))]
        public IHttpActionResult GetPersonCreditCard(int id)
        {
            PersonCreditCard personCreditCard = db.PersonCreditCards.Find(id);
            if (personCreditCard == null)
            {
                return NotFound();
            }

            return Ok(personCreditCard);
        }

        // PUT: api/PersonCreditCards/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonCreditCard(int id, PersonCreditCard personCreditCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personCreditCard.Id)
            {
                return BadRequest();
            }

            db.Entry(personCreditCard).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonCreditCardExists(id))
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

        // POST: api/PersonCreditCards
        [ResponseType(typeof(PersonCreditCard))]
        public IHttpActionResult PostPersonCreditCard(PersonCreditCard personCreditCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PersonCreditCards.Add(personCreditCard);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personCreditCard.Id }, personCreditCard);
        }

        // DELETE: api/PersonCreditCards/5
        [ResponseType(typeof(PersonCreditCard))]
        public IHttpActionResult DeletePersonCreditCard(int id)
        {
            PersonCreditCard personCreditCard = db.PersonCreditCards.Find(id);
            if (personCreditCard == null)
            {
                return NotFound();
            }

            db.PersonCreditCards.Remove(personCreditCard);
            db.SaveChanges();

            return Ok(personCreditCard);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonCreditCardExists(int id)
        {
            return db.PersonCreditCards.Count(e => e.Id == id) > 0;
        }
    }
}