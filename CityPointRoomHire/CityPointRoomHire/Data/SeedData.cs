using CityPointRoomHire.Data;
using CityPointRoomHire.Models;
using Microsoft.EntityFrameworkCore;

namespace CityPointRoomHireSeedData.Data
{
    public class SeedData
    {
        public static async Task SeedBookingsAsync(ApplicationDbContext context)
        {
            if (!await context.Booking.AnyAsync())
            {
                var Bookings = new List<Booking>
                {
                    new Booking
                    {
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,
                        TotalCost = 100,
                    },
                    new Booking
                    {
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,
                        TotalCost = 120,
                    }
                };
                await context.Booking.AddRangeAsync(Bookings);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedVenuesAsync(ApplicationDbContext context)
        {
            if (!await context.Venue.AnyAsync())
            {
                var Venues = new List<Venue>
                {
                    new Venue
                    {
                        City = "Wolverhampton",
                        HourlyRate = 10,
                        Postcode = "WV1DTQ",
                        VenueName = "Venue 1"
                    },
                    new Venue
                    {
                        City = "Birmingham",
                        HourlyRate = 15,
                        Postcode = "BM2JXT",
                        VenueName = "Venue 2"
                    }
                };
                await context.Venue.AddRangeAsync(Venues);
                await context.SaveChangesAsync();
            }
        }

    }

}
