using System.ComponentModel.DataAnnotations;

namespace BankingApp.ViewModels
{
    public class UpdateBranchViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Branch name is required.")]
        [Display(Name = "Branch Name")]
        public string BranchName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Branch code is required.")]
        [Display(Name = "Branch Code")]
        public string BranchCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required.")]
        [Display(Name = "Branch Address")]
        public string Address { get; set; } = string.Empty;
    }
}