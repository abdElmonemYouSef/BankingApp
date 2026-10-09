using System.ComponentModel.DataAnnotations;

namespace BankingApp.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "First name is required")]
        public string Fname { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string Lname { get; set; }

        public string FullName => $"{Fname} {Lname}";

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        public bool RememberMe { get; set; }
    }
}