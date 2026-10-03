namespace BankingApp.Models.Entities;

public class AccountType
{
    public int AccountTypeID { get; set; }
    public string TypeName { get; set; } = string.Empty;
    public decimal InterestRate { get; set; }
    public decimal MinimumBalance { get; set; }

    // Navigation Property
    public ICollection<Account> Accounts { get; set; } = new List<Account>();
}