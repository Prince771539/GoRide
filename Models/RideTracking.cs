using System.ComponentModel.DataAnnotations;

namespace GoRide.Models
{
    public class RideTracking
    {
        [Key]
        public int Id { get; set; }

        public int RideId { get; set; }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public DateTime RecordedAt { get; set; } = DateTime.Now;

        public Ride Ride { get; set; }
    }
}