using System.ComponentModel.DataAnnotations;

namespace GoRide.Models.ViewModels
{
    public class UserDashboardViewModel
    {
        public string UserName { get; set; }
        public int TotalRides { get; set; }
        public RideViewModel ActiveRide { get; set; }
        public List<RideViewModel> RecentRides { get; set; }
    }

    public class BookRideViewModel
    {
        [Required(ErrorMessage = "Pickup Location is required")]
        public string PickupLocation { get; set; }

        [Required(ErrorMessage = "Drop Location is required")]
        public string DropLocation { get; set; }

        [Required]
        public string VehicleType { get; set; } // Bike, Car, SUV

        public double EstimatedFare { get; set; }
        public string Distance { get; set; }
        public string Duration { get; set; }
    }

    public class RideViewModel
    {
        public string RideId { get; set; }
        public string DriverName { get; set; }
        public string VehicleNumber { get; set; }
        public string PickupLocation { get; set; }
        public string DropLocation { get; set; }
        public DateTime Date { get; set; }
        public double Fare { get; set; }
        public string Status { get; set; } // Completed, Cancelled, Ongoing
        public string PassengerName { get; internal set; }
    }

    public class UserProfileViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
    
    public class LiveTrackingViewModel
    {
        public string RideId { get; set; }
        public string DriverName { get; set; }
        public string VehicleNumber { get; set; }
        public string DriverPhone { get; set; }
        public string CurrentLocation { get; set; }
        public string ETA { get; set; }
        public string Status { get; set; }
    }
}
