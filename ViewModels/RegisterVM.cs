using System.ComponentModel.DataAnnotations;

namespace BankingApp.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="field is required")]
        public string Fname { get; set; }


        [Required(ErrorMessage ="field is required")]
        public string Lname { get; set; }

        [Required(ErrorMessage ="field is required")]
        public string Password { get; set; }


        [Required(ErrorMessage ="field is required")]
        [DataType(DataType.Password)]
        public int ConfirmBassword { get; set; }

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]

        public bool RememberMe { get; set; }
    }
}
