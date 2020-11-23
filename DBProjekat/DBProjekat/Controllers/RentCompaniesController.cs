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
            List<Car> lc = _context.Cars.ToList();
            List<Location> ll = _context.Locations.ToList();
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


        [HttpPost]
        [Route("BookCar")]
        public async Task<IActionResult> BookCar(PostModel model)
        {       
            DateTime DateStart = DateTime.Parse(model.DateStart);
            DateTime DateReturn = DateTime.Parse(model.DateReturn);
            double NumberOfDays = (DateReturn - DateStart).TotalDays;
            double TotalPrice;
            //List<Rating> rl = _context.Rating.ToList();
            var car = await _context.Cars.FindAsync(model.Id);
            if (car == null)
            {
                return NotFound();
            }

            TotalPrice = NumberOfDays * car.DailyRate;

            return Ok(TotalPrice);
        }

        [HttpPost]
        [Route("ReserveCar")]
        public async Task<IActionResult> ReserveCar(PostModel model)
        {
            DateTime DateStart = DateTime.Parse(model.DateStart);
            DateTime DateReturn = DateTime.Parse(model.DateReturn);
            CarBooking CB = new CarBooking();
            List<Location> Locations = _context.Locations.ToList();
            List<CarBooking> CarBookings = await _context.CarBookings.ToListAsync();
            List<Car> Cars = await _context.Cars.ToListAsync();
            Car Car1 = Cars.Find(item => item.Id == model.CarId);
            //List<Rating> rl = _context.Rating.ToList();


            var Company = await _context.RentCompanies.FindAsync(model.RCId);

            CB.PassportNum = model.PassportNumber;
            CB.Username = model.Username;
            CB.ReserveStart = DateStart;
            CB.ReserveEnd = DateReturn;
            CB.TotalPrice = Double.Parse(model.TotalPrice);
            CB.Car = Car1;
            CB.Location = Locations.Find(item => item.Location1 == model.Location);


            Company.CarBookings = new List<CarBooking>();
            Company.CarBookings.Add(CB);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [Route("GetLocations")]
        [HttpGet]
        public IEnumerable<Location> GetLocations()
        {
            return _context.Locations;
        }

        [Route("SearchByLocation")]
        [HttpPost]
        public List<RentCompany> SearchByLocation(PostModel model)
        {
            List<RentCompany> rc = _context.RentCompanies.ToList();
            List<Location> ll = _context.Locations.ToList();
            //List<Rating> rl = _context.Rating.ToList();
            

            List<RentCompany> searchedRC = new List<RentCompany>();

            foreach (var item in rc)
            {
                if (item.Locations == null)
                {
                    continue;
                }
                else
                {
                    foreach (var loc in item.Locations)
                    {
                        if (loc.Location1 == model.Location)
                        {
                            searchedRC.Add(item);
                        }
                    }
                }
            }

            return searchedRC;
        }
    }
}