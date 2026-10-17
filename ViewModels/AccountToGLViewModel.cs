using System.ComponentModel.DataAnnotations;

namespace BankingApp.ViewModels
{
    public class AccountToGLViewModel
    {
        [Required(ErrorMessage = "Account number is required.")]
        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "GL Account code is required.")]
        [Display(Name = "GL Account Code")]
        public string GlAccountCode { get; set; } = string.Empty; // مثل حساب المصروفات أو الرسوم

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [Display(Name = "Description / Notes")]
        public string? Description { get; set; }
    }
}