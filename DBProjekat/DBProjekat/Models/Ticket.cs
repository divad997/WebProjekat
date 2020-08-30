using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DBProjekat.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DestinationFrom { get; set; }
        [Required]
        public string DestinationTo { get; set; }
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
        public List<Rating> Ratings { get; set; }
        public string Username { get; set; }
        public string PassportNum { get; set; }

        public Flight Flight { get; set; }
    }
}
