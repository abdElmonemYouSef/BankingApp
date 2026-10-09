namespace BankingApp.Models.Entities;

public class AccountType
{
    public int AccountTypeID { get; set; }
    public string Name { get; set; } = string.Empty;       // مثال: حساب توفير بالدولار
    public string ProductCode { get; set; } = string.Empty;  // مثال: 101
    public string Currency { get; set; } = "EGP";          // العملة الخاصة بالمنتج ده (EGP, USD, EUR)
}

