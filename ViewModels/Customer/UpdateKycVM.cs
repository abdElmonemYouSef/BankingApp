

using System.ComponentModel.DataAnnotations;
using BankingApp.Models.Enums;

namespace BankingApp.ViewModels.Customer

{
    public class UpdateKycVM
    {
        [Required(ErrorMessage = "National ID is required")]
        [RegularExpression(@"^[0-9]{14}$", ErrorMessage = "National ID must be exactly 14 digits")]
        [Display(Name = "National ID")]
        public string NationalId { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(100, ErrorMessage = "Full Name cannot exceed 100 characters")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(150, ErrorMessage = "Email cannot exceed 150 characters")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "Phone number must start with 010, 011, 012, or 015 and be exactly 11 digits")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please select a customer category")]
        [Display(Name = "Customer Category")]
        public CustomerCategory Category { get; set; }

        [StringLength(250, ErrorMessage = "Address cannot exceed 250 characters")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Enable Online Banking")]
        public bool HasOnlineBanking { get; set; } = false;
    }
}