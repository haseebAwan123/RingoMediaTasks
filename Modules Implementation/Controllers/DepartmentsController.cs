using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modules_Implementation.Context;
using Modules_Implementation.Models;
using Modules_Implementation.Repository;
using Modules_Implementation.ViewModels;

namespace Modules_Implementation.Controllers
{
    public class DepartmentsController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IDepartmentsRepository _departmentRepository;

        public DepartmentsController(IDepartmentsRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            
            var departments = await _departmentRepository.GetAllDepartmentsAsync();
            return View(departments);
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var departments = await _departmentRepository.GetDepartmentByIdAsync(id);
            return View(departments);
        }

        // GET: Departments/Create
        public async Task<IActionResult> CreateAsync()
        {
            var departments = await _departmentRepository.GetParentDepartmentsAsync();
            ViewBag.ParentDepartments = departments;
            var viewModel = new DepartmentViewModel();
            return View(viewModel);
            
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _departmentRepository.AddDepartmentAsync(viewModel);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var errors = ModelState
                 .Where(ms => ms.Value.Errors.Count > 0)
                 .Select(ms => new { ms.Key, Errors = ms.Value.Errors.Select(e => e.ErrorMessage).ToArray() })
                 .ToArray();
            }
            return View(viewModel);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var ParentDepartments = await _departmentRepository.GetParentDepartmentsAsync();
            ViewBag.ParentDepartments = ParentDepartments;
            var departments = await _departmentRepository.GetDepartmentByIdAsync(id);
            return View(departments);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DepartmentViewModel viewModel)
        {
            if (id != viewModel.DepartmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _departmentRepository.UpdateDepartmentAsync(viewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var errors = ModelState
                 .Where(ms => ms.Value.Errors.Count > 0)
                 .Select(ms => new { ms.Key, Errors = ms.Value.Errors.Select(e => e.ErrorMessage).ToArray() })
                 .ToArray();
            }
            return View(viewModel);
        }

       // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }

           await _departmentRepository.DeleteDepartmentAsync(id);

            return RedirectToAction(nameof(Index));
        }

        
    }
}
