﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DBProjekat.Models
{
    public class AirCompany
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address {get; set; }
        [Required]
        public string About { get; set; }
        [Required]
        public string Prices { get; set;  }
        [Required]
        public List<Destination> Destionations { get; set; }
        [Required]
        public List<Flight> Flights { get; set; }
        [Required]
        public List<Rating> Ratings { get; set; }
    }
}
