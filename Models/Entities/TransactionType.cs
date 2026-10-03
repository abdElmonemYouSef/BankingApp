namespace BankingApp.Models.Entities;

public class TransactionType
{
    public int TransactionTypeID { get; set; }
    public string TypeName { get; set; } = string.Empty;

    // Navigation Property
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}