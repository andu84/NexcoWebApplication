﻿using System;
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
    public class IncomesController : ApiController
    {
        private NexcoAppEntities1 db = new NexcoAppEntities1();

        // GET: api/Income
        public IQueryable<Income> GetIncomes()
        {
            return db.Incomes;
        }

        // GET: api/Income/5
        [ResponseType(typeof(Income))]
        public IHttpActionResult GetIncome(int id)
        {
            Income income = db.Incomes.Find(id);
            if (income == null)
            {
                return NotFound();
            }

            return Ok(income);
        }

        // PUT: api/Income/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIncome(int id, Income income)
        {
        
            if (id != income.IncomeId)
            {
                return BadRequest();
            }

            db.Entry(income).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncomeExists(id))
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

        // POST: api/Income
        [ResponseType(typeof(Income))]
        public IHttpActionResult PostIncome(Income income)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Incomes.Add(income);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = income.IncomeId }, income);
        }

        // DELETE: api/Income/5
        [ResponseType(typeof(Income))]
        public IHttpActionResult DeleteIncome(int id)
        {
            Income income = db.Incomes.Find(id);
            if (income == null)
            {
                return NotFound();
            }

            db.Incomes.Remove(income);
            db.SaveChanges();

            return Ok(income);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IncomeExists(int id)
        {
            return db.Incomes.Count(e => e.IncomeId == id) > 0;
        }
    }
}