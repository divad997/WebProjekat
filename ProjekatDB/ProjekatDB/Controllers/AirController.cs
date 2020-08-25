using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ProjekatDB.Models;

namespace ProjekatDB.Controllers
{
    [RoutePrefix("Api/Air")]
    public class AirController : ApiController
    {
        private RocketEntities1 db = new RocketEntities1();

        // GET: api/Air
        [Route("AllAirDetails")]
        public async Task<Object> GetAirCompanies()
        {
            return db.AirCompanies;
        }

        // GET: api/Air/5
        [Route("GetAirDetailsById/{airId}")]
        [ResponseType(typeof(AirCompany))]
        public async Task<Object> GetAirCompany(int id)
        {
            AirCompany airCompany = db.AirCompanies.Find(id);
            if (airCompany == null)
            {
                return NotFound();
            }

            return Ok(airCompany);
        }

        // PUT: api/Air/5
        [Route("UpdateAirDetails")]
        [ResponseType(typeof(void))]
        public async Task<Object> PutAirCompany(int id, AirCompany airCompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != airCompany.Id)
            {
                return BadRequest();
            }

            db.Entry(airCompany).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirCompanyExists(id))
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

        // POST: api/Air
        [Route("InsertAirDetails")]
        [ResponseType(typeof(AirCompany))]
        public async Task<Object> PostAirCompany(AirCompany airCompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AirCompanies.Add(airCompany);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = airCompany.Id }, airCompany);
        }

        // DELETE: api/Air/5
        [Route("DeleteAirDetails")]
        [ResponseType(typeof(AirCompany))]
        public async Task<Object> DeleteAirCompany(int id)
        {
            AirCompany airCompany = db.AirCompanies.Find(id);
            if (airCompany == null)
            {
                return NotFound();
            }

            db.AirCompanies.Remove(airCompany);
            db.SaveChanges();

            return Ok(airCompany);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AirCompanyExists(int id)
        {
            return db.AirCompanies.Count(e => e.Id == id) > 0;
        }
    }
}