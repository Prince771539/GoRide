using System.ComponentModel.DataAnnotations;

namespace GoRide.Models.ViewModels
{
    public class AdminDashboardViewModel
    {
        public int TotalUsers { get; set; }
        public int TotalDrivers { get; set; }
        public int TotalRides { get; set; }
        public double TotalRevenue { get; set; }
        public List<RideViewModel> RecentRides { get; set; }
    }

    public class UserListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } // Passenger / Driver
        public string Status { get; set; } // Active / Blocked
        public DateTime JoinDate { get; set; }
    }

    public class FareSettingsViewModel
    {
        [Required]
        public double BaseFareBike { get; set; }

        [Required]
        public double PerKmBike { get; set; }

        [Required]
        public double BaseFareCar { get; set; }

        [Required]
        public double PerKmCar { get; set; }

        [Required]
        public double SurgeMultiplier { get; set; }
    }
    
    public class VehicleViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } // e.g. Sedan, Mini
        [Required]
        public string Type { get; set; } // Car, Bike
        [Required]
        public int Capacity { get; set; }
        [Required]
        public string IconUrl { get; set; }
    }
}
