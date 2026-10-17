using System.Threading.Tasks;
using BankingApp.ViewModels;

namespace BankingApp.Services
{
    public interface ITransactionService
    {
        // 1. Deposit
        Task<bool> DepositAsync(DepositViewModel model, string userId);

        // 2. Withdrawal
        Task<bool> WithdrawAsync(WithdrawalViewModel model, string userId);

        // 3. Account to Account Transfer
        Task<bool> TransferAccountToAccountAsync(TransferAccountToAccountViewModel model, string userId);

        // 4. Account to GL Transfer
        Task<bool> TransferAccountToGLAsync(AccountToGLViewModel model, string userId);

        // 5. GL to Account Transfer
        Task<bool> TransferGLToAccountAsync(GLToAccountViewModel model, string userId);
    }
}