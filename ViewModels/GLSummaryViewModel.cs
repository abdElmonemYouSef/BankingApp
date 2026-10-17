using BankingApp.Models.Enums;

namespace BankingApp.ViewModels
{
    public class GLSummaryViewModel
    {
        public int Id { get; set; }
        public string GLNumber { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Currency Currency { get; set; }
        public bool AllowNegative { get; set; }
        public string BranchName { get; set; } = string.Empty;
    }
}