
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankingApp.ViewModels
{
    public class CreateTransactionViewModel
    {
        [Required(ErrorMessage = "The Account field is required.")]
        [Display(Name = "Account")]
        public string Account { get; set; }

        [Required(ErrorMessage = "The Amount field is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The amount must be greater than zero.")]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "The Currency field is required.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Currency code must be 3 characters (e.g., EGP).")]
        [Display(Name = "Currency")]
        public string Currency { get; set; } = "EGP";


        [Required(ErrorMessage = "Please select a transaction type.")]
        [Display(Name = "Transaction Type")]
        public int TransactionTypeID { get; set; }

        public IEnumerable<SelectListItem>? TransactionTypesList { get; set; }
    }
}