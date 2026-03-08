using System;
using System.Collections.Generic;
using GoRide.Models.Enums;

namespace GoRide.Models.ViewModels
{
    public class RideViewModel
    {
        public string RideId { get; set; }
        public DateTime Date { get; set; }
        public string DriverName { get; set; }
        public string PickupLocation { get; set; }
        public string DropLocation { get; set; }
        public string Pickup { get; set; }
        public string Drop { get; set; }
        public double Fare { get; set; }
        public string Status { get; set; }
    }

    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class UserRegisterViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class DriverRegisterViewModel : UserRegisterViewModel
    {
        public string LicenseNumber { get; set; }
        public string VehicleType { get; set; }
        public string VehicleNumber { get; set; }
    }

    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class DriverProfileViewModel
    {
        public string FullName { get; set; }
        public string VehicleType { get; set; }
        public double Rating { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LicenseNumber { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleNumber { get; set; }
    }

    public class VehicleViewModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public string IconUrl { get; set; }
    }

    public class DriverEarningsViewModel
    {
        public double TotalEarnings { get; set; }
        public double WeeklyEarnings { get; set; }
        public double MonthlyEarnings { get; set; }
        public List<RideViewModel> TripHistory { get; set; } = new List<RideViewModel>();
    }

    public class UserListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public DateTime JoinDate { get; set; }
    }
}

namespace GoRide.Models.ViewModels.Admin
{
    public class AdminStatsVM
    {
        public int TotalUsers { get; set; }
        public int TotalDrivers { get; set; }
        public int ActiveRides { get; set; }
        public double TotalRevenue { get; set; }
    }

    public class UserListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public DateTime JoinedDate { get; set; }
    }

    public class SettingsVM
    {
        public double SurgeMultiplier { get; set; }
        public double PlatformFeePercentage { get; set; }
    }
}

namespace GoRide.Models.ViewModels.Ride
{
    public class RideHistoryVM : RideViewModel
    {
        // Backward compatibility for controllers using RideHistoryVM
    }

    public class LiveTrackingVM
    {
        public string RideId { get; set; }
        public string DriverName { get; set; }
        public string DriverPhone { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleModel { get; set; }
        public RideStatus Status { get; set; }
        public string ETA { get; set; }
        public string CurrentLocation { get; set; }
        public double Fare { get; set; }
    }

    public class BookingVM
    {
        public string PickupAddress { get; set; }
        public string DropAddress { get; set; }
        public int VehicleTypeId { get; set; }
    }

    public class RideRequestVM
    {
        public string RequestId { get; set; }
        public string PassengerName { get; set; }
        public string PickupLocation { get; set; }
        public string DropLocation { get; set; }
        public double EstimatedFare { get; set; }
        public double DistanceKM { get; set; }
        public string PassengerRating { get; set; }
    }
}

namespace GoRide.Models.ViewModels.Vehicle
{
    public class VehicleTypeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double BaseFare { get; set; }
        public double PerKmRate { get; set; }
        public double PerMinuteRate { get; set; }
        public int Capacity { get; set; }
        public string IconClass { get; set; }
    }

    public class VehicleTypeCreateVM
    {
        public string Name { get; set; }
        public double BaseFare { get; set; }
        public double PerKmRate { get; set; }
        public double PerMinuteRate { get; set; }
    }

    public class VehicleTypeEditVM : VehicleTypeCreateVM
    {
        public int Id { get; set; }
    }
}

namespace GoRide.Models.ViewModels.User
{
    public class UserDashboardStatsVM
    {
        public int TotalRides { get; set; }
        public double TotalSpent { get; set; }
        public RideStatus LastRideStatus { get; set; }
    }

    public class ProfileVM
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}

namespace GoRide.Models.ViewModels.Driver
{
    public class DriverDashboardStatsVM
    {
        public bool IsOnline { get; set; }
        public double TodayEarnings { get; set; }
        public int TodayTrips { get; set; }
        public double Rating { get; set; }
    }
}

namespace GoRide.Models
{
    // Keeping namespaces clean
}
