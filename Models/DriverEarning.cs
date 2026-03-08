using System.ComponentModel.DataAnnotations;

namespace GoRide.Models
{
    public class DriverEarning
    {
        [Key]
        public int Id { get; set; }

        public int DriverId { get; set; }

        public int RideId { get; set; }

        public decimal Amount { get; set; }

        public decimal PlatformCommission { get; set; }

        public decimal NetAmount { get; set; }

        public DateTime EarnedAt { get; set; } = DateTime.Now;

        public Driver Driver { get; set; }
        public Ride Ride { get; set; }
    }
}