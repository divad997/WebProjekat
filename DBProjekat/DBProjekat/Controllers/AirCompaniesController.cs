﻿using System;
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
        [Route("GetAirCompanies")]
        [HttpGet]
        public IEnumerable<AirCompany> GetAirCompanies()
        {
            List<AirCompany> acl = _context.AirCompanies.ToList();
            List<Destination> dl = _context.Destination.ToList();
            //List<Rating> rl = _context.Rating.ToList();
            List<Flight> fl = _context.Flight.ToList();

            return _context.AirCompanies;
        }

        [Route("SearchByDestination")]
        [HttpPost]
        public List<AirCompany> SearchByDestination(PostModel model)
        {
            List<AirCompany> acl = _context.AirCompanies.ToList();
            List<Destination> dl = _context.Destination.ToList();
            //List<Rating> rl = _context.Rating.ToList();
            List<Flight> fl = _context.Flight.ToList();

            List<AirCompany> searchedAC = new List<AirCompany>();

            foreach (var item in acl)
            {
                if (item.Flights == null)
                {
                    continue;
                }
                else
                {
                    foreach (var item1 in item.Flights)
                    {
                        if (item1.DestinationFrom == model.DestinationFrom && item1.DestinationTo == model.DestinationTo)
                        {
                            searchedAC.Add(item);
                        }
                    }
                }                
            }

            return searchedAC;
        }

        [Route("SearchByDate")]
        [HttpPost]
        public List<AirCompany> SearchByDate(PostModel model)
        {
            List<AirCompany> acl = _context.AirCompanies.ToList();
            List<Destination> dl = _context.Destination.ToList();
            //List<Rating> rl = _context.Rating.ToList();
            List<Flight> fl = _context.Flight.ToList();
            DateTime tmpTDate = DateTime.Parse(model.Date);
            DateTime tmpLDate = DateTime.Parse(model.LandDate);

            List<AirCompany> searchedAC = new List<AirCompany>();

            foreach (var item in acl)
            {
                if (item.Flights == null)
                {
                    continue;
                }
                else
                {
                    foreach (var item1 in item.Flights)
                    {
                        if (DateTime.Compare(item1.TakeoffDate.Date, tmpTDate.Date) == 0 && DateTime.Compare(item1.LandingDate.Date, tmpLDate.Date) == 0)
                        {
                            searchedAC.Add(item);
                        }
                    }
                }
            }

            return searchedAC;
        }

        [Route("SearchByBoth")]
        [HttpPost]
        public List<AirCompany> SearchByBoth(PostModel model)
        {
            List<AirCompany> acl = _context.AirCompanies.ToList();
            List<Destination> dl = _context.Destination.ToList();
            //List<Rating> rl = _context.Rating.ToList();
            List<Flight> fl = _context.Flight.ToList();
            DateTime tmpTDate = DateTime.Parse(model.Date);
            DateTime tmpLDate = DateTime.Parse(model.LandDate);

            List<AirCompany> searchedAC = new List<AirCompany>();

            foreach (var item in acl)
            {
                if (item.Flights == null)
                {
                    continue;
                }
                else
                {
                    foreach (var item1 in item.Flights)
                    {
                        if (DateTime.Compare(item1.TakeoffDate.Date, tmpTDate.Date) == 0 && DateTime.Compare(item1.LandingDate.Date, tmpLDate.Date) == 0 && item1.DestinationFrom == model.DestinationFrom && item1.DestinationTo == model.DestinationTo)
                        {
                            searchedAC.Add(item);
                        }
                    }
                }
            }

            return searchedAC;
        }

        // GET: api/AirCompanies/5
        [Route("GetAirCompany")]
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

        [HttpPost]
        [Route("ACById")]
        public async Task<IActionResult> ACById(PostModel model)
        {
            List<Destination> dl = _context.Destination.ToList();
            List<Flight> fl = _context.Flight.ToList();
            //List<Rating> rl = _context.Rating.ToList();
            var ac = await _context.AirCompanies.FindAsync(model.Id);
            if (ac == null)
            {
                return NotFound();
            }

            return Ok(ac);
        }

        [HttpPost]
        [Route("BookFlight")]
        public async Task<IActionResult> BookFlight(PostModel model)
        {
            List<Destination> dl = _context.Destination.ToList();
            List<Flight> fl = _context.Flight.ToList();
            List<Flight> fl1 = new List<Flight>();
            DateTime tmpDate = DateTime.Parse(model.Date);
            //List<Rating> rl = _context.Rating.ToList();
            var ac = await _context.AirCompanies.FindAsync(model.Id);
            if (ac == null)
            {
                return NotFound();
            }

            foreach (var item in ac.Flights)
            {
                if (item.DestinationFrom == model.DestinationFrom && item.DestinationTo == model.DestinationTo && DateTime.Compare(tmpDate.Date, item.TakeoffDate.Date) == 0)
                {
                    fl1.Add(item);
                }
            }

            return Ok(fl1);
        }

        [HttpPost]
        [Route("ReserveFlight")]
        public async Task<IActionResult> ReserveFlight(PostModel model)
        {
            List<Destination> dl = _context.Destination.ToList();
            List<Flight> fl = _context.Flight.ToList();
            List<Ticket> tl = _context.Ticket.ToList();
            List<Flight> fl1 = new List<Flight>();
            Ticket t = new Ticket();
            int numOfT = Int32.Parse(model.NumberOfTickets);
            //List<Rating> rl = _context.Rating.ToList();
            var flt = await _context.Flight.FindAsync(model.Fl.Id);
            if (flt.NumberOfTickets - numOfT >= 0)
            {
                flt.NumberOfTickets -= numOfT;
            }
            else
            {
                return BadRequest();
            }
            
            if (flt == null)
            {
                return NotFound();
            }
            else
            {
                t.PassportNum = model.PassportNumber;
                t.Username = model.Username;
                t.DestinationFrom = flt.DestinationFrom;
                t.DestinationTo = flt.DestinationTo;
                t.Flight = flt;
                t.FlightLength = flt.FlightLength;
                t.LandingDate = flt.LandingDate;
                t.TakeoffDate = flt.TakeoffDate;
                t.TakeoffTime = flt.TakeoffTime;
                t.TicketPrice = flt.TicketPrice * numOfT;

                flt.Tickets.Add(t);

                await _context.SaveChangesAsync();
            }
            return Ok();
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