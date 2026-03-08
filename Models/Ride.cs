using System.ComponentModel.DataAnnotations;
using GoRide.Models.Enums;

namespace GoRide.Models
{
    public class Ride
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PassengerId { get; set; }

        public int? DriverId { get; set; }

        public int? VehicleId { get; set; }

        [Required]
        public string PickupAddress { get; set; }

        [Required]
        public string DropAddress { get; set; }

        public decimal PickupLatitude { get; set; }
        public decimal PickupLongitude { get; set; }
        public decimal DropLatitude { get; set; }
        public decimal DropLongitude { get; set; }

        public decimal DistanceKm { get; set; }
        public int DurationMinutes { get; set; }

        public decimal EstimatedFare { get; set; }
        public decimal FinalFare { get; set; }

        public RideStatus Status { get; set; } = RideStatus.Pending;

        public DateTime RequestedAt { get; set; } = DateTime.Now;
        public DateTime? AcceptedAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        // Navigation
        public User Passenger { get; set; }
        public Driver? Driver { get; set; }
        public Vehicle? Vehicle { get; set; }
        public ICollection<RideTracking>? TrackingRecords { get; set; }
        public Payment? Payment { get; set; }
    }
}