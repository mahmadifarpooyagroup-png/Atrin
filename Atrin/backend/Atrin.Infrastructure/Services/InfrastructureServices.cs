using Microsoft.Extensions.Configuration;

namespace Atrin.Infrastructure.Services;

public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.Now;
    public DateTime UtcNow => DateTime.UtcNow;
}

public class EmailService : IEmailService
{
    private readonly ILogger<EmailService> _logger;

    public EmailService(ILogger<EmailService> logger)
    {
        _logger = logger;
    }

    public Task SendEmailAsync(string to, string subject, string body)
    {
        _logger.LogInformation("Email would be sent to {To} with subject {Subject}", to, subject);
        return Task.CompletedTask;
    }
}

public class SmsService : ISmsService
{
    private readonly ILogger<SmsService> _logger;

    public SmsService(ILogger<SmsService> logger)
    {
        _logger = logger;
    }

    public Task SendSmsAsync(string phoneNumber, string message)
    {
        _logger.LogInformation("SMS would be sent to {PhoneNumber}: {Message}", phoneNumber, message);
        return Task.CompletedTask;
    }
}
