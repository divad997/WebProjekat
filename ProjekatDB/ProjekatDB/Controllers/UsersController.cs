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
    [RoutePrefix("Api/User")]
    public class UsersController : ApiController
    {
        private RocketEntities db = new RocketEntities();

        // GET: api/Users
        [Route("AllUserDetails")]
        public async Task<Object> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [Route("GetUserDetailsById/{userId}")]
        [ResponseType(typeof(User))]
        public async Task<Object> GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [Route("UpdateUserDetails")]
        [ResponseType(typeof(void))]
        public async Task<Object> PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [Route("InsertUserDetails")]
        [ResponseType(typeof(User))]
        public async Task<Object> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            db.SaveChanges();

            return user;
        }

        // DELETE: api/Users/5
        [Route("DeleteUserDetails")]
        [ResponseType(typeof(User))]
        public async Task<Object> DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}