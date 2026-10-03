namespace BankingApp.Models.Entities;

public class Beneficiary
{
    public int BeneficiaryID { get; set; }
    public string BeneficiaryName { get; set; } = string.Empty;
    public string AccountOrIBAN { get; set; } = string.Empty;
    public string BankName { get; set; } = string.Empty;
    public string Nickname { get; set; } = string.Empty;

    public int CustomerID { get; set; }
    public Customer Customer { get; set; } = null!;
}