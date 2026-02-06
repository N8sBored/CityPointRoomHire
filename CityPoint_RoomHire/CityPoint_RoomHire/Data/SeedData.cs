using CityPoint_RoomHire.Data;
using CityPoint_RoomHire.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CityPoint_RoomHireSeedData.Data
{
    public class SeedData
    {
        public static async Task SeedBookingsAsync(IServiceProvider serviceProvider,UserManager<IdentityUser> userManager)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (!context.Booking.Any())
            {
                var user1 = await userManager.FindByEmailAsync("User1@example.com");
                var user2 = await userManager.FindByEmailAsync("User2@example.com");

                if (user1 != null && user2 != null)
                {
                    var venue1 = await context.Venue.FirstOrDefaultAsync(x => x.VenueName == "Venue 1");
                    var venue2 = await context.Venue.FirstOrDefaultAsync(x => x.VenueName == "Venue 2");
                    var Bookings = new List<Booking>
            {
                new Booking
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    UserId = user1.Id,
                    TotalCost = 1,
                    VenueId = venue1.VenueId
                },
                new Booking
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    UserId = user2.Id,
                    TotalCost = 2,
                    VenueId = venue2.VenueId
                }
            };
                    context.Booking.AddRange(Bookings);
                    await context.SaveChangesAsync();
                }
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
                    },
                    new Venue
                    {
                        City = "London",
                        HourlyRate = 20,
                        Postcode = "EC1BMD",
                        VenueName = "Venue 3"
                    },
                    new Venue
                    {
                        City = "Wolverhampton",
                        HourlyRate = 12,
                        Postcode = "WV14KPS",
                        VenueName = "Venue 4"
                    },
                    new Venue
                    {
                        City = "Liverpool",
                        HourlyRate = 15,
                        Postcode = "CH41PQS",
                        VenueName = "Venue 5"
                    },
                    new Venue
                    {
                        City = "Manchester",
                        HourlyRate = 22,
                        Postcode = "M11AS",
                        VenueName = "Venue 6"
                    }
                };
                await context.Venue.AddRangeAsync(Venues);
                await context.SaveChangesAsync();
            }
        }
        public static async Task SeedRoles(IServiceProvider serviceProvider, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Create roles if none exist
            string[] roleNames = { "Admin", "Manager", "User" };
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    var role = new IdentityRole(roleName);
                    await roleManager.CreateAsync(role);
                }
            }
            var adminUser = await userManager.FindByEmailAsync("admin@example.com");
            if (adminUser == null)
            {
                adminUser = new IdentityUser { UserName = "admin", Email = "admin@example.com", EmailConfirmed = true };
                await userManager.CreateAsync(adminUser, "Admin@123");
            }

            //Add admin role if not already assigned
            if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            // Create User1
            var user1 = await userManager.FindByEmailAsync("User1@example.com");
            if (user1 == null)
            {
                user1 = new IdentityUser
                {
                    UserName = "user1",
                    Email = "User1@example.com",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user1, "User1@123");
            }

            // Add User role
            if (!await userManager.IsInRoleAsync(user1, "User"))
            {
                await userManager.AddToRoleAsync(user1, "User");
            }

            // Create User2
            var user2 = await userManager.FindByEmailAsync("User2@example.com");
            if (user2 == null)
            {
                user2 = new IdentityUser
                {
                    UserName = "user2",
                    Email = "User2@example.com",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user2, "User2@123");
            }

            // Add User role
            if (!await userManager.IsInRoleAsync(user2, "User"))
            {
                await userManager.AddToRoleAsync(user2, "User");
            }
        }
    }
}