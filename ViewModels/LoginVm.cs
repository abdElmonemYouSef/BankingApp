using System.ComponentModel.DataAnnotations;

namespace BankingApp.ViewModels
{
    public class LoginVm
    {
        [Required (ErrorMessage ="userName is a required ")]
        public string UserName { get; set; }

        [Required (ErrorMessage ="Bassword is a required ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool isPersistent = false;
    }
}
