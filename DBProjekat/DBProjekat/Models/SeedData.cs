using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBProjekat.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DBProjekat.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AgencyContext(serviceProvider.GetRequiredService<DbContextOptions<AgencyContext>>()))
            {
                if(!context.AirCompanies.Any())
                {
                    context.AirCompanies.AddRange(
                        new AirCompany
                        {
                            
                            Name = "AirSerbia",
                            Address = "www.airserbia.com",
                            About = "Air Serbia is the flag carrier of Serbia.",
                            Destinations = new List<Destination>(),
                            Flights = new List<Flight>(),
                            Prices = "1200",
                            Ratings = new List<Rating>()

                        },

                        new AirCompany
                        {
                            
                            Name = "Lufthansa",
                            Address = "www.lufthansa.com",
                            About = "Lufthansa is the largest German airline.",
                            Destinations = new List<Destination>(),
                            Flights = new List<Flight>(),
                            Prices = "1200",
                            Ratings = new List<Rating>()

                        }
                     );
                    context.SaveChanges();
                }
            }
        }
    }
}
