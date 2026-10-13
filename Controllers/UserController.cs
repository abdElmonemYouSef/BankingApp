using BankingApp.Models.Entities;
using BankingApp.Repositories.Interfaces;
using BankingApp.ViewModels; // تأكد من مساحة الأسماء الخاصة بالـ ViewModels
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BankingApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepository<ApplicationUser> _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(IRepository<ApplicationUser> userRepository, UserManager<ApplicationUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // في البداية نعرض كل المستخدمين أو نترك القائمة فارغة حسب رغبتك
            var users = await _userRepository.FindAsync();
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UsersVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var filters = new List<Expression<Func<ApplicationUser, bool>>>();

            if (!string.IsNullOrEmpty(model.FullName))
            {
                filters.Add(u => u.FullName.Contains(model.FullName));
            }

            if (!string.IsNullOrEmpty(model.Email))
            {
                filters.Add(u => u.Email.Contains(model.Email));
            }


            var filteredUsers = await _userRepository.FindAsync(filters.ToArray());

            return View(filteredUsers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(UsersVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName,
            };

            // استخدام UserManager لإنشاء اليوزر مع كلمة المرور
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "تم إنشاء المستخدم بنجاح!";
                return RedirectToAction(nameof(Index));
            }

            // لو فيه أخطاء من الـ Identity ضيفها للـ ModelState
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            // تعبئة الـ ViewModel بالبيانات الحالية للمستخدم لعرضها في الفيو
            var model = new UsersVM
            {
                // Id = user.Id, // لو الـ ViewModel فيه Id
                FullName = user.FullName,
                Email = user.Email,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UsersVM model, string id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.FullName = model.FullName;
            user.Email = model.Email;
            user.UserName = model.Email;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "تم تعديل بيانات المستخدم بنجاح!";
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }
    }
}