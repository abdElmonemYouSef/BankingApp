using System.ComponentModel.DataAnnotations;

namespace BankingApp.ViewModels
{
    public class GLToAccountViewModel
    {
        [Required(ErrorMessage = "GL Account code is required.")]
        [Display(Name = "GL Account Code")]
        public string GlAccountCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Account number is required.")]
        [Display(Name = "Destination Account Number")]
        public string AccountNumber { get; set; } = string.Empty; 

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [Display(Name = "Description / Notes")]
        public string? Description { get; set; }
    }
}