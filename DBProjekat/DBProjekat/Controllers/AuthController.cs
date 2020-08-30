using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DBProjekat.Data;
using DBProjekat.Dtos;
using DBProjekat.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DBProjekat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        private readonly IConfiguration _config;

        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }


        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userDto)
        {
            userDto.Username = userDto.Username.ToLower();

            if (await _repo.UserExists(userDto.Username))
                return BadRequest("Username already exists");
            else if (await _repo.EmailExists(userDto.Email))
                return BadRequest("Email already exists");
            else if (userDto.Password != userDto.ConfirmPassword)
                return BadRequest("Passwords must match");

            var userToCreate = new User()
            {
                Username = userDto.Username,
                Email = userDto.Email,
                Password = userDto.Password,
                Name = userDto.Name,
                LastName = userDto.LastName,
                City = userDto.City,
                PhoneNumber = userDto.PhoneNumber,
                Role = "User"
                

            };
            

            var createdUser = await _repo.RegisterAsync(userToCreate, userDto.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userDto)
        {
            var userFromRepo = await _repo.LoginAsync(userDto.Username.ToLower(), userDto.Password);

            if (userFromRepo == null)
                return Unauthorized();
            else if (userFromRepo.Password != userDto.Password || userFromRepo.Username != userDto.Username)
                return BadRequest("Username or password is incorrect");


            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(5),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}