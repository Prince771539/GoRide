using GoRide.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace GoRide.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        public int RideId { get; set; }

        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public string? TransactionId { get; set; }

        public DateTime? PaidAt { get; set; }

        public Ride Ride { get; set; }
    }
}