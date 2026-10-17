
using BankingApp.Data;
using BankingApp.Models.Entities; // أو المكان اللي فيه الـ DbContext والـ Branch Entity
using BankingApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Controllers
{
    public class BranchController : Controller
    {
        private readonly ApplicationDbContext _context; 

        public BranchController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? searchTerm = null, int pageIndex = 1, int pageSize = 5)
        {
            var branchesQuery = _context.Branches.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                branchesQuery = branchesQuery.Where(b => b.BranchName.Contains(searchTerm) || b.BranchCode.Contains(searchTerm));
            }

            int totalCount = await branchesQuery.CountAsync();
            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            if (totalPages > 0 && pageIndex > totalPages) pageIndex = totalPages;

            var branchesList = await branchesQuery
                .OrderBy(b => b.BranchName)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Select(b => new BranchViewModel
                {
                    Id = b.BranchID,
                    BranchName = b.BranchName,
                    BranchCode = b.BranchCode,
                    Address = b.Location
                })
                .ToListAsync();

            var model = new BranchIndexViewModel
            {
                Branches = branchesList,
                SearchTerm = searchTerm,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalPages = totalPages
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(BranchIndexViewModel model)
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
        public async Task<IActionResult> Add(AddBranchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var branch = new Branch
            {
                BranchName = model.BranchName,
                BranchCode = model.BranchCode,
                Location = model.Address
            };

            _context.Branches.Add(branch);
            await _context.SaveChangesAsync();

            TempData["success"] = "Branch added successfully!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id )
        {
            var branch = await _context.Branches.FindAsync(id);
            if (id == null || id == 0)
            {
                var emptyModel = new UpdateBranchViewModel(); 
                return View(emptyModel);
            }
            var model = new UpdateBranchViewModel
            {
                Id = branch.BranchID,
                BranchName = branch.BranchName,
                BranchCode = branch.BranchCode,
                Address = branch.Location
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBranchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var branch = await _context.Branches.FindAsync(model.Id);
            if (branch == null)
            {
                ModelState.AddModelError("", "Branch not found.");
                return View(model);
            }

            branch.BranchName = model.BranchName;
            branch.BranchCode = model.BranchCode;
            branch.Location = model.Address;

            _context.Branches.Update(branch);
            await _context.SaveChangesAsync();

            TempData["success"] = "Branch updated successfully!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> GetByCode(string branchCode)
        {
            if (string.IsNullOrWhiteSpace(branchCode))
            {
                TempData["error"] = "Please enter a valid branch code.";
                return RedirectToAction(nameof(Update));
            }

            var branch = await _context.Branches
                .FirstOrDefaultAsync(b => b.BranchCode == branchCode);

            if (branch == null)
            {
                TempData["error"] = "Branch not found with this code.";
                return RedirectToAction(nameof(Update));
            }

            var model = new UpdateBranchViewModel
            {
                Id = branch.BranchID,
                BranchName = branch.BranchName,
                BranchCode = branch.BranchCode,
                Address = branch.Location
            };

            // بنرجع نفس الـ View عشان تظهر بياناته وتقدر تحدثها
            return View("Update", model);
        }
    }
}