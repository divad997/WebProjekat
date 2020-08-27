using DBProjekat.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBProjekat.Data
{
    public class AgencyContext: DbContext
    {
        public AgencyContext(DbContextOptions<AgencyContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AirCompany> AirCompanies { get; set; }
        public DbSet<RentCompany> RentCompanies { get; set; }
    }
}
