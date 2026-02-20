using Microsoft.AspNetCore.Mvc;
using GoRide.Models.ViewModels;

namespace GoRide.Controllers
{
    public class DriverController : Controller
    {
        public IActionResult Dashboard()
        {
            var model = new DriverDashboardViewModel
            {
                DriverName = "Mike Ross",
                IsOnline = true,
                TodayEarnings = 450.50,
                TodayRides = 4,
                CurrentRequest = new RideRequestViewModel
                {
                    RequestId = "REQ001",
                    PassengerName = "Alice",
                    PickupLocation = "Tech Park",
                    DropLocation = "Metro Station",
                    EstimatedFare = 85,
                    DistanceKM = 4.2
                }
            };
            return View(model);
        }

        public IActionResult RideRequests()
        {
             var requests = new List<RideRequestViewModel>
            {
                new RideRequestViewModel { RequestId = "REQ002", PassengerName = "Bob", PickupLocation = "Mall", DropLocation = "Cinema", EstimatedFare = 40, DistanceKM = 2.0 },
                new RideRequestViewModel { RequestId = "REQ003", PassengerName = "Charlie", PickupLocation = "Hospital", DropLocation = "Residency", EstimatedFare = 60, DistanceKM = 3.5 }
            };
            return View(requests);
        }

        public IActionResult ActiveRide()
        {
            var model = new RideViewModel
            {
                RideId = "R999",
                DriverName = "Mike Ross",
                PassengerName = "Alice", // Added internally just for this view context if needed
                PickupLocation = "Tech Park",
                DropLocation = "Metro Station",
                VehicleNumber = "KA-01-AB-1234",
                Fare = 85,
                Status = "Ongoing"
            };
            // Note: RideViewModel typically doesn't have PassengerName, using ViewData or Bag if model strictly follows shared definition.
            ViewBag.PassengerName = "Alice"; 
            ViewBag.PassengerPhone = "9123456780";
            return View(model);
        }

        public IActionResult Earnings()
        {
            var model = new DriverEarningsViewModel
            {
                TotalEarnings = 12500.00,
                WeeklyEarnings = 2300.00,
                TripHistory = new List<RideViewModel>
                {
                    new RideViewModel { RideId = "R101", Date = DateTime.Now.AddDays(-1), Fare = 45, Status = "Completed" },
                    new RideViewModel { RideId = "R102", Date = DateTime.Now.AddDays(-1), Fare = 55, Status = "Completed" }
                }
            };
            return View(model);
        }

        public IActionResult History()
        {
             var history = new List<RideViewModel>
            {
                new RideViewModel { RideId = "R088", Date = DateTime.Now.AddDays(-10), PickupLocation = "Area A", DropLocation = "Area B", Fare = 100, Status = "Completed" }
            };
            return View(history);
        }

        public IActionResult Profile()
        {
            var model = new DriverProfileViewModel
            {
                FullName = "Mike Ross",
                Email = "mike@driver.com",
                Phone = "9876543210",
                LicenseNumber = "DL-KA-2024-001",
                VehicleModel = "Honda Shine",
                VehicleNumber = "KA-53-E-1234",
                VehicleType = "Bike",
                Rating = 4.8
            };
            return View(model);
        }
    }
}
