using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoRide.Models.ViewModels;
using GoRide.Models.ViewModels.Driver;
using GoRide.Models.ViewModels.Ride;
using GoRide.Models.Enums;
using GoRide.DBData;
using GoRide.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace GoRide.Controllers
{
    [SessionAuth(UserRole.Driver)]
    public class DriverController : Controller
    {
        private readonly AddDbContext _context;

        public DriverController(AddDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Dashboard()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var driver = await _context.Drivers.FirstOrDefaultAsync(d => d.UserId == userId);

            if (driver == null) return NotFound();

            var todayTrips = await _context.Rides.CountAsync(r => r.DriverId == driver.Id && r.RequestedAt.Date == DateTime.Today);

            var model = new DriverDashboardStatsVM
            {
                IsOnline = driver.IsOnline,
                TodayEarnings = 1250.00, // Dummy
                TodayTrips = todayTrips,
                Rating = (double)driver.Rating
            };
            return View(model);
        }

        public IActionResult RideRequests()
        {
             var requests = new List<RideRequestVM>
            {
                new RideRequestVM { RequestId = "REQ001", PassengerName = "Alice", PickupLocation = "Tech Park", DropLocation = "Metro Station", EstimatedFare = 85, DistanceKM = 4.2, PassengerRating = "4.8" },
                new RideRequestVM { RequestId = "REQ002", PassengerName = "Bob", PickupLocation = "City Center", DropLocation = "Airport", EstimatedFare = 450, DistanceKM = 25.0, PassengerRating = "4.5" }
            };
            return View(requests);
        }

        public IActionResult ActiveRide()
        {
            var model = new LiveTrackingVM
            {
                RideId = "R888",
                DriverName = "Mike Driver", // Self
                VehicleNumber = "KA-01-AB-1234",
                Status = RideStatus.Accepted,
                CurrentLocation = "Tech Park Gate 1",
                Fare = 85.00
            };
            // Adding extra Context for Driver View
            ViewData["PassengerName"] = "Alice";
            ViewData["PassengerPhone"] = "9876543210";
            return View(model);
        }

        public async Task<IActionResult> Earnings()
        {
             var model = new DriverEarningsViewModel
            {
                TotalEarnings = 15000.00,
                WeeklyEarnings = 4500.00,
                MonthlyEarnings = 12000.00,
                TripHistory = new List<RideViewModel>
                {
                    new RideViewModel { RideId = "101", Date = DateTime.Now.AddHours(-2), Fare = 50, Status = "Completed" },
                    new RideViewModel { RideId = "102", Date = DateTime.Now.AddHours(-5), Fare = 75, Status = "Completed" }
                }
            };
            return View(model);
        }

        public async Task<IActionResult> History()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var driver = await _context.Drivers.FirstOrDefaultAsync(d => d.UserId == userId);

            if (driver == null) return NotFound();

            var history = await _context.Rides
                .Where(r => r.DriverId == driver.Id)
                .Select(r => new RideViewModel
                {
                    RideId = r.Id.ToString(),
                    Date = r.RequestedAt,
                    PickupLocation = r.PickupAddress,
                    DropLocation = r.DropAddress,
                    Fare = (double)(r.FinalFare == 0 ? r.EstimatedFare : r.FinalFare),
                    Status = r.Status.ToString()
                }).ToListAsync();

            if (!history.Any())
            {
                history = new List<RideViewModel>
                {
                    new RideViewModel { RideId = "101", Date = DateTime.Now.AddDays(-1), PickupLocation = "Area A", DropLocation = "Area B", Fare = 50, Status = "Completed" }
                };
            }
            return View(history);
        }
    }
}
