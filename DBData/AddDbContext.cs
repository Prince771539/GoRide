using GoRide.Models;
using Microsoft.EntityFrameworkCore;

namespace GoRide.DBData
{
    public class AddDbContext:DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<RideTracking> RideTrackings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<DriverEarning> DriverEarnings { get; set; }
        public DbSet<PlatformSetting> PlatformSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Disable Cascade Delete globally
            foreach (var relationship in modelBuilder.Model
                         .GetEntityTypes()
                         .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
