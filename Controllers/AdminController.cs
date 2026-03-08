using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoRide.Models;
using GoRide.Models.ViewModels;
using GoRide.Models.ViewModels.Admin;
using GoRide.Models.ViewModels.Ride;
using GoRide.Models.ViewModels.Vehicle;
using GoRide.DBData;
using GoRide.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace GoRide.Controllers
{
    [SessionAuth(Models.Enums.UserRole.Admin)]
    public class AdminController : Controller
    {
        private readonly AddDbContext _context;

        public AdminController(AddDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Dashboard()
        {
            var totalUsers = await _context.Users.CountAsync(u => u.Role == Models.Enums.UserRole.Passenger);
            var totalDrivers = await _context.Drivers.CountAsync();
            var activeRides = await _context.Rides.CountAsync(r => r.Status == Models.Enums.RideStatus.Started || r.Status == Models.Enums.RideStatus.Accepted);

            var model = new AdminStatsVM
            {
                TotalUsers = totalUsers,
                TotalDrivers = totalDrivers,
                ActiveRides = activeRides,
                TotalRevenue = 50000.00 // Placeholder logic for revenue
            };
            return View(model);
        }

        public async Task<IActionResult> UsersList()
        {
            var users = await _context.Users
                .Where(u => u.Role == Models.Enums.UserRole.Passenger)
                .Select(u => new UserListViewModel
                {
                    Id = u.UserId,
                    Name = u.FullName,
                    Email = u.Email,
                    Role = u.Role.ToString(),
                    Status = u.IsActive ? "Active" : "Inactive",
                    JoinDate = u.CreatedAt
                }).ToListAsync();

            return View(users);
        }

        public async Task<IActionResult> DriversList()
        {
            var drivers = await _context.Drivers
                .Include(d => d.User)
                .Select(d => new UserListVM
                {
                    Id = d.Id,
                    Name = d.User.FullName,
                    Email = d.User.Email,
                    Role = "Driver",
                    Status = d.IsApproved ? "Approved" : "Pending",
                    JoinedDate = d.User.CreatedAt
                }).ToListAsync();

            return View(drivers);
        }

        public IActionResult RidesList()
        {
            // Dummy for now, can implement same as above later
            var rides = new List<RideHistoryVM>
            {
                 new RideHistoryVM { RideId = "R1001", Date = DateTime.Now, DriverName = "Mike", Pickup = "A", Drop = "B", Fare = 100, Status = "Completed" }
            };
            return View(rides);
        }

        public async Task<IActionResult> VehicleList()
        {
            var vehicles = await _context.VehicleTypes
                .Select(v => new VehicleTypeVM
                {
                    Id = v.Id,
                    Name = v.Name,
                    BaseFare = (double)v.BaseFare,
                    PerKmRate = (double)v.PerKmRate,
                    PerMinuteRate = (double)v.PerMinuteRate
                }).ToListAsync();

            return View(vehicles);
        }

        [HttpGet]
        public IActionResult AddVehicle()
        {
            return View(new VehicleTypeCreateVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVehicle(VehicleTypeCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var vt = new VehicleType
                {
                    Name = model.Name,
                    BaseFare = (decimal)model.BaseFare,
                    PerKmRate = (decimal)model.PerKmRate,
                    PerMinuteRate = (decimal)model.PerMinuteRate,
                    IsActive = true
                };

                _context.VehicleTypes.Add(vt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(VehicleList));
            }
            return View(model);
        }
        
        [HttpGet]
        public async Task<IActionResult> EditVehicle(int id)
        {
            var v = await _context.VehicleTypes.FindAsync(id);
            if (v == null) return NotFound();

            var model = new VehicleTypeEditVM
            {
                Id = v.Id,
                Name = v.Name,
                BaseFare = (double)v.BaseFare,
                PerKmRate = (double)v.PerKmRate,
                PerMinuteRate = (double)v.PerMinuteRate
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditVehicle(VehicleTypeEditVM model)
        {
            if (ModelState.IsValid)
            {
                var v = await _context.VehicleTypes.FindAsync(model.Id);
                if (v == null) return NotFound();

                v.Name = model.Name;
                v.BaseFare = (decimal)model.BaseFare;
                v.PerKmRate = (decimal)model.PerKmRate;
                v.PerMinuteRate = (decimal)model.PerMinuteRate;

                _context.VehicleTypes.Update(v);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(VehicleList));
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var v = await _context.VehicleTypes.FindAsync(id);
            if (v != null)
            {
                _context.VehicleTypes.Remove(v);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(VehicleList));
        }

        public IActionResult FareSettings()
        {
            var model = new SettingsVM
            {
                SurgeMultiplier = 1.0,
                PlatformFeePercentage = 15.0
            };
            return View(model);
        }
    }
}
