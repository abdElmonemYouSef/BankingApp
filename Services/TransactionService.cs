using BankingApp.Data;
using BankingApp.Models.Entities;
using BankingApp.Models.Enums;
using BankingApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ApplicationDbContext _context;

        public TransactionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DepositAsync(DepositViewModel model, string userId)
        {
            var account = await _context.Accounts
                .FirstOrDefaultAsync(a => a.AccountNumber == model.AccountNumber);

            if (account == null || account.Status != AccountStatus.Active)
            {
                return false;
            }

            try
            {
                account.Balance += model.Amount;

                var transaction = new Transaction
                {
                    Amount = model.Amount,
                    Currency = account.Currency ?? "EGP",
                    Channel = TransactionChannel.Branch,
                    MakerId = userId,
                    TimeStamps = DateTime.UtcNow,
                    Status = TransactionStatus.Completed,
                    TransactionTypeID = 1,
                    Narrative = model.Description ?? "Cash Deposit"
                };

                await _context.Transactions.AddAsync(transaction);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> WithdrawAsync(WithdrawalViewModel model, string userId)
        {
            var account = await _context.Accounts
                .FirstOrDefaultAsync(a => a.AccountNumber == model.AccountNumber);

            if (account == null || account.Status != AccountStatus.Active)
            {
                return false;
            }

            if (account.Balance < model.Amount)
            {
                return false; 
            }
                

            try
            {
                account.Balance -= model.Amount;

                var transaction = new Transaction
                {
                    Amount = model.Amount,
                    Currency = account.Currency ?? "EGP",
                    Channel = TransactionChannel.Branch,
                    MakerId = userId,
                    TimeStamps = DateTime.UtcNow,
                    Status = TransactionStatus.Completed,
                    TransactionTypeID = 2, 
                    Narrative = model.Description 
                };

                await _context.Transactions.AddAsync(transaction);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> TransferAccountToAccountAsync(TransferAccountToAccountViewModel model, string userId)
        {
            var SourceAccountNumber = await _context.Accounts
                .FirstOrDefaultAsync(a => a.AccountNumber == model.SourceAccountNumber);
            var DestinationAccountNumber = await _context.Accounts
                .FirstOrDefaultAsync(a => a.AccountNumber == model.DestinationAccountNumber);

            if (SourceAccountNumber == null || SourceAccountNumber.Status != AccountStatus.Active)
            {
                return false;
            }

            if (DestinationAccountNumber == null )
            {
                return false;
            }

            if (SourceAccountNumber.Balance < model.Amount)
            {
                return false;
            }


            try
            {
                SourceAccountNumber.Balance -= model.Amount;
                DestinationAccountNumber.Balance += model.Amount;

                var transaction = new Transaction
                {
                    Amount = model.Amount,
                    Currency = SourceAccountNumber.Currency ?? "EGP",
                    Channel = TransactionChannel.Branch,
                    MakerId = userId,
                    TimeStamps = DateTime.UtcNow,
                    Status = TransactionStatus.Completed,
                    TransactionTypeID = 3, // ID السحب
                    Narrative = model.Description
                };

                await _context.Transactions.AddAsync(transaction);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<bool> TransferAccountToGLAsync(AccountToGLViewModel model, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TransferGLToAccountAsync(GLToAccountViewModel model, string userId)
        {
            throw new NotImplementedException();
        }
    }
}