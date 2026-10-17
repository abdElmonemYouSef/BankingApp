namespace BankingApp.Services


{
    public interface IAccountService
    {
        // ميثود توليد رقم الحساب بناءً على كود الفرع وكود المنتج
        Task<string> GenerateAccountNumberAsync(int branchCode, string productCode);
    }
}