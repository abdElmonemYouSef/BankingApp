using BankingApp.Models.Enums;
using Microsoft.Identity.Client.Extensibility;

namespace BankingApp.Models.Entities;

public class Account
{
    public int AccountID { get; set; }
    public string AccountNumber { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public string Currency { get; set; } = "EGP";
    public AccountStatus Status { get; set; } = AccountStatus.Active;
    public string IBAN => $"{Currency}{AccountNumber}";
    public int CustomerID { get; set; }
    public Customer Customer { get; set; } = null!;

    public int AccountTypeID { get; set; }
    public AccountType AccountType { get; set; } = null!;

    public int BranchID { get; set; }
    public Branch Branch { get; set; } = null!;

    public ICollection<Transaction> DebitedTransactions { get; set; } = new List<Transaction>();
    public ICollection<Transaction> CreditedTransactions { get; set; } = new List<Transaction>();
}