using BankingApp.Models.Enums;

namespace BankingApp.Models.Entities
{
    public class GL
    {
        public int Id { get; set; }
        public string GLNumber { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Currency Currency { get; set; } = Currency.EGP;
        public bool AllowNegative { get; set; } = true;

        public int BranchID { get; set; }
        public Branch Branch { get; set; } = null!;
    }
}