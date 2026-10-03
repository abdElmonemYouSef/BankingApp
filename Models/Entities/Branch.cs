namespace BankingApp.Models.Entities;

public class Branch
{
    public int BranchID { get; set; }
    public string BranchCode { get; set; } = string.Empty;
    public string BranchName { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;

    // Navigation Properties
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    public ICollection<Account> Accounts { get; set; } = new List<Account>();
}