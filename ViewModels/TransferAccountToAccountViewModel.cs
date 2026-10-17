using System.ComponentModel.DataAnnotations;

namespace BankingApp.ViewModels
{
    public class TransferAccountToAccountViewModel

    {
        [Required(ErrorMessage = "Source account number is required.")]
        [Display(Name = "From Account Number")]
        public string SourceAccountNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Destination account number is required.")]
        [Display(Name = "To Account Number")]
        public string DestinationAccountNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        [Display(Name = "Transfer Amount")]
        public decimal Amount { get; set; }

        [Display(Name = "Description / Notes")]
        public string? Description { get; set; }
    }
}