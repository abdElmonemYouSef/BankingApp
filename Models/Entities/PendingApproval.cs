using BankingApp.Models.Enums;

namespace BankingApp.Models.Entities;

public class PendingApproval
{
    public int ApprovalID { get; set; }
    public string EntityType { get; set; } = string.Empty;
    public int? EntityID { get; set; }
    public string RequestPayloadJson { get; set; } = string.Empty;
    public PendingApprovalStatus Status { get; set; } = PendingApprovalStatus.Pending;
    public DateTime RequestedAt { get; set; } = DateTime.UtcNow;

    // Maker
    public int MakerEmployeeID { get; set; }
    public Employee MakerEmployee { get; set; } = null!;

    // Checker
    public int? CheckerEmployeeID { get; set; }
    public Employee? CheckerEmployee { get; set; }

    // Navigation Property
    public Transaction? Transaction { get; set; }
}