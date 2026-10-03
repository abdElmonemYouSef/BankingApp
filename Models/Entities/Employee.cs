namespace BankingApp.Models.Entities;

public class Employee
{
    public int EmployeeID { get; set; }
    public string EmpCode { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;

    public int BranchID { get; set; }
    public Branch Branch { get; set; } = null!;
    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }





    // Navigation Properties
    public ICollection<Role> Roles { get; set; } = new List<Role>();

    //public ICollection<StaffAuditLog> StaffAuditLogs { get; set; } = new List<StaffAuditLog>();
}