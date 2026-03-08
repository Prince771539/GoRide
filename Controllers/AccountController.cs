using GoRide.DBData;
using GoRide.Models;
using GoRide.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoRide.Controllers
{
    public class AccountController : Controller
    {
        private readonly AddDbContext _context; 
        public AccountController(AddDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserLogin(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email && u.PasswordHash == model.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(model);
            }
            // Save session
            HttpContext.Session.SetInt32("UserId", user.UserId);
            HttpContext.Session.SetString("UserName", user.FullName);
            HttpContext.Session.SetString("UserRole", user.Role.ToString());

            // Redirect based on role
            if (user.Role == Models.Enums.UserRole.Passenger)
                return RedirectToAction("Dashboard", "User");

            if (user.Role == Models.Enums.UserRole.Driver)
                return RedirectToAction("Dashboard", "Driver");

            if (user.Role == Models.Enums.UserRole.Admin)
                return RedirectToAction("Dashboard", "Admin");
            return RedirectToAction("Dashboard", "User");
        }

        [HttpGet]
        public IActionResult UserRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // Check if email already exists
            var existingUser = _context.Users
                .FirstOrDefault(u => u.Email == model.Email);

            if (existingUser != null)
            {
                ModelState.AddModelError("", "Email already exists.");
                return View(model);
            }
            var user = new User
            {
                FullName = model.FullName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                PasswordHash = model.Password, // ⚠ We will improve this later (hashing)
                Role = (Models.Enums.UserRole)1,
                CreatedAt = DateTime.Now
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("UserLogin");
        }

        [HttpGet]
        public IActionResult DriverRegister()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DriverRegister(DriverRegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var existingUser = _context.Users.FirstOrDefault(u => u.Email == model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("", "Email already exists.");
                return View(model);
            }

            var user = new User
            {
                FullName = model.FullName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                PasswordHash = model.Password,
                Role = Models.Enums.UserRole.Driver,
                CreatedAt = DateTime.Now
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var driver = new Driver
            {
                UserId = user.UserId,
                LicenseNumber = model.LicenseNumber,
                IsOnline = false,
                IsApproved = false,
                Rating = 5.0m
            };

            _context.Drivers.Add(driver);
            await _context.SaveChangesAsync();

            return RedirectToAction("UserLogin");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("UserLogin");
        }
    }
}
