using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CityPoint_RoomHire.Models;

namespace CityPoint_RoomHire.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CityPoint_RoomHire.Models.Booking> Booking { get; set; } = default!;
        public DbSet<CityPoint_RoomHire.Models.User> User { get; set; } = default!;
        public DbSet<CityPoint_RoomHire.Models.Venue> Venue { get; set; } = default!;
    }
}
