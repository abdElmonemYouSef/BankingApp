using System.ComponentModel.DataAnnotations;
using BankingApp.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankingApp.ViewModels
{
    public class GLFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "GL Number is required.")]
        [Display(Name = "GL Number")]
        public string GLNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Currency is required.")]
        [Display(Name = "Currency")]
        public Currency Currency { get; set; } = Currency.EGP;

        [Display(Name = "Allow Negative Balance")]
        public bool AllowNegative { get; set; } = true;

        [Required(ErrorMessage = "Please select a branch.")]
        [Display(Name = "Branch")]
        public int BranchID { get; set; }

        // قائمة الفروع للـ DropDownList
        public IEnumerable<SelectListItem>? Branches { get; set; }
    }
}