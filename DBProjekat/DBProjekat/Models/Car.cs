using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DBProjekat.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double DailyRate { get; set; }
        [Required]
        public string Type { get; set; }
        
        public RentCompany RentCompany { get; set; }

        public List<Rating> Ratings { get; set; }
        
        
    }
}
