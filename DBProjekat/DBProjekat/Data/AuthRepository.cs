using System;
using System.Linq;
using System.Threading.Tasks;
using DBProjekat.Dtos;
using DBProjekat.Models;
using Microsoft.EntityFrameworkCore;

namespace DBProjekat.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AgencyContext _context;

        public AuthRepository(AgencyContext context)
        {
            _context = context;
        }
        public async Task<User> LoginAsync(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);

            return user;

            
        }

        public async Task<User> RegisterAsync(User user, string password)
        {

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(); 

            return user;
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.Username == username))
                return true;

            return false;
        }

        public async Task<bool> EmailExists(string email)
        {
            if (await _context.Users.AnyAsync(x => x.Email == email))
                return true;

            return false;
        }

        
    }
}
