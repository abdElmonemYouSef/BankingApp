using BankingApp.Data;
using BankingApp.Models.Entities;
using BankingApp.Repositories.Interfaces;
using BankingApp.ViewModels.Customer;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepository<Customer> _CustomerManger;

        public CustomerController(IRepository<Customer> customerManger)
        {
            _CustomerManger = customerManger;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
     [HttpPost]
        public async Task<IActionResult> Add(CreateCustomerVM model )
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var NewCustomer = new Customer()
            {
                Address = model.Address,
                Category = model.Category,
                NationalId  = model.NationalId,
                FullName = model.FullName,
                Email = model.Email,
                CreatedAt = DateTime.UtcNow,
                PhoneNumber = model.PhoneNumber,

            };

             await _CustomerManger.AddAsync(NewCustomer);
            await _CustomerManger.SaveChangesAsync();

            return RedirectToAction("Index" , "home" );
        }
     [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
     [HttpPost]
        public IActionResult Update(UpdateKycVM model )
        {
            return View();
        }
    }
}



