using BankingApp.Data;
using BankingApp.Models.Enums;
using BankingApp.Services;
using BankingApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BankingApp.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly ApplicationDbContext _context;

        public TransactionController(ITransactionService transactionService, ApplicationDbContext context)
        {
            _transactionService = transactionService;
            _context = context;
        }

        [HttpGet]
        public IActionResult Deposit()
        {
            return View(new DepositViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deposit(DepositViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "System";

            var isSuccess = await _transactionService.DepositAsync(model, userId);

            if (!isSuccess)
            {
                ModelState.AddModelError(string.Empty, "Failed to process deposit. Check account number or status.");
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }






        [HttpGet]
        public IActionResult Withdraw()
        {
            return View(new WithdrawalViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Withdraw(WithdrawalViewModel model)
        {
            if (!ModelState.IsValid)
            {
                
                return View(model);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "System";

            var isSuccess = await _transactionService.WithdrawAsync(model, userId);

            if (!isSuccess)
            {
                ModelState.AddModelError(string.Empty, "Failed to process withdrawal.");
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }






        [HttpGet]
        public IActionResult TransferAccountToAccount()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TransferAccountToAccount(TransferAccountToAccountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                
                return View(model);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "System";

            var isSuccess = await _transactionService.TransferAccountToAccountAsync(model, userId);

            if (!isSuccess)
            {
                ModelState.AddModelError("", "Failed to process The transfer.");
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }









        [HttpGet]
        public async Task<IActionResult> GetAccountHolderName(string accountNumber)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                return Json(new { success = false, message = "Account number cannot be empty." });
            }

            var account = await _context.Accounts
                .Include(a => a.Customer)
                .FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);

            if (account == null)
            {
                return Json(new { success = false, message = "Invalid account number." });
            }

            var customerName = account.Customer != null ? account.Customer.FullName : "No Customer Linked";

            return Json(new { success = true, customerName = customerName });
        }
    }
}