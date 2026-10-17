namespace BankingApp.ViewModels
{
    public class BranchViewModel
    {
        public int Id { get; set; }
        public string BranchName { get; set; } = string.Empty;
        public string BranchCode { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}