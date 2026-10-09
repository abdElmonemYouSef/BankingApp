using BankingApp.Data;
using BankingApp.Models.Entities;
using Microsoft.EntityFrameworkCore;




namespace BankingApp.Services;

public class AccountNumberGeneratorService
{
    private readonly ApplicationDbContext _context;

    public AccountNumberGeneratorService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> GenerateNextAccountNumberAsync(int branchId, int accountTypeId, string branchCode, string productCode)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var sequence = await _context.Set<AccountSequence>()
                .FromSqlRaw(@"SELECT * FROM AccountSequences WITH (UPDLOCK, ROWLOCK) 
                              WHERE BranchID = {0} AND AccountTypeID = {1}", branchId, accountTypeId)
                .FirstOrDefaultAsync();

            if (sequence == null)
            {
                sequence = new AccountSequence
                {
                    BranchID = branchId,
                    AccountTypeID = accountTypeId,
                    LastNumber = 1
                };
                _context.Set<AccountSequence>().Add(sequence);
            }
            else
            {
                sequence.LastNumber++;
            }

            await _context.SaveChangesAsync();

            string formattedBranchCode = branchCode.PadLeft(3, '0');
            string formattedProductCode = productCode.PadLeft(3, '0');
            string formattedSerialNumber = sequence.LastNumber.ToString().PadLeft(6, '0');

            string generatedAccountNumber = $"{formattedBranchCode}{formattedProductCode}{formattedSerialNumber}";

            await transaction.CommitAsync();

            return generatedAccountNumber;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}