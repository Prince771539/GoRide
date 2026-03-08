using System.ComponentModel.DataAnnotations;

namespace GoRide.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DriverId { get; set; }

        [Required]
        public int VehicleTypeId { get; set; }

        [Required, StringLength(20)]
        public string VehicleNumber { get; set; }

        [Required, StringLength(100)]
        public string Model { get; set; }

        [Required, StringLength(50)]
        public string Color { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation
        public Driver Driver { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}