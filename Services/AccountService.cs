using BankingApp.Data;
using BankingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Services
{
    public interface IAccountService
    {
        Task<string> GenerateAccountNumberAsync(string branchCode, string productCode);
    }

    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;

        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> GenerateAccountNumberAsync(string branchCode, string productCode)
        {
            // 1. التحقق من الطول الصحيح
            if (string.IsNullOrWhiteSpace(branchCode) || branchCode.Length != 3)
                throw new ArgumentException("رقم الفرع يجب أن يكون 3 خانات.");

            if (string.IsNullOrWhiteSpace(productCode) || productCode.Length != 4)
                throw new ArgumentException("كود المنتج يجب أن يكون 4 خانات.");

            // 2. البحث عن التسلسل الحالي للفرع والمنتج
            var sequence = await _context.accountSequence
                .FirstOrDefaultAsync(s => s.BranchCode == branchCode && s.ProductCode == productCode);

            long nextSerial = 1;

            if (sequence == null)
            {
                // لو أول مرة، أنشئ سجل جديد يبدأ من 1
                sequence = new AccountSequence
                {
                    BranchCode = branchCode,
                    ProductCode = productCode,
                    LastSerial = 1
                };
                _context.accountSequence.Add(sequence);
            }
            else
            {
                // لو موجود، زود السريال بواحدة
                nextSerial = ++sequence.LastSerial;
                _context.accountSequence.Update(sequence);
            }

            // 3. تنسيق السريال ليكون 9 خانات (بإضافة أصفار على اليسار)
            string formattedSerial = nextSerial.ToString("D9");

            // 4. دمج الأجزاء الثلاثة (3 + 4 + 9 = 16 رقم)
            string accountNumber = $"{branchCode}{productCode}{formattedSerial}";

            // 5. حفظ التغييرات في الداتا بيز
            await _context.SaveChangesAsync();

            return accountNumber;
        }
    }
}