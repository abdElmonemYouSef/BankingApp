using BankingApp.Data;
using global::BankingApp.Data;
using Microsoft.EntityFrameworkCore;


namespace BankingApp.Services
{
    public class AccountService : IAccountService

    {
        private readonly ApplicationDbContext _context;

        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> GenerateAccountNumberAsync(int branchCode, string productCode)
        {


            string yearComponent = DateTime.UtcNow.ToString("yy");

            int count = await _context.AccountTypes
                .CountAsync(a => a.AccountTypeID == branchCode && a.ProductCode == productCode);

            long nextSerial = count + 1;

            string serialFormatted = nextSerial.ToString("D6");

            string generatedAccountNumber = $"{branchCode}{productCode}{serialFormatted}";

            return generatedAccountNumber;
        }

    }
}