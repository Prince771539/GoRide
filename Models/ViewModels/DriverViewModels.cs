using System.ComponentModel.DataAnnotations;

namespace GoRide.Models.ViewModels
{
    public class DriverDashboardViewModel
    {
        public string DriverName { get; set; }
        public bool IsOnline { get; set; }
        public double TodayEarnings { get; set; }
        public int TodayRides { get; set; }
        public RideRequestViewModel CurrentRequest { get; set; }
        public RideViewModel ActiveRide { get; set; }
    }

    public class RideRequestViewModel
    {
        public string RequestId { get; set; }
        public string PassengerName { get; set; }
        public string PickupLocation { get; set; }
        public string DropLocation { get; set; }
        public double EstimatedFare { get; set; }
        public double DistanceKM { get; set; }
    }

    public class DriverEarningsViewModel
    {
        public double TotalEarnings { get; set; }
        public double WeeklyEarnings { get; set; }
        public List<RideViewModel> TripHistory { get; set; }
    }

    public class DriverProfileViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LicenseNumber { get; set; }
        public string VehicleModel { get; set; } // e.g. Honda City
        public string VehicleNumber { get; set; }
        public string VehicleType { get; set; }
        public double Rating { get; set; }
    }
}
