namespace BankingApp.ViewModels
{
    public class RoleIndexViewModel
    {
        public List<RoleViewModel> Roles { get; set; } = new();

        public string? SearchTerm { get; set; } = string.Empty;

        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public int TotalPages { get; set; }
        public bool HasNextPage => PageIndex < TotalPages;
        public bool HasPreviousPage => PageIndex > 1;
    }
}
