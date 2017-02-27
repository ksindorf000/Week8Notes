using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Week8Notes.Models;

namespace Week8Notes.Controllers
{
    public class DogController : ApiController
    {
        DogContext db = new DogContext();

        /*********************************
         * POST
         ********************************/
        public IHttpActionResult Post(Dog dog)
        {
            db.Dogs.Add(dog);
            db.SaveChanges();
            return Created("Get", dog);
        }

        /*********************************
         * GET List
         ********************************/
        [ResponseType(typeof(Dog))]
        public IHttpActionResult Get()
        {
            DbSet<Dog> results = db.Dogs;
            return Ok(results);
        }

        /*********************************
         * GET Single
         ********************************/
         [ResponseType(typeof(Dog))]
         public IHttpActionResult Get(int id)
        {
            Dog result = db.Dogs.Where(d => d.Id == id).FirstOrDefault();
            return Ok(result); 
        }

        /*********************************
         * UPDATE
         ********************************/
         public IHttpActionResult Put(int id, Dog dog)
        {
            dog.Id = id;
            db.Entry(dog).State = EntityState.Modified;
            db.SaveChanges();

            return Ok();
        }

        /*********************************
         * DELETE
         ********************************/
         public IHttpActionResult Delete(int id)
        {
            Dog result = db.Dogs.Find(id);
            db.Dogs.Remove(result);
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
