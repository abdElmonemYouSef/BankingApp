using BankingApp.Models.Enums;

namespace BankingApp.Models.Entities;

public class Account
{
    public int AccountID { get; set; }
    public string AccountNumber { get; set; } = string.Empty;
    public string IBAN { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public decimal AvailableBalance { get; set; }
    public string Currency { get; set; } = "EGP";
    public AccountStatus Status { get; set; } = AccountStatus.Active;

    // العلاقات الأساسية
    public int CustomerID { get; set; }
    public Customer Customer { get; set; } = null!;

    public int AccountTypeID { get; set; }
    public AccountType AccountType { get; set; } = null!;

    // تعديل الفرع ليكون Foreign Key حقيقي
    public int BranchID { get; set; }
    public Branch Branch { get; set; } = null!;

    // Navigation Properties
    public ICollection<Transaction> DebitedTransactions { get; set; } = new List<Transaction>();
    public ICollection<Transaction> CreditedTransactions { get; set; } = new List<Transaction>();
}