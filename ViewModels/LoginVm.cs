using System.ComponentModel.DataAnnotations;

namespace BankingApp.ViewModels
{
    public class LoginVm
    {
        [Required (ErrorMessage ="userName is a required ")]
        public string UserName { get; set; }

        [Required (ErrorMessage ="Bassword is a required ")]
        public string Password { get; set; }
    }
}
