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

                        },



                        new AirCompany
                        {

                            Name = "Qatar Airways",
                            Address = "www.qatarairways.com",
                            About = "Qatar is the state-owned flag carrier of Qatar",
                            Destinations = new List<Destination>(),
                            Flights = new List<Flight>(),
                            Prices = "1200",
                            Ratings = new List<Rating>()

                        },

                        new AirCompany
                        {

                            Name = "British Airways",
                            Address = "www.britishairways.com",
                            About = "British Airways is the flag carrier of the UK",
                            Destinations = new List<Destination>(),
                            Flights = new List<Flight>(),
                            Prices = "1200",
                            Ratings = new List<Rating>()

                        },

                        new AirCompany
                        {

                            Name = "Air France",
                            Address = "www.britishairways.com",
                            About = "Air France is the flag carrier of France",
                            Destinations = new List<Destination>(),
                            Flights = new List<Flight>(),
                            Prices = "1200",
                            Ratings = new List<Rating>()

                        }






                     );
                    

                }
                else if (!context.RentCompanies.Any())
                {
                    context.RentCompanies.AddRange(

                        new RentCompany
                        {
                            Name = "Enterprise",
                            Address = "www.enterprise.com",
                            Cars = new List<Car>(),
                            Description = "There are almost 6,000 locations across the U.S.",
                            Locations = new List<Location>(),
                            Prices = "1200"

                        },

                        new RentCompany
                        {
                            Name = "National",
                            Address = "www.nationalcar.com",
                            Cars = new List<Car>(),
                            Description = "A huge variety of vehicles to rent.",
                            Locations = new List<Location>(),
                            Prices = "1200"

                        },

                        new RentCompany
                        {
                            Name = "Alamo",
                            Address = "www.alamo.com",
                            Cars = new List<Car>(),
                            Description = "A favorite with millennials.",
                            Locations = new List<Location>(),
                            Prices = "1200"

                        },

                        new RentCompany
                        {
                            Name = "Budget",
                            Address = "www.budget.com",
                            Cars = new List<Car>(),
                            Description = "Some of the cheapest car rentals in the industry.",
                            Locations = new List<Location>(),
                            Prices = "1200"

                        },

                        new RentCompany
                        {
                            Name = "Avis",
                            Address = "www.avis.com",
                            Cars = new List<Car>(),
                            Description = "Good for companies",
                            Locations = new List<Location>(),
                            Prices = "1200"

                        }

                        
                    );
                    
                }

               /* else if (!context.Locations.Any())
                {
                    context.Locations.AddRange(

                        new Location
                        {
                           
                            Location1 = "Proba 23",
                            RentCompanyId = 1,
                            
                           
                        }

                        

                    );
                    context.SaveChanges();
                }*/
                context.SaveChanges();
            }
        }
    }
}
