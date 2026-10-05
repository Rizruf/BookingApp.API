using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .Property(r => r.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Room>()
                .ToTable(r => r.HasCheckConstraint("CK_Room_SleepingPlaces", "[SleepingPlaces] >= 1 AND [SleepingPlaces] <= 10"));
        }
    }
}
