﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DBProjekat.Models
{
    public class RentCompany
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public List<Car> Cars { get; set; }
        [Required]
        public string Prices { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public List<Location> Locations { get; set; }
        [Required]
        public List<CarBooking> CarBookings { get; set; }
       
    }
}
