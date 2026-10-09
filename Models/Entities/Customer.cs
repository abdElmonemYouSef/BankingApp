using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BankingApp.Models.Enums;
namespace BankingApp.Models.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "National ID is required")]
        [RegularExpression(@"^[0-9]{14}$", ErrorMessage = "National ID must be exactly 14 digits")]
        public string NationalId { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "Phone number must start with 010, 011, 012, or 015 and be exactly 11 digits.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public CustomerCategory Category { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }

        public bool HasOnlineBanking { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;

        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

        [ForeignKey(nameof(Branch))]
        public int BranchId { get; set; }

        public Branch Branch { get; set; }
    }
}