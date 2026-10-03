
namespace BankingApp.Models.Entities;

public class StaffAuditLog
{
    public long LogID { get; set; }
    public string Action { get; set; } = string.Empty;
    public string IPAddress { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public int EmployeeID { get; set; }
    public Employee Employee { get; set; } = null!;
}