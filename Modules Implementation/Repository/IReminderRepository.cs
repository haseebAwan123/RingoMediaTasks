using Modules_Implementation.Models;

namespace Modules_Implementation.Repository
{
    public interface IReminderRepository
    {
        Task AddReminderAsync(Reminders viewModel);
        Task<IEnumerable<Reminders>> GetAllRemindersAsync();
    }
}
