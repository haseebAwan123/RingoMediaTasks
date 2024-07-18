using Modules_Implementation.Context;

namespace Modules_Implementation.BackgroundServices
{
    public class BackgroundWorkedService : Microsoft.Extensions.Hosting.BackgroundService
    {
        //private readonly ApplicationDbContext _context;
        //public BackgroundWorkedService(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
