using Microsoft.Extensions.Options;
using Modules_Implementation.Context;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Modules_Implementation.BackgroundService
{
    public class EmailService : Microsoft.Extensions.Hosting.BackgroundService,IEmailService
    {
        private readonly SMTPConfig _config;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<SMTPConfig> config, IServiceScopeFactory scopeFactory, ILogger<EmailService> logger)
        {
            _config = config.Value;
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("EmailService is starting.");

            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    var reminders = context.Reminders.ToList();
                    foreach (var reminder in reminders)
                    {
                        if (reminder.DateTime == DateTime.Now)
                        {
                           await SendEmailAsync("ahaseebawan123@gmail.com", "Subject", reminder.Title);
                        }
                    }
                    
                    _logger.LogInformation("EmailService is running in the background.");
                }
                await Task.Delay(1000, stoppingToken);
            }

            _logger.LogInformation("EmailService is stopping.");
        }
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            using (var client = new SmtpClient(_config.Host, _config.Port))
            {
                client.EnableSsl = _config.EnableSsl;
                client.Credentials = new NetworkCredential(_config.UserName, _config.Password);

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_config.UserName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(to);

                await client.SendMailAsync(mailMessage);
            }
        }


    }

    public class SMTPConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
