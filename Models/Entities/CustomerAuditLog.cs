namespace BankingApp.Models.Entities
{
    public class CustomerAuditLog
    {
        public long LogID { get; set; }
        public string Action { get; set; } = string.Empty;
        public string IPAddress { get; set; } = string.Empty;
        public string DeviceInfo { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public int CustomerUserID { get; set; }
    }

}
