using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CityPointRoomHire.Models;

namespace CityPointRoomHire.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CityPointRoomHire.Models.Booking> Booking { get; set; } = default!;
        public DbSet<CityPointRoomHire.Models.User> User { get; set; } = default!;
        public DbSet<CityPointRoomHire.Models.Venue> Venue { get; set; } = default!;
    }
}
