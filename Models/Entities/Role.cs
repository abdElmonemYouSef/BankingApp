namespace BankingApp.Models.Entities;

public class Role
{
    public int RoleID { get; set; }
    public string RoleName { get; set; } = string.Empty;

    // Navigation Property
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}