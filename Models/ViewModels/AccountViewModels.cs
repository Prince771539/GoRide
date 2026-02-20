using System.ComponentModel.DataAnnotations;

namespace GoRide.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }

    public class DriverRegisterViewModel : UserRegisterViewModel
    {
        [Required(ErrorMessage = "License Number is required")]
        public string LicenseNumber { get; set; }

        [Required(ErrorMessage = "Vehicle Type is required")]
        public string VehicleType { get; set; } // Bike, Car, Auto

        [Required(ErrorMessage = "Vehicle Number is required")]
        public string VehicleNumber { get; set; }
    }
}
