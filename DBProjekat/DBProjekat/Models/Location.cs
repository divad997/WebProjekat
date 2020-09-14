using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DBProjekat.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Location1 { get; set; } 
    
        public RentCompany RentCompany { get; set; }
    }
}