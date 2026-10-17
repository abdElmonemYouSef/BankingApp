using System.ComponentModel.DataAnnotations;

namespace BankingApp.ViewModels
{
    public class UsersVM
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Full name is required.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Branch code is required.")]
        [Display(Name = "Branch Code")]
        public string BranchCode { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; } = true;

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "The password must be at least 6 characters long.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Selected Roles")]
        public List<string> SelectedRoles { get; set; } = new List<string>();

        public List<string>? AvailableRoles { get; set; } = new List<string>();
    }
}