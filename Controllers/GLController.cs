using BankingApp.Models.Entities;
using BankingApp.Repositories.Interfaces;
using BankingApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankingApp.Controllers
{
    public class GLController : Controller
    {
        private readonly IRepository<GL> _glRepository;
        private readonly IRepository<Branch> _branchRepository;

        public GLController(IRepository<GL> glRepository, IRepository<Branch> branchRepository)
        {
            _glRepository = glRepository;
            _branchRepository = branchRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var glList = await _glRepository.GetAllAsync(g => g.Branch);

            var viewModelList = glList.Select(g => new GLSummaryViewModel
            {
                Id = g.Id,
                GLNumber = g.GLNumber,
                Description = g.Description,
                Currency = g.Currency,
                AllowNegative = g.AllowNegative,
                BranchName = g.Branch != null ? g.Branch.BranchName : "N/A"
            }).ToList();

            return View(viewModelList);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var viewModel = new GLFormViewModel
            {
                Branches = await GetBranchesSelectListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(GLFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Branches = await GetBranchesSelectListAsync();
                return View(model);
            }

            var glEntity = new GL
            {
                GLNumber = model.GLNumber,
                Description = model.Description,
                Currency = model.Currency,
                AllowNegative = model.AllowNegative,
                BranchID = model.BranchID
            };

            await _glRepository.AddAsync(glEntity);
            await _glRepository.SaveChangesAsync();

            TempData["SuccessMessage"] = "GL account added successfully!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            var glEntity = await _glRepository.GetByIdAsync(id.Value);
            if (glEntity == null) return NotFound();

            var viewModel = new GLFormViewModel
            {
                Id = glEntity.Id,
                GLNumber = glEntity.GLNumber,
                Description = glEntity.Description,
                Currency = glEntity.Currency,
                AllowNegative = glEntity.AllowNegative,
                BranchID = glEntity.BranchID,
                Branches = await GetBranchesSelectListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(GLFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Branches = await GetBranchesSelectListAsync();
                return View(model);
            }

            var glEntity = await _glRepository.GetByIdAsync(model.Id);
            if (glEntity == null) return NotFound();

            glEntity.GLNumber = model.GLNumber;
            glEntity.Description = model.Description;
            glEntity.Currency = model.Currency;
            glEntity.AllowNegative = model.AllowNegative;
            glEntity.BranchID = model.BranchID;

            _glRepository.Update(glEntity);
            await _glRepository.SaveChangesAsync(); 

            TempData["SuccessMessage"] = "GL account updated successfully!";
            return RedirectToAction(nameof(Index));
        }

        #region Helper Methods
        private async Task<IEnumerable<SelectListItem>> GetBranchesSelectListAsync()
        {
            var branches = await _branchRepository.GetAllAsync();

            return branches.Select(b => new SelectListItem
            {
                Value = b.BranchID.ToString(),
                Text = b.BranchName
            }).ToList();
        }
        #endregion
    }
}