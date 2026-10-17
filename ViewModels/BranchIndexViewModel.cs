namespace BankingApp.ViewModels
{
    public class BranchIndexViewModel
    {
        public List<BranchViewModel> Branches { get; set; } = new();
        public string? SearchTerm { get; set; } = string.Empty;
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public int TotalPages { get; set; }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
    }
}