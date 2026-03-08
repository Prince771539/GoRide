using System.ComponentModel.DataAnnotations;

namespace GoRide.Models
{
    public class PlatformSetting
    {
        [Key]
        public int Id { get; set; }

        public decimal PlatformFeePercent { get; set; }

        public decimal SurgeMultiplier { get; set; }

        public decimal CancellationFee { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}