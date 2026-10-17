using System.ComponentModel.DataAnnotations;

namespace BankingApp.ViewModels
{
    public class DepositViewModel
    {
        [Required(ErrorMessage = "Account number is required.")]
        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        [Display(Name = "Deposit Amount")]
        public decimal Amount { get; set; }

        [Display(Name = "Description / Notes")]
        public string? Description { get; set; }



        [Display(Name = "Narrative")]
        public string? Narrative { get; set; }
    }
}