using System.ComponentModel.DataAnnotations;

namespace BankingApp.ViewModels
{
    public class CreateAccountVM
    {
        [Display(Name = "Customer ID")]
        [Required(ErrorMessage = "Please enter the customer ID.")]
        public int CustomerId { get; set; }

        [Display(Name = "Customer Name")]
        public string? CustomerName { get; set; } // هيتعبى أوتوماتيك بـ AJAX

        [Display(Name = "Product Code")]
        [Required(ErrorMessage = "Please enter the product code.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Product code must be exactly 4 characters.")]
        public string ProductCode { get; set; }

        [Display(Name = "Product Description")]
        public string? ProductDescription { get; set; } // هيتعبى أوتوماتيك بـ AJAX

        [Display(Name = "Branch Code")]
        [Required(ErrorMessage = "Please enter the branch code.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Branch code must be exactly 3 characters.")]
        public string BranchCode { get; set; }
    }
}