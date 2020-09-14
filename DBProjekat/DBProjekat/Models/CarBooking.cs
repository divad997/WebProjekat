using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DBProjekat.Models
{
    public class CarBooking
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Car Car { get; set; }
        [Required]
        public Location Location { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string PassportNum { get; set; }
        [Required]
        public DateTime ReserveStart { get; set; }
        [Required]
        public DateTime ReserveEnd { get; set; }
        [Required]
        public double TotalPrice { get; set; }

        public RentCompany RentCompany { get; set; }

        
    }
}
