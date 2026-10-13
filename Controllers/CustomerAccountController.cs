using BankingApp.Data;
using BankingApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Controllers
{
    public class CustomerAccountController : Controller
    {


        private readonly ApplicationDbContext _context;
        private readonly IAccountService _accountService;


        public CustomerAccountController(ApplicationDbContext context, IAccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Add()
        {
        
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateAccountVM model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                var customerExists = await _context.Customers.AnyAsync(c => c.Id == model.CustomerId);
                if (!customerExists)
                {
                    ModelState.AddModelError("CustomerId", "كود العميل غير موجود بالنظام.");
                    return View(model);
                }

                string generatedAccountNumber = await _accountService.GenerateAccountNumberAsync(model.BranchCode, model.ProductCode);


                TempData["SuccessMessage"] = $"تم فتح الحساب بنجاح! رقم الحساب هو: {generatedAccountNumber}";

                return RedirectToAction("index" , "home" );
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء إنشاء الحساب: {ex.Message}");
                return View(model);
            }
        }

        
        
        [HttpGet]
        public async Task<IActionResult> GetCustomerName(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer == null)
                return Json(new { success = false, message = "العميل غير موجود" });

            return Json(new { success = true, name = customer.FullName }); // افترض إن الخاصية اسمها FullName
            }

        [HttpGet]
        public async Task<IActionResult> GetProductDescription(string productCode)
        {
            var product = await _context.AccountTypes.FirstOrDefaultAsync(p => p.ProductCode == productCode);
            if (product == null)
                return Json(new { success = false, message = "كود المنتج غير مسجل" });

            return Json(new { success = true, description = product.Name }); // الوصف السردي للمنتج
        }
    }






}

