using Microsoft.AspNetCore.Mvc;
using GoRide.Models.ViewModels;

namespace GoRide.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Dashboard()
        {
            var model = new UserDashboardViewModel
            {
                UserName = "John Doe",
                TotalRides = 15,
                RecentRides = new List<RideViewModel>
                {
                    new RideViewModel { RideId = "R123", Date = DateTime.Now.AddDays(-1), DropLocation = "Central Mall", Fare = 50, Status = "Completed" },
                    new RideViewModel { RideId = "R124", Date = DateTime.Now.AddDays(-2), DropLocation = "Airport", Fare = 120, Status = "Completed" }
                }
            };
            return View(model);
        }

        public IActionResult BookRide()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BookRide(BookRideViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("TrackRide");
            }
            return View(model);
        }

        public IActionResult TrackRide()
        {
            var model = new LiveTrackingViewModel
            {
                RideId = "R999",
                DriverName = "Mike Ross",
                VehicleNumber = "KA-01-AB-1234",
                DriverPhone = "9876543210",
                CurrentLocation = "Main Street, 4th Block",
                ETA = "5 Mins",
                Status = "Arriving"
            };
            return View(model);
        }

        public IActionResult RideHistory()
        {
            var history = new List<RideViewModel>
            {
                new RideViewModel { RideId = "R101", Date = DateTime.Now.AddDays(-5), PickupLocation = "Home", DropLocation = "Office", Fare = 45, Status = "Completed", DriverName = "Alex" },
                new RideViewModel { RideId = "R102", Date = DateTime.Now.AddDays(-4), PickupLocation = "Office", DropLocation = "Gym", Fare = 30, Status = "Completed", DriverName = "Sam" }
            };
            return View(history);
        }

        public IActionResult Profile()
        {
            var model = new UserProfileViewModel
            {
                FullName = "John Doe",
                Email = "john@example.com",
                Phone = "9988776655",
                Address = "123, Layout"
            };
            return View(model);
        }
    }
}
