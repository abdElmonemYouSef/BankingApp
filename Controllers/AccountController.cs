using BankingApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Controllers
{
    public class

        AccountController : Controller
    {


        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager; _signInManager = signInManager;
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Login(LoginVm model)
        {

            if (!ModelState.IsValid)
                return View(model);


            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user is null) return NotFound();

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.isPersistent, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("" , "Invalid UserName or Invalid Password");
                return View(model);
            }

            return RedirectToAction("Index" , "Home");

            

                




        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var Appuser = new ApplicationUser()
            {
                FullName = model.FullName,
                Email = model.Email,
                UserName = model.Email

            };
            var result = await _userManager.CreateAsync(Appuser, model.Password);

            if (!result.Succeeded)
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
                return View(model);
            }

            return RedirectToAction(nameof(Login));




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
