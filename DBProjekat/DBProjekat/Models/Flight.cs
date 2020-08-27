using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DBProjekat.Models
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime TakeoffDate { get; set; }
        [Required]
        public DateTime LandingDate { get; set; }
        [Required]
        public DateTime TakeoffTime { get; set; }
        [Required]
        public double FlightLength { get; set; }
        [Required]
        public double TicketPrice { get; set; }
        [Required]
        public List<Rating> Ratings { get; set; }

        public AirCompany AirCompany { get; set; }
    }
}
