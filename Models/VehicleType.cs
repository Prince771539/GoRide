using System.ComponentModel.DataAnnotations;

namespace GoRide.Models
{
    public class VehicleType
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal BaseFare { get; set; }

        [Required]
        public decimal PerKmRate { get; set; }

        [Required]
        public decimal PerMinuteRate { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<Vehicle>? Vehicles { get; set; }
    }
}