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
using Day2Authentification.Models;
using Microsoft.AspNet.Identity;

namespace Day2Authentification.Controllers
{
    [Authorize]
    public class TransactionController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Transaction
        public IQueryable<Transaction> GetTransactions()
        {
            /*******
             * To do: filter by current auth user
             * *****/
            return db.Transactions;
        }

        // GET: api/Transaction/5
        [ResponseType(typeof(Transaction))]
        public IHttpActionResult GetTransaction(int id)
        {
            /*******
             * To do: filter by current auth user
             * *****/
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }        

        // POST: api/Transaction
        [ResponseType(typeof(Transaction))]
        public IHttpActionResult PostTransaction(Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            transaction.Created = DateTime.Now;
            transaction.UserId = User.Identity.GetUserId();

            db.Transactions.Add(transaction);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = transaction.Id }, transaction);
        }
        
        /*--------------------------------------------------------*/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TransactionExists(int id)
        {
            return db.Transactions.Count(e => e.Id == id) > 0;
        }
    }
}