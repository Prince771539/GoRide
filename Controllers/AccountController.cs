using Microsoft.AspNetCore.Mvc;
using GoRide.Models.ViewModels;

namespace GoRide.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserLogin(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Dummy login logic
                return RedirectToAction("Dashboard", "User");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult UserRegister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserRegister(UserRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("UserLogin");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult DriverLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DriverLogin(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Dashboard", "Driver");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult DriverRegister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DriverRegister(DriverRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("DriverLogin");
            }
            return View(model);
        }
    }
}
