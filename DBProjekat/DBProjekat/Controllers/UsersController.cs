using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBProjekat.Data;
using DBProjekat.Models;

namespace DBProjekat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AgencyContext _context;

        public UsersController(AgencyContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        // GET: api/Users/5
        [Route("GetUser")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [Route("GetUserById")]
        [HttpPost]
        public async Task<IActionResult> GetUserById(PostModel postModel)
        {
            var user = await _context.Users.FindAsync(postModel.Id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [Route("EditUser")]
        [HttpPost]
        public async Task<IActionResult> EditUser(User user)
        {
            var usr = await _context.Users.FindAsync(user.Id);
            if (user == null)
            {
                return NotFound();
            }

            usr.Username = user.Username;
            usr.Email = user.Email;
            usr.Password = user.Password;
            usr.Name = user.Name;
            usr.LastName = user.LastName;
            usr.City = user.City;
            usr.PhoneNumber = user.PhoneNumber;
            usr.PassportNumber = user.PassportNumber;
            usr.Role = user.Role;
            usr.Id = user.Id;
            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}