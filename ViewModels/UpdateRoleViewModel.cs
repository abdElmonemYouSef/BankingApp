using System.ComponentModel.DataAnnotations;

namespace BankingApp.ViewModels
{
    public class UpdateRoleViewModel
    {
        [Required]
        public string RoleId { get; set; } = string.Empty;

        [Required(ErrorMessage = "New role name is required.")]
        [Display(Name = "New Role Name")]
        public string RoleName { get; set; } = string.Empty;
    }
}