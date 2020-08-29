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
    public class RentCompaniesController : ControllerBase
    {
        private readonly AgencyContext _context;

        public RentCompaniesController(AgencyContext context)
        {
            _context = context;
        }

        // GET: api/RentCompanies
        [HttpGet]
        public IEnumerable<RentCompany> GetRentCompanies()
        {
            return _context.RentCompanies;
        }

        // GET: api/RentCompanies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRentCompany([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rentCompany = await _context.RentCompanies.FindAsync(id);

            if (rentCompany == null)
            {
                return NotFound();
            }

            return Ok(rentCompany);
        }

        // PUT: api/RentCompanies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRentCompany([FromRoute] int id, [FromBody] RentCompany rentCompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rentCompany.Id)
            {
                return BadRequest();
            }

            _context.Entry(rentCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentCompanyExists(id))
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

        // POST: api/RentCompanies
        [HttpPost]
        public async Task<IActionResult> PostRentCompany([FromBody] RentCompany rentCompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RentCompanies.Add(rentCompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRentCompany", new { id = rentCompany.Id }, rentCompany);
        }

        // DELETE: api/RentCompanies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentCompany([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rentCompany = await _context.RentCompanies.FindAsync(id);
            if (rentCompany == null)
            {
                return NotFound();
            }

            _context.RentCompanies.Remove(rentCompany);
            await _context.SaveChangesAsync();

            return Ok(rentCompany);
        }

        private bool RentCompanyExists(int id)
        {
            return _context.RentCompanies.Any(e => e.Id == id);
        }
    }
}