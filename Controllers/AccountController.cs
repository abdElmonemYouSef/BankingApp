using BankingApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace BankingApp.Controllers
{
    public class AccountController : Controller
    {

     [HttpGet]
        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Login(LoginVm model)
        {
            return View();
        }




        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterVM model)
        {
            return View();
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgetPassword(ForgetPassordVM model)
        {
            return View();
        }


    }
}
