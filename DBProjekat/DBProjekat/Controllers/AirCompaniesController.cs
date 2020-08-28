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
    public class AirCompaniesController : ControllerBase
    {
        private readonly AgencyContext _context;

        public AirCompaniesController(AgencyContext context)
        {
            _context = context;
        }

        // GET: api/AirCompanies
        [HttpGet]
        public IEnumerable<AirCompany> GetAirCompanies()
        {
            return _context.AirCompanies;
        }

        // GET: api/AirCompanies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAirCompany([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var airCompany = await _context.AirCompanies.FindAsync(id);

            if (airCompany == null)
            {
                return NotFound();
            }

            return Ok(airCompany);
        }

        // PUT: api/AirCompanies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirCompany([FromRoute] int id, [FromBody] AirCompany airCompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != airCompany.Id)
            {
                return BadRequest();
            }

            _context.Entry(airCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

            return NoContent();
        }

        // POST: api/AirCompanies
        [HttpPost]
        public async Task<IActionResult> PostAirCompany([FromBody] AirCompany airCompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AirCompanies.Add(airCompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirCompany", new { id = airCompany.Id }, airCompany);
        }

        // DELETE: api/AirCompanies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirCompany([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var airCompany = await _context.AirCompanies.FindAsync(id);
            if (airCompany == null)
            {
                return NotFound();
            }

            _context.AirCompanies.Remove(airCompany);
            await _context.SaveChangesAsync();

            return Ok(airCompany);
        }

        private bool AirCompanyExists(int id)
        {
            return _context.AirCompanies.Any(e => e.Id == id);
        }
    }
}