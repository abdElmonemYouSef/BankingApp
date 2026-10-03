using BankingApp.Models.Enums;

namespace BankingApp.Models.Entities;

public class Transaction
{
    public int TransactionID { get; set; }
    public string TransactionRef { get; set; } = Guid.NewGuid().ToString("N");
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "EGP";
    public TransactionChannel Channel { get; set; }
    public string InitiatedBy { get; set; } = string.Empty;
    public TransactionStatus Status { get; set; } = TransactionStatus.Pending;


    public int TransactionTypeID { get; set; }
    public TransactionType TransactionType { get; set; } = null!;

}