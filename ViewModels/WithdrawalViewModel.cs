using System.ComponentModel.DataAnnotations;

namespace BankingApp.ViewModels
{
    public class WithdrawalViewModel
    {
        [Required(ErrorMessage = "Account number is required.")]
        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; } 

        [Display(Name = "Account Holder Name")]
        public string? AccontHolderName { get; set; } 

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        [Display(Name = "Withdrawal Amount")]
        public decimal Amount { get; set; }

        [Display(Name = "Description / Notes")]
        public string? Description { get; set; }
    }
}