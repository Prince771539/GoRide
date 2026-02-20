using Microsoft.AspNetCore.Mvc;
using GoRide.Models.ViewModels;

namespace GoRide.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            var model = new AdminDashboardViewModel
            {
                TotalUsers = 120,
                TotalDrivers = 45,
                TotalRides = 1500,
                TotalRevenue = 250000.00,
                RecentRides = new List<RideViewModel>
                {
                    new RideViewModel { RideId = "R1001", DriverName = "Mike", PickupLocation = "A", DropLocation = "B", Fare = 50, Status = "Completed" }
                }
            };
            return View(model);
        }

        public IActionResult UsersList()
        {
            var users = new List<UserListViewModel>
            {
                new UserListViewModel { Id = 1, Name = "John Doe", Email = "john@example.com", Role = "Passenger", Status = "Active", JoinDate = DateTime.Now.AddMonths(-1) },
                new UserListViewModel { Id = 2, Name = "Jane Smith", Email = "jane@example.com", Role = "Passenger", Status = "Blocked", JoinDate = DateTime.Now.AddMonths(-2) }

            };
            return View(users);
        }

        public IActionResult DriversList()
        {
            var drivers = new List<UserListViewModel>
            {
                new UserListViewModel { Id = 3, Name = "Mike Ross", Email = "mike@driver.com", Role = "Driver", Status = "Active", JoinDate = DateTime.Now.AddMonths(-3) }
            };
            return View(drivers);
        }
        
        public IActionResult RidesList()
        {
            var rides = new List<RideViewModel>
            {
                 new RideViewModel { RideId = "R555", DriverName = "Mike", PickupLocation = "X", DropLocation = "Y", Fare = 200, Status = "Cancelled", Date = DateTime.Now }
            };
            return View(rides);
        }

        public IActionResult VehicleList()
        {
            var vehicles = new List<VehicleViewModel>
            {
                new VehicleViewModel { Id = 1, Name = "Bike", Type = "Bike", Capacity = 1, IconUrl = "bi-bicycle" },
                new VehicleViewModel { Id = 2, Name = "Standard Car", Type = "Car", Capacity = 4, IconUrl = "bi-car-front" },
                new VehicleViewModel { Id = 3, Name = "SUV", Type = "Car", Capacity = 6, IconUrl = "bi-truck" }
            };
            return View(vehicles);
        }

        public IActionResult FareSettings()
        {
            var model = new FareSettingsViewModel
            {
                BaseFareBike = 20,
                PerKmBike = 8,
                BaseFareCar = 40,
                PerKmCar = 12,
                SurgeMultiplier = 1.0
            };
            return View(model);
        }
    }
}
