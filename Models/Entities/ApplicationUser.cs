using Microsoft.AspNetCore.Identity;

namespace BankingApp.Models.Entities
{

    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }

    }
}
