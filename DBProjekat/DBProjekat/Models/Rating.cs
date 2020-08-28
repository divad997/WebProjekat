using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DBProjekat.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Rating1 { get; set; }
        
        public AirCompany AirCompany { get; set; }

        public RentCompany RentCompany { get; set; }
        
        public Car Car { get; set; }
    }
}
