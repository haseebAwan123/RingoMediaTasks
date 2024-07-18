using Microsoft.EntityFrameworkCore;
using Modules_Implementation.Context;
using Modules_Implementation.Models;

namespace Modules_Implementation.Repository
{
    public class ReminderRepository : IReminderRepository
    {
        private readonly ApplicationDbContext _context;
        public ReminderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddReminderAsync(Reminders viewModel)
        {
            if (viewModel != null)
            {
                await _context.Reminders.AddAsync(viewModel);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Reminders>> GetAllRemindersAsync()
        {
            var Reminders = await _context.Reminders.ToListAsync();
            return Reminders;
        }
    }
}
