using System.ComponentModel.DataAnnotations;
using BankingApp.Models.Enums;

namespace BankingApp.ViewModels
{
    public class ReviewTransactionViewModel
    {
        public int TransactionID { get; set; }

        [Display(Name = "Transaction Ref")]
        public string TransactionRef { get; set; } = string.Empty;

        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [Display(Name = "Currency")]
        public string Currency { get; set; } = string.Empty;

        [Display(Name = "Channel")]
        public TransactionChannel Channel { get; set; }

        [Display(Name = "Maker ID / Name")]
        public string MakerName { get; set; } = string.Empty;

        [Display(Name = "Timestamp")]
        public DateTime TimeStamps { get; set; }

        [Display(Name = "Transaction Type")]
        public string TransactionTypeName { get; set; } = string.Empty;

        // === 2. المدخلات الخاصة بالـ Checker (القرار والملاحظات) ===
        [Required(ErrorMessage = "Please specify a decision status.")]
        [Display(Name = "Decision")]
        public TransactionStatus Status { get; set; } // غالباً بتبقى Approved أو Rejected

        [Display(Name = "Review Notes")]
        [StringLength(500, ErrorMessage = "Review notes cannot exceed 500 characters.")]
        public string? ReviewNotes { get; set; }
    }
}