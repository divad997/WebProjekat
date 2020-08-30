using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DBProjekat.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Password must be longer than 4 characters")]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
        
        public string Name { get; set; }
        
        public string LastName { get; set; }
        
        public string City { get; set; }
      
        public string PhoneNumber { get; set; }
        
        public string Role { get; set; }

    }
}
