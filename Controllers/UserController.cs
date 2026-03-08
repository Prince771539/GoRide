using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoRide.Models.ViewModels.User;
using GoRide.Models.ViewModels.Ride;
using GoRide.Models.Enums;
using GoRide.Models.ViewModels;
using GoRide.DBData;
using GoRide.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace GoRide.Controllers
{
    [SessionAuth(UserRole.Passenger)]
    public class UserController : Controller
    {
        private readonly AddDbContext _context;

        public UserController(AddDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Dashboard()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var totalRides = await _context.Rides.CountAsync(r => r.PassengerId == userId);
            
            var model = new UserDashboardStatsVM
            {
                TotalRides = totalRides,
                TotalSpent = 450.50, // Dummy
                LastRideStatus = RideStatus.Completed // Dummy
            };
            return View(model);
        }

        public IActionResult BookRide()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BookRide(BookingVM model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("TrackRide", new { rideId = "R999" });
            }
            return View(model);
        }

        public IActionResult TrackRide(string rideId)
        {
            var model = new LiveTrackingVM
            {
                RideId = rideId ?? "R999",
                DriverName = "Mike Driver",
                DriverPhone = "9876543210",
                VehicleNumber = "KA-01-AB-1234",
                VehicleModel = "Toyota Etios",
                Status = RideStatus.Started,
                ETA = "4 mins",
                CurrentLocation = "Main Street, Block 4",
                Fare = 120.50
            };
            return View(model);
        }

        public async Task<IActionResult> RideHistory()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var history = await _context.Rides
                .Where(r => r.PassengerId == userId)
                .Select(r => new RideViewModel
                {
                    RideId = r.Id.ToString(),
                    Date = r.RequestedAt,
                    PickupLocation = r.PickupAddress,
                    DropLocation = r.DropAddress,
                    Fare = (double)(r.FinalFare == 0 ? r.EstimatedFare : r.FinalFare),
                    Status = r.Status.ToString(),
                    DriverName = r.Driver != null ? r.Driver.User.FullName : "Unassigned"
                }).ToListAsync();

            if (!history.Any())
            {
                history = new List<RideViewModel>
                {
                    new RideViewModel { RideId = "R101", Date = DateTime.Now.AddDays(-2), PickupLocation = "Home", DropLocation = "Office", Fare = 55, Status = "Completed", DriverName = "Alex" },
                    new RideViewModel { RideId = "R102", Date = DateTime.Now.AddDays(-5), PickupLocation = "Mall", DropLocation = "Home", Fare = 80, Status = "Cancelled", DriverName = "John" }
                };
            }
            return View(history);
        }

        public async Task<IActionResult> Profile()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var user = await _context.Users.FindAsync(userId);

            if (user == null) return NotFound();

            var model = new ProfileVM
            {
                FullName = user.FullName,
                Email = user.Email,
                Phone = user.PhoneNumber,
                Address = "123 Cherry Lane, Metro City" // Dummy
            };
            return View(model);
        }
    }
}
