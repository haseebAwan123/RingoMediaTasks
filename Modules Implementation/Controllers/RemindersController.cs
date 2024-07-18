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

namespace Modules_Implementation.Controllers
{
    public class RemindersController : Controller
    {
        private readonly IReminderRepository _reminderRepository;

        public RemindersController(IReminderRepository reminderRepository)
        {
            _reminderRepository = reminderRepository;
        }

        // GET: Reminders
        public async Task<IActionResult> Index()
        {
            var result = await _reminderRepository.GetAllRemindersAsync();
           return View(result);
        }

        // GET: Reminders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reminders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,DateTime")] Reminders reminders)
        {
            if (ModelState.IsValid)
            {
                await _reminderRepository.AddReminderAsync(reminders);
                return RedirectToAction(nameof(Index));
            }
            return View(reminders);
        }

        
    }
}
