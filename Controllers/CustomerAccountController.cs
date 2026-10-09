using BankingApp.ViewModels.CustomerAccount;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Controllers
{
    public class CustomerAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(CreatCustomerAccountVM model )
        {

            return View();
        }





    }
}
