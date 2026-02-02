using CityPointRoomHire.Data;
using CityPointRoomHire.Models;
using Microsoft.EntityFrameworkCore;

namespace CityPointRoomHireSeedData.Data
{
    public class SeedData
    {
        public static async Task SeedBookingsAsync(ApplicationDbContext context)
        {
            if (!await context.Booking.AnyAsync()) //If there is nothing in the Bookings table, it runs the seed data function
            {
                var Bookings = new List<Booking> //Sets a list called Bookings to be made up of individual items each called "booking"
                {
                    new Booking //Creates a new booking to seed the Bookings table with
                    {
                        StartDate = DateTime.Now, //Sets the value of StartDate to whatever the current date and time is
                        EndDate = DateTime.Now, //Sets the value of EndDate to whatever the current date and time is
                        TotalCost = 100, //Sets the parameter for the total cost, though this will be automatically calculated for created bookings
                    },
                    new Booking
                    {
                        StartDate = DateTime.Now, //Sets the value of StartDate to whatever the current date and time is
                        EndDate = DateTime.Now, //Sets the value of EndDate to whatever the current date and time is
                        TotalCost = 120, //Sets the parameter for the total cost, though this will be automatically calculated for created bookings
                    }
                };
                await context.Booking.AddRangeAsync(Bookings); //Adds a range for how many bookings are in the list (currently 2)
                await context.SaveChangesAsync(); //Saves the changes applied by creating the list and the range
            }
        }

        public static async Task SeedVenuesAsync(ApplicationDbContext context) 
        {
            if (!await context.Venue.AnyAsync()) //If there is nothing in the Venues table, it runs the seed data function
            {
                var Venues = new List<Venue> //Sets a list called Venues to be made up of individual items each called "Venue"
                {
                    new Venue //Creates a new Venue to seed the Bookings table with
                    {
                        City = "Wolverhampton",
                        HourlyRate = 10,
                        Postcode = "WV1DTQ",
                        VenueName = "Venue 1"
                    },
                    new Venue //Creates a new Venue to seed the Bookings table with
                    {
                        City = "Birmingham",
                        HourlyRate = 15,
                        Postcode = "BM2JXT",
                        VenueName = "Venue 2"
                    }
                };
                await context.Venue.AddRangeAsync(Venues); //Adds a range for how many venues are in the list (currently 2)
                await context.SaveChangesAsync(); //Saves the changes applied by creating the list and the range
            }
        }

    }

}
