using BankingApp.Models.Enums;

namespace BankingApp.Models.Entities;

public class Customer
{
    public int CustomerID { get; set; }
    public string CIF { get; set; } = string.Empty;
    public string NationalID { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public CustomerStatus Status { get; set; } = CustomerStatus.Active;

    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }

    // Navigation Properties
    public ICollection<Account> Accounts { get; set; } = new List<Account>();
    public ICollection<Beneficiary> Beneficiaries { get; set; } = new List<Beneficiary>();
}