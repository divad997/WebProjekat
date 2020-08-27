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
        public string Car1 { get; set; }
        [Required]
        public List<Rating> Rating { get; set; }
        [Required]
        public RentCompany RentCompany { get; set; }
    }
}
