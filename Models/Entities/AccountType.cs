namespace BankingApp.Models.Entities;

public class AccountType
{
    public int AccountTypeID { get; set; }
    public string Name { get; set; } = string.Empty;     
    public string ProductCode { get; set; } = string.Empty;
    public string Currency { get; set; } = "EGP";          
}

