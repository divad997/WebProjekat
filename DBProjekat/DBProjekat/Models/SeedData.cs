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
                
                if (!context.Locations.Any())
                {
                    context.Locations.AddRange(
                        new Location
                        {
                            Location1 = "Belgrade, Serbia"
                        },

                        new Location
                        {
                            Location1 = "Berlin, Germany"
                        },

                        new Location
                        {
                            Location1 = "Qinhuangdao, China"
                        }
                    );
                }
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
                if (!context.Cars.Any())
                {
                    List<Car> Cars = new List<Car>();
                    context.Cars.AddRange(

                        new Car
                        {
                            Name = "Fiat 500",
                            Type = "Mini",
                            DailyRate = 17.16,
                        },

                        new Car
                        {
                            Name = "Volkswagen Polo",
                            Type = "Economy",
                            DailyRate = 20.93,
                        },

                        new Car
                        {
                            Name = "Volkswagen Golf",
                            Type = "Compact",
                            DailyRate = 24.13,
                        },

                        new Car
                        {
                            Name = "Ford Focus",
                            Type = "Compact",
                            DailyRate = 24.15,
                        },

                        new Car
                        {
                            Name = "Volkswagen Passat",
                            Type = "Standard",
                            DailyRate = 17.16,
                        },

                        new Car
                        {
                            Name = "Mercedes E Class",
                            Type = "Luxury",
                            DailyRate = 73.77,
                        },

                        new Car
                        {
                            Name = "Ford Mondeo",
                            Type = "Standard",
                            DailyRate = 17.16,
                        }
                        );
                    context.SaveChanges();
                }
                if (!context.RentCompanies.Any())
                {
                    context.RentCompanies.AddRange(

                        new RentCompany
                        {
                            Name = "Enterprise",
                            Address = "www.enterprise.com",
                            Cars = new List<Car>(),
                            CarBookings = new List<CarBooking>(),
                            Description = "There are almost 6,000 locations across the U.S.",
                            Locations = new List<Location>(),
                            Prices = "1200"

                        },

                        new RentCompany
                        {
                            Name = "National",
                            Address = "www.nationalcar.com",
                            Cars = context.Cars.ToList(),
                            CarBookings = new List<CarBooking>(),
                            Description = "A huge variety of vehicles to rent.",
                            Locations = context.Locations.ToList(),
                            Prices = "1200"

                        },

                        new RentCompany
                        {
                            Name = "Alamo",
                            Address = "www.alamo.com",
                            Cars = new List<Car>(),
                            CarBookings = new List<CarBooking>(),
                            Description = "A favorite with millennials.",
                            Locations = new List<Location>(),
                            Prices = "1200"

                        },

                        new RentCompany
                        {
                            Name = "Budget",
                            Address = "www.budget.com",
                            Cars = new List<Car>(),
                            CarBookings = new List<CarBooking>(),
                            Description = "Some of the cheapest car rentals in the industry.",
                            Locations = new List<Location>(),
                            Prices = "1200"

                        },

                        new RentCompany
                        {
                            Name = "Avis",
                            Address = "www.avis.com",
                            Cars = new List<Car>(),
                            CarBookings = new List<CarBooking>(),
                            Description = "Good for companies",
                            Locations = new List<Location>(),
                            Prices = "1200"

                        }

                        
                    );
                    
                }
                if (!context.Users.Any())
                {
                    context.Users.AddRange(

                        new User
                        {
                           Username = "admin",
                           Email = "admin@admin",
                           Password = "admin",
                           Name = "Admir",
                           LastName = "Admirovski",
                           City = "Adminovo",
                           PhoneNumber = "2131313",
                           PassportNumber = "3213131",
                           Role = "Admin"
                           
                        }

                        

                    );
                    
                }
                context.SaveChanges();
            }
        }
    }
}
