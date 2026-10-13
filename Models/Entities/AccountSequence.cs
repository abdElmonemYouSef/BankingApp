namespace BankingApp.Models
{
    public class AccountSequence
    {
        public int Id { get; set; }
        public string BranchCode { get; set; }    // 3 خانات
        public string ProductCode { get; set; }   // 4 خانات
        public long LastSerial { get; set; }      // آخر رقم سريال
    }
}