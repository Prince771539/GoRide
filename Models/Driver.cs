using System.ComponentModel.DataAnnotations;

namespace GoRide.Models
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required, StringLength(50)]
        public string LicenseNumber { get; set; }

        public bool IsOnline { get; set; } = false;

        public decimal Rating { get; set; } = 5.0m;

        public bool IsApproved { get; set; } = false;

        // Navigation
        public User User { get; set; }
        public ICollection<Vehicle>? Vehicles { get; set; }
        public ICollection<Ride>? Rides { get; set; }
        public ICollection<DriverEarning>? Earnings { get; set; }
    }
}