using System.ComponentModel.DataAnnotations;

namespace BankingApp.ViewModels
{
    public class AddRoleViewModel
    {
        [Required(ErrorMessage = "Role name is required.")]
        [Display(Name = "Role Name")]
        public string roleName { get; set; } = string.Empty;
    }
}