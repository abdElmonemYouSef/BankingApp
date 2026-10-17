using BankingApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Controllers
{
    public class RoleController : Controller
    {
        private readonly UserManager <ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        [HttpGet]
        public IActionResult Index(string? searchTerm = null, int pageIndex = 1, int pageSize = 5)
        {
            var rolesQuery = _roleManager.Roles.AsQueryable();

            // تطبيق الفلتر لو اليوزر كاتب كلمة بحث
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                rolesQuery = rolesQuery.Where(r => r.Name != null && r.Name.Contains(searchTerm));
            }

            // حساب الصفحات
            int totalCount = rolesQuery.Count();
            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            if (totalPages > 0 && pageIndex > totalPages) pageIndex = totalPages;

            // جلب الداتا الخاصة بالصفحة الحالية
            var rolesList = rolesQuery
                .OrderBy(r => r.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Select(r => new RoleViewModel
                {
                    Id = r.Id,
                    RoleName = r.Name ?? string.Empty
                })
                .ToList();

            // إنشاء وحشو الـ RoleIndexViewModel
            var model = new RoleIndexViewModel
            {
                Roles = rolesList,
                SearchTerm = searchTerm,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalPages = totalPages
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(RoleIndexViewModel model)
        {
            return RedirectToAction(nameof(Index), new
            {
                searchTerm = model.SearchTerm,
                pageIndex = 1,
                pageSize = model.PageSize
            });
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add( AddRoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var roleName = model.roleName;
            var role = new IdentityRole(roleName);
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
              var result =  await _roleManager.CreateAsync(role);
                if ( !result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", "failed to add the role ");
                    }
                }

            }

            TempData["success"] = "a new role has been added successfully "; 

            return RedirectToAction ("index" , "home");
        }


        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(UpdateRoleViewModel model)
        {
            return View();
        }


        [HttpGet]
        public IActionResult ModifyAccess()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ModifyAccess(ModifyAccessViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.email);

            if (user == null)
            {
                ModelState.AddModelError("" , "user is not found ");
            }

            var result = await _userManager.AddToRoleAsync(user, model.roleName);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                    ModelState.AddModelError("", "failed to add the role for the given user  ");

                return View(model);
            }
            return RedirectToAction("index" , "home") ;

        }

    }
}
