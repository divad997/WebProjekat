﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DBProjekat.Models
{
    public class Destination
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Destination1 { get; set; }
        public AirCompany AirCompany { get; set; }

       
    }
}
