using System.ComponentModel.DataAnnotations;

namespace BankingApp.ViewModels
{
    public class ModifyAccessViewModel
    {
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [Display(Name = "User Email")]
        public string email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Role name is required.")]
        [Display(Name = "Role Name")]
        public string roleName { get; set; } = string.Empty;
    }
}