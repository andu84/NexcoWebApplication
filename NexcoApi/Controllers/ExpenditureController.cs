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
using NexcoApi.Models;

namespace NexcoApi.Controllers
{
    public class ExpenditureController : ApiController
    {
        private NexcoAppEntities1 db = new NexcoAppEntities1();

        // GET: api/Expenditures
        public IQueryable<Expenditure> GetExpenditures()
        {
            return db.Expenditures;
        }

        // GET: api/Expenditures/5
        [ResponseType(typeof(Expenditure))]
        public IHttpActionResult GetExpenditure(int id)
        {
            Expenditure expenditure = db.Expenditures.Find(id);
            if (expenditure == null)
            {
                return NotFound();
            }

            return Ok(expenditure);
        }

        // PUT: api/Expenditures/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExpenditure(int id, Expenditure expenditure)
        {
        

            if (id != expenditure.ExpenditureId)
            {
                return BadRequest();
            }

            db.Entry(expenditure).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenditureExists(id))
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

        // POST: api/Expenditures
        [ResponseType(typeof(Expenditure))]
        public IHttpActionResult PostExpenditure(Expenditure expenditure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Expenditures.Add(expenditure);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = expenditure.ExpenditureId }, expenditure);
        }

        // DELETE: api/Expenditures/5
        [ResponseType(typeof(Expenditure))]
        public IHttpActionResult DeleteExpenditure(int id)
        {
            Expenditure expenditure = db.Expenditures.Find(id);
            if (expenditure == null)
            {
                return NotFound();
            }

            db.Expenditures.Remove(expenditure);
            db.SaveChanges();

            return Ok(expenditure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExpenditureExists(int id)
        {
            return db.Expenditures.Count(e => e.ExpenditureId == id) > 0;
        }
    }
}