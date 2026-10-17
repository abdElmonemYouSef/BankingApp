namespace BankingApp.ViewModels
{
    public class ManageUserRolesVM
    {
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;

        public List<string> SelectedRoles { get; set; } = new List<string>();

        public List<string>? AvailableRoles { get; set; } = new List<string>();
    }
}